namespace b_d_semana3;

partial class LoginForm
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitle = null!;
    private Label lblUserName = null!;
    private TextBox txtUserName = null!;
    private Label lblPassword = null!;
    private TextBox txtPassword = null!;
    private Label lblConfirmPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private Button btnSubmit = null!;
    private Label lblMessage = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblUserName = new Label();
        txtUserName = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new TextBox();
        btnSubmit = new Button();
        lblMessage = new Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(125, 31);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(404, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Crea el primer usuario del sistema";
        // 
        // lblUserName
        // 
        lblUserName.AutoSize = true;
        lblUserName.Location = new Point(41, 121);
        lblUserName.Name = "lblUserName";
        lblUserName.Size = new Size(59, 20);
        lblUserName.TabIndex = 1;
        lblUserName.Text = "Usuario";
        // 
        // txtUserName
        // 
        txtUserName.Location = new Point(206, 116);
        txtUserName.Margin = new Padding(3, 4, 3, 4);
        txtUserName.Name = "txtUserName";
        txtUserName.Size = new Size(308, 27);
        txtUserName.TabIndex = 2;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(17, 183);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(83, 20);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Contraseña";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(206, 180);
        txtPassword.Margin = new Padding(3, 4, 3, 4);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(308, 27);
        txtPassword.TabIndex = 4;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Location = new Point(12, 244);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(151, 20);
        lblConfirmPassword.TabIndex = 5;
        lblConfirmPassword.Text = "Confirmar contraseña";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Location = new Point(206, 244);
        txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Size = new Size(308, 27);
        txtConfirmPassword.TabIndex = 6;
        txtConfirmPassword.UseSystemPasswordChar = true;
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(249, 304);
        btnSubmit.Margin = new Padding(3, 4, 3, 4);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(171, 48);
        btnSubmit.TabIndex = 7;
        btnSubmit.Text = "Crear cuenta";
        btnSubmit.UseVisualStyleBackColor = true;
        // 
        // lblMessage
        // 
        lblMessage.ForeColor = Color.DarkRed;
        lblMessage.Location = new Point(41, 376);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(473, 56);
        lblMessage.TabIndex = 8;
        // 
        // LoginForm
        // 
        AcceptButton = btnSubmit;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(656, 467);
        Controls.Add(lblMessage);
        Controls.Add(btnSubmit);
        Controls.Add(txtConfirmPassword);
        Controls.Add(lblConfirmPassword);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUserName);
        Controls.Add(lblUserName);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Crear usuario inicial";
        ResumeLayout(false);
        PerformLayout();
    }
}
