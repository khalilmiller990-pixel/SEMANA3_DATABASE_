namespace b_d_semana3;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblHeader = null!;
    private Label lblInstructions = null!;
    private FlowLayoutPanel flpTables = null!;
    private Button btnAuthors = null!;
    private Button btnDiscounts = null!;
    private Button btnEmployee = null!;
    private Button btnJobs = null!;
    private Button btnPubInfo = null!;
    private Button btnPublishers = null!;
    private Button btnRoySched = null!;
    private Button btnSales = null!;
    private Button btnStores = null!;
    private Button btnTitleAuthor = null!;
    private Button btnTitles = null!;

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
        components = new System.ComponentModel.Container();
        lblHeader = new Label();
        lblInstructions = new Label();
        flpTables = new FlowLayoutPanel();
        btnAuthors = new Button();
        btnDiscounts = new Button();
        btnEmployee = new Button();
        btnJobs = new Button();
        btnPubInfo = new Button();
        btnPublishers = new Button();
        btnRoySched = new Button();
        btnSales = new Button();
        btnStores = new Button();
        btnTitleAuthor = new Button();
        btnTitles = new Button();
        SuspendLayout();
        // 
        // lblHeader
        // 
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblHeader.Location = new Point(24, 22);
        lblHeader.Name = "lblHeader";
        lblHeader.Size = new Size(0, 30);
        lblHeader.TabIndex = 0;
        lblHeader.Text = "Base de datos pubs";
        // 
        // lblInstructions
        // 
        lblInstructions.AutoSize = true;
        lblInstructions.Location = new Point(27, 68);
        lblInstructions.Name = "lblInstructions";
        lblInstructions.Size = new Size(364, 15);
        lblInstructions.TabIndex = 1;
        lblInstructions.Text = "Selecciona una tabla para abrir su formulario de consulta y edición.";
        // 
        // flpTables
        // 
        flpTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        flpTables.AutoScroll = true;
        flpTables.Location = new Point(24, 104);
        flpTables.Name = "flpTables";
        flpTables.Padding = new Padding(8);
        flpTables.Size = new Size(832, 440);
        flpTables.TabIndex = 2;
        flpTables.WrapContents = true;
        // 
        // btnAuthors
        // 
        btnAuthors.Location = new Point(11, 11);
        btnAuthors.Margin = new Padding(8);
        btnAuthors.Name = "btnAuthors";
        btnAuthors.Size = new Size(225, 50);
        btnAuthors.TabIndex = 0;
        btnAuthors.Text = "dbo.authors";
        btnAuthors.UseVisualStyleBackColor = true;
        // 
        // btnDiscounts
        // 
        btnDiscounts.Location = new Point(252, 11);
        btnDiscounts.Margin = new Padding(8);
        btnDiscounts.Name = "btnDiscounts";
        btnDiscounts.Size = new Size(225, 50);
        btnDiscounts.TabIndex = 1;
        btnDiscounts.Text = "dbo.discounts";
        btnDiscounts.UseVisualStyleBackColor = true;
        // 
        // btnEmployee
        // 
        btnEmployee.Location = new Point(493, 11);
        btnEmployee.Margin = new Padding(8);
        btnEmployee.Name = "btnEmployee";
        btnEmployee.Size = new Size(225, 50);
        btnEmployee.TabIndex = 2;
        btnEmployee.Text = "dbo.employee";
        btnEmployee.UseVisualStyleBackColor = true;
        // 
        // btnJobs
        // 
        btnJobs.Location = new Point(11, 77);
        btnJobs.Margin = new Padding(8);
        btnJobs.Name = "btnJobs";
        btnJobs.Size = new Size(225, 50);
        btnJobs.TabIndex = 3;
        btnJobs.Text = "dbo.jobs";
        btnJobs.UseVisualStyleBackColor = true;
        // 
        // btnPubInfo
        // 
        btnPubInfo.Location = new Point(252, 77);
        btnPubInfo.Margin = new Padding(8);
        btnPubInfo.Name = "btnPubInfo";
        btnPubInfo.Size = new Size(225, 50);
        btnPubInfo.TabIndex = 4;
        btnPubInfo.Text = "dbo.pub_info";
        btnPubInfo.UseVisualStyleBackColor = true;
        // 
        // btnPublishers
        // 
        btnPublishers.Location = new Point(493, 77);
        btnPublishers.Margin = new Padding(8);
        btnPublishers.Name = "btnPublishers";
        btnPublishers.Size = new Size(225, 50);
        btnPublishers.TabIndex = 5;
        btnPublishers.Text = "dbo.publishers";
        btnPublishers.UseVisualStyleBackColor = true;
        // 
        // btnRoySched
        // 
        btnRoySched.Location = new Point(11, 143);
        btnRoySched.Margin = new Padding(8);
        btnRoySched.Name = "btnRoySched";
        btnRoySched.Size = new Size(225, 50);
        btnRoySched.TabIndex = 6;
        btnRoySched.Text = "dbo.roysched";
        btnRoySched.UseVisualStyleBackColor = true;
        // 
        // btnSales
        // 
        btnSales.Location = new Point(252, 143);
        btnSales.Margin = new Padding(8);
        btnSales.Name = "btnSales";
        btnSales.Size = new Size(225, 50);
        btnSales.TabIndex = 7;
        btnSales.Text = "dbo.sales";
        btnSales.UseVisualStyleBackColor = true;
        // 
        // btnStores
        // 
        btnStores.Location = new Point(493, 143);
        btnStores.Margin = new Padding(8);
        btnStores.Name = "btnStores";
        btnStores.Size = new Size(225, 50);
        btnStores.TabIndex = 8;
        btnStores.Text = "dbo.stores";
        btnStores.UseVisualStyleBackColor = true;
        // 
        // btnTitleAuthor
        // 
        btnTitleAuthor.Location = new Point(11, 209);
        btnTitleAuthor.Margin = new Padding(8);
        btnTitleAuthor.Name = "btnTitleAuthor";
        btnTitleAuthor.Size = new Size(225, 50);
        btnTitleAuthor.TabIndex = 9;
        btnTitleAuthor.Text = "dbo.titleauthor";
        btnTitleAuthor.UseVisualStyleBackColor = true;
        // 
        // btnTitles
        // 
        btnTitles.Location = new Point(252, 209);
        btnTitles.Margin = new Padding(8);
        btnTitles.Name = "btnTitles";
        btnTitles.Size = new Size(225, 50);
        btnTitles.TabIndex = 10;
        btnTitles.Text = "dbo.titles";
        btnTitles.UseVisualStyleBackColor = true;
        flpTables.Controls.Add(btnAuthors);
        flpTables.Controls.Add(btnDiscounts);
        flpTables.Controls.Add(btnEmployee);
        flpTables.Controls.Add(btnJobs);
        flpTables.Controls.Add(btnPubInfo);
        flpTables.Controls.Add(btnPublishers);
        flpTables.Controls.Add(btnRoySched);
        flpTables.Controls.Add(btnSales);
        flpTables.Controls.Add(btnStores);
        flpTables.Controls.Add(btnTitleAuthor);
        flpTables.Controls.Add(btnTitles);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(880, 570);
        Controls.Add(flpTables);
        Controls.Add(lblInstructions);
        Controls.Add(lblHeader);
        MinimumSize = new Size(620, 420);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sistema de gestión - pubs";
        ResumeLayout(false);
        PerformLayout();
    }
}
