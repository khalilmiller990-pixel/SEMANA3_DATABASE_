namespace b_d_semana3;

public sealed partial class LoginForm : Form
{
    private DatabaseService? _database;
    private bool _firstUser = true;
    private int _failedAttempts;

    public string AuthenticatedUser { get; private set; } = string.Empty;

    public LoginForm()
    {
        InitializeComponent();
        btnSubmit.Click += SubmitClicked;
        ConfigureMode(true);
    }

    public LoginForm(DatabaseService database) : this()
    {
        _database = database;
        ConfigureMode(!_database.HasUsers());
    }

    private void ConfigureMode(bool firstUser)
    {
        _firstUser = firstUser;
        Text = _firstUser ? "Crear usuario inicial" : "Inicio de sesión";
        lblTitle.Text = _firstUser ? "Crea el primer usuario del sistema" : "Inicia sesión para continuar";
        lblConfirmPassword.Visible = _firstUser;
        txtConfirmPassword.Visible = _firstUser;
        btnSubmit.Text = _firstUser ? "Crear cuenta" : "Iniciar sesión";
    }

    private void SubmitClicked(object? sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (_database is null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            lblMessage.Text = "Escribe el usuario y la contraseña.";
            return;
        }

        try
        {
            if (_firstUser)
            {
                if (txtPassword.Text.Length < 8)
                {
                    lblMessage.Text = "La contraseña debe tener al menos 8 caracteres.";
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblMessage.Text = "Las contraseñas no coinciden.";
                    return;
                }

                _database.RegisterUser(txtUserName.Text, txtPassword.Text);
                AuthenticatedUser = txtUserName.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (_database.Authenticate(txtUserName.Text, txtPassword.Text))
            {
                AuthenticatedUser = txtUserName.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            _failedAttempts++;
            var remaining = 3 - _failedAttempts;
            if (remaining == 0)
            {
                MessageBox.Show("Se agotaron los 3 intentos. El programa se cerrará.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            lblMessage.Text = $"Usuario o contraseña incorrectos. Intentos restantes: {remaining}.";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo completar el acceso.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
