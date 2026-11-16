namespace b_d_semana3;

public sealed partial class MainForm : Form
{
    private DatabaseService? _database;
    private string _userName = string.Empty;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(DatabaseService database, string userName) : this()
    {
        _database = database;
        _userName = userName;
        lblHeader.Text = $"Base de datos pubs  |  Usuario: {_userName}";
        LoadTableButtons();
    }

    private void LoadTableButtons()
    {
        if (_database is null)
        {
            return;
        }

        try
        {
            flpTables.Controls.Clear();
            var tables = _database.GetTables();
            foreach (var table in tables)
            {
                var button = new Button
                {
                    Text = table.ToString(),
                    Width = 225,
                    Height = 50,
                    Margin = new Padding(8),
                    Tag = table
                };
                button.Click += OpenTable;
                flpTables.Controls.Add(button);
            }

            if (tables.Count == 0)
            {
                flpTables.Controls.Add(new Label { Text = "No se encontraron tablas de datos.", AutoSize = true, Padding = new Padding(8) });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudieron cargar las tablas.\n{ex.Message}", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            BeginInvoke(Close);
        }
    }

    private void OpenTable(object? sender, EventArgs e)
    {
        if (_database is not null && sender is Button { Tag: TableInfo table })
        {
            using var form = new TableForm(_database, table);
            form.ShowDialog(this);
        }
    }
}
