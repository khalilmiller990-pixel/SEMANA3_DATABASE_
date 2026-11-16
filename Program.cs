namespace b_d_semana3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var database = new DatabaseService();
            try
            {
                database.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a SQL Server o preparar el acceso a la base pubs.\n{ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var login = new LoginForm(database);
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(database, login.AuthenticatedUser));
            }
        }
    }
}