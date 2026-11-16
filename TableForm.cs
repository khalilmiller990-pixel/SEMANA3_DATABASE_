using System.Data;
using Microsoft.Data.SqlClient;

namespace b_d_semana3;

public sealed partial class TableForm : Form
{
    private DatabaseService? _database;
    private TableInfo? _tableInfo;
    private DataTable? _data;
    private bool _canEdit;

    public TableForm()
    {
        InitializeComponent();
    }

    public TableForm(DatabaseService database, TableInfo tableInfo) : this()
    {
        _database = database;
        _tableInfo = tableInfo;
        Text = $"Formulario: {_tableInfo}";
        btnReload.Click += (_, _) => ReloadData();
        btnAdd.Click += (_, _) => AddRow();
        btnDelete.Click += (_, _) => DeleteRow();
        btnSave.Click += (_, _) => SaveChanges();
        dgvTable.DataError += (_, args) =>
        {
            args.ThrowException = false;
            MessageBox.Show(args.Exception?.Message ?? "El valor no es válido para esta columna.", "Dato no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        };
        ReloadData();
    }

    private void ReloadData()
    {
        if (_database is null || _tableInfo is null)
        {
            return;
        }

        if (_data?.GetChanges() is not null && MessageBox.Show("Hay cambios sin guardar. ¿Descartarlos y volver a cargar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        try
        {
            _data = _database.LoadTable(_tableInfo);
            dgvTable.DataSource = _data;
            _canEdit = _data.PrimaryKey.Length > 0;
            foreach (var columnName in _database.GetReadOnlyColumns(_tableInfo))
            {
                if (dgvTable.Columns[columnName] is { } column)
                {
                    column.ReadOnly = true;
                }
            }

            dgvTable.AllowUserToAddRows = _canEdit;
            dgvTable.AllowUserToDeleteRows = _canEdit;
            dgvTable.ReadOnly = !_canEdit;
            btnAdd.Enabled = _canEdit;
            btnDelete.Enabled = _canEdit;
            btnSave.Enabled = _canEdit;
            if (!_canEdit)
            {
                MessageBox.Show("La tabla no tiene clave primaria; se abre en modo de solo lectura.", "Solo lectura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo cargar {_tableInfo}.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void AddRow()
    {
        if (!_canEdit || _data is null)
        {
            return;
        }

        var row = _data.NewRow();
        _data.Rows.Add(row);
        var index = dgvTable.Rows.Count - 1;
        if (index >= 0)
        {
            dgvTable.CurrentCell = dgvTable.Rows[index].Cells.Cast<DataGridViewCell>().FirstOrDefault(cell => !cell.ReadOnly);
        }
    }

    private void DeleteRow()
    {
        if (!_canEdit || dgvTable.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        if (MessageBox.Show("¿Marcar la fila seleccionada para eliminar? Se aplicará al guardar.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            rowView.Delete();
        }
    }

    private void SaveChanges()
    {
        if (!_canEdit || _data is null || _database is null || _tableInfo is null)
        {
            return;
        }

        try
        {
            dgvTable.EndEdit();
            if (_data.GetChanges() is null)
            {
                MessageBox.Show("No hay cambios para guardar.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _database.SaveTable(_tableInfo, _data);
            MessageBox.Show("Los cambios se guardaron correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReloadData();
        }
        catch (Exception ex) when (ex is SqlException or InvalidOperationException or ConstraintException)
        {
            MessageBox.Show($"No se pudieron guardar los cambios. Revisa los datos y las relaciones de la tabla.\n{ex.Message}", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudieron guardar los cambios.\n{ex.Message}", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
