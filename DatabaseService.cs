using System.Data;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace b_d_semana3;

public sealed class DatabaseService
{
    private const string UsersTableName = "AppUsers";
    private const int PasswordIterations = 210_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    private readonly string _connectionString;

    public DatabaseService()
        : this(Environment.GetEnvironmentVariable("B_D_SEMANA3_CONNECTION_STRING") ??
               "Data Source=DESKTOP-3JK7CD9;Initial Catalog=pubs;Integrated Security=True;TrustServerCertificate=True;")
    {
    }

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Initialize()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"""
            IF OBJECT_ID(N'dbo.{UsersTableName}', N'U') IS NULL
            BEGIN
                CREATE TABLE dbo.{QuoteIdentifier(UsersTableName)}
                (
                    UserName nvarchar(100) NOT NULL PRIMARY KEY,
                    PasswordSalt varbinary({SaltSize}) NOT NULL,
                    PasswordHash varbinary({HashSize}) NOT NULL,
                    CreatedAt datetime2 NOT NULL CONSTRAINT DF_AppUsers_CreatedAt DEFAULT SYSUTCDATETIME()
                );
            END
            """;
        command.ExecuteNonQuery();
    }

    public bool HasUsers()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand($"SELECT CASE WHEN EXISTS (SELECT 1 FROM dbo.{QuoteIdentifier(UsersTableName)}) THEN 1 ELSE 0 END", connection);
        return Convert.ToInt32(command.ExecuteScalar()) != 0;
    }

    public void RegisterUser(string userName, string password)
    {
        var normalizedUserName = userName.Trim();
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, PasswordIterations, HashAlgorithmName.SHA256, HashSize);

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var transaction = connection.BeginTransaction(IsolationLevel.Serializable);
        using var command = new SqlCommand($"INSERT INTO dbo.{QuoteIdentifier(UsersTableName)} (UserName, PasswordSalt, PasswordHash) VALUES (@userName, @salt, @hash)", connection, transaction);
        command.Parameters.Add("@userName", SqlDbType.NVarChar, 100).Value = normalizedUserName;
        command.Parameters.Add("@salt", SqlDbType.VarBinary, SaltSize).Value = salt;
        command.Parameters.Add("@hash", SqlDbType.VarBinary, HashSize).Value = hash;
        command.ExecuteNonQuery();
        transaction.Commit();
    }

    public bool Authenticate(string userName, string password)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand($"SELECT PasswordSalt, PasswordHash FROM dbo.{QuoteIdentifier(UsersTableName)} WHERE UserName = @userName", connection);
        command.Parameters.Add("@userName", SqlDbType.NVarChar, 100).Value = userName.Trim();
        using var reader = command.ExecuteReader(CommandBehavior.SingleRow);
        if (!reader.Read())
        {
            return false;
        }

        var salt = (byte[])reader["PasswordSalt"];
        var expectedHash = (byte[])reader["PasswordHash"];
        var actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, PasswordIterations, HashAlgorithmName.SHA256, expectedHash.Length);
        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }

    public IReadOnlyList<TableInfo> GetTables()
    {
        var tables = new List<TableInfo>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT s.name, t.name FROM sys.tables AS t INNER JOIN sys.schemas AS s ON s.schema_id = t.schema_id WHERE t.is_ms_shipped = 0 AND NOT (s.name = N'dbo' AND t.name IN (@usersTable, N'sysdiagrams')) ORDER BY s.name, t.name", connection);
        command.Parameters.Add("@usersTable", SqlDbType.NVarChar, 128).Value = UsersTableName;
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            tables.Add(new TableInfo(reader.GetString(0), reader.GetString(1)));
        }

        return tables;
    }

    public DataTable LoadTable(TableInfo table)
    {
        using var connection = new SqlConnection(_connectionString);
        using var adapter = new SqlDataAdapter($"SELECT * FROM {QuoteIdentifier(table.SchemaName)}.{QuoteIdentifier(table.TableName)}", connection)
        {
            MissingSchemaAction = MissingSchemaAction.AddWithKey
        };
        var data = new DataTable(table.TableName);
        adapter.Fill(data);
        return data;
    }

    public IReadOnlyList<string> GetReadOnlyColumns(TableInfo table)
    {
        var columns = new List<string>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT c.name FROM sys.columns AS c INNER JOIN sys.tables AS t ON t.object_id = c.object_id INNER JOIN sys.schemas AS s ON s.schema_id = t.schema_id WHERE s.name = @schema AND t.name = @table AND (c.is_identity = 1 OR c.is_computed = 1 OR c.system_type_id = 189)", connection);
        command.Parameters.Add("@schema", SqlDbType.NVarChar, 128).Value = table.SchemaName;
        command.Parameters.Add("@table", SqlDbType.NVarChar, 128).Value = table.TableName;
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            columns.Add(reader.GetString(0));
        }

        return columns;
    }

    public void SaveTable(TableInfo table, DataTable data)
    {
        using var connection = new SqlConnection(_connectionString);
        using var adapter = new SqlDataAdapter($"SELECT * FROM {QuoteIdentifier(table.SchemaName)}.{QuoteIdentifier(table.TableName)}", connection);
        using var builder = new SqlCommandBuilder(adapter);
        adapter.Update(data);
    }

    private static string QuoteIdentifier(string identifier) => $"[{identifier.Replace("]", "]]", StringComparison.Ordinal)}]";
}

public sealed record TableInfo(string SchemaName, string TableName)
{
    public override string ToString() => $"{SchemaName}.{TableName}";
}
