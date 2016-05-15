namespace code.UserProfile
{
    partial class AdminProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPg_Detailed = new System.Windows.Forms.TabPage();
            this.tabPg_Actions = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_AddInvestCompany = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_AddStartup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AddAngelIv = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RemoveIncubator = new System.Windows.Forms.Button();
            this.btn_AddIncubator = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Startup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manager = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Application_round = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Foundation_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total_Investment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Marketing_Strategy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Competitors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Business_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_startup = new System.Windows.Forms.Panel();
            this.btm_Back = new System.Windows.Forms.Button();
            this.pnl_User = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoggedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_main = new System.Windows.Forms.Panel();
            this.btm_show_startup = new System.Windows.Forms.Button();
            this.btm_show_user = new System.Windows.Forms.Button();
            this.btm_Invest_Company = new System.Windows.Forms.Button();
            this.pnl_inv_company = new System.Windows.Forms.Panel();
            this.listView3 = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Website = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Found_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Office_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CEO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPg_Detailed.SuspendLayout();
            this.tabPg_Actions.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnl_startup.SuspendLayout();
            this.pnl_User.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.pnl_inv_company.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPg_Detailed);
            this.tabControl1.Controls.Add(this.tabPg_Actions);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1044, 556);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 7;
            // 
            // tabPg_Detailed
            // 
            this.tabPg_Detailed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.tabPg_Detailed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPg_Detailed.Controls.Add(this.pnl_main);
            this.tabPg_Detailed.Controls.Add(this.pnl_startup);
            this.tabPg_Detailed.Controls.Add(this.pnl_inv_company);
            this.tabPg_Detailed.Controls.Add(this.pnl_User);
            this.tabPg_Detailed.Controls.Add(this.btm_Back);
            this.tabPg_Detailed.Location = new System.Drawing.Point(4, 34);
            this.tabPg_Detailed.Name = "tabPg_Detailed";
            this.tabPg_Detailed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg_Detailed.Size = new System.Drawing.Size(1036, 518);
            this.tabPg_Detailed.TabIndex = 0;
            this.tabPg_Detailed.Text = "Detailed Info";
            // 
            // tabPg_Actions
            // 
            this.tabPg_Actions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.tabPg_Actions.Controls.Add(this.panel4);
            this.tabPg_Actions.Controls.Add(this.panel3);
            this.tabPg_Actions.Controls.Add(this.panel2);
            this.tabPg_Actions.Controls.Add(this.panel1);
            this.tabPg_Actions.Location = new System.Drawing.Point(4, 34);
            this.tabPg_Actions.Name = "tabPg_Actions";
            this.tabPg_Actions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg_Actions.Size = new System.Drawing.Size(1036, 518);
            this.tabPg_Actions.TabIndex = 1;
            this.tabPg_Actions.Text = "Actions";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(73)))), ((int)(((byte)(171)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btn_AddInvestCompany);
            this.panel4.Location = new System.Drawing.Point(0, 190);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 181);
            this.panel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Investment Company";
            // 
            // btn_AddInvestCompany
            // 
            this.btn_AddInvestCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddInvestCompany.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddInvestCompany.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddInvestCompany.Location = new System.Drawing.Point(30, 70);
            this.btn_AddInvestCompany.Name = "btn_AddInvestCompany";
            this.btn_AddInvestCompany.Size = new System.Drawing.Size(178, 78);
            this.btn_AddInvestCompany.TabIndex = 0;
            this.btn_AddInvestCompany.Text = "Add";
            this.btn_AddInvestCompany.UseVisualStyleBackColor = true;
            this.btn_AddInvestCompany.Click += new System.EventHandler(this.btn_AddInvestCompany_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(69)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_AddStartup);
            this.panel3.Location = new System.Drawing.Point(521, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 181);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Startups";
            // 
            // btn_AddStartup
            // 
            this.btn_AddStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddStartup.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddStartup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddStartup.Location = new System.Drawing.Point(32, 74);
            this.btn_AddStartup.Name = "btn_AddStartup";
            this.btn_AddStartup.Size = new System.Drawing.Size(178, 78);
            this.btn_AddStartup.TabIndex = 0;
            this.btn_AddStartup.Text = "Add";
            this.btn_AddStartup.UseVisualStyleBackColor = true;
            this.btn_AddStartup.Click += new System.EventHandler(this.btn_AddStartup_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(45)))), ((int)(((byte)(124)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_AddAngelIv);
            this.panel2.Location = new System.Drawing.Point(522, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 181);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Angel Investors";
            // 
            // btn_AddAngelIv
            // 
            this.btn_AddAngelIv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAngelIv.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddAngelIv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddAngelIv.Location = new System.Drawing.Point(30, 70);
            this.btn_AddAngelIv.Name = "btn_AddAngelIv";
            this.btn_AddAngelIv.Size = new System.Drawing.Size(178, 78);
            this.btn_AddAngelIv.TabIndex = 0;
            this.btn_AddAngelIv.Text = "Add";
            this.btn_AddAngelIv.UseVisualStyleBackColor = true;
            this.btn_AddAngelIv.Click += new System.EventHandler(this.btn_AddAngelIv_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(115)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_RemoveIncubator);
            this.panel1.Controls.Add(this.btn_AddIncubator);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 181);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Business Incubators";
            // 
            // btn_RemoveIncubator
            // 
            this.btn_RemoveIncubator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveIncubator.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_RemoveIncubator.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_RemoveIncubator.Location = new System.Drawing.Point(288, 74);
            this.btn_RemoveIncubator.Name = "btn_RemoveIncubator";
            this.btn_RemoveIncubator.Size = new System.Drawing.Size(178, 78);
            this.btn_RemoveIncubator.TabIndex = 1;
            this.btn_RemoveIncubator.Text = "Remove";
            this.btn_RemoveIncubator.UseVisualStyleBackColor = true;
            this.btn_RemoveIncubator.Click += new System.EventHandler(this.btn_RemoveIncubator_Click);
            // 
            // btn_AddIncubator
            // 
            this.btn_AddIncubator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddIncubator.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddIncubator.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddIncubator.Location = new System.Drawing.Point(30, 74);
            this.btn_AddIncubator.Name = "btn_AddIncubator";
            this.btn_AddIncubator.Size = new System.Drawing.Size(178, 78);
            this.btn_AddIncubator.TabIndex = 0;
            this.btn_AddIncubator.Text = "Add";
            this.btn_AddIncubator.UseVisualStyleBackColor = true;
            this.btn_AddIncubator.Click += new System.EventHandler(this.btn_AddIncubator_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1044, 4);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.panel5.Controls.Add(this.btn_Logout);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1044, 40);
            this.panel5.TabIndex = 10;
            // 
            // btn_Logout
            // 
            this.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Logout.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Logout.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Logout.Location = new System.Drawing.Point(958, 5);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(72, 29);
            this.btn_Logout.TabIndex = 0;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Startup,
            this.Manager,
            this.State,
            this.Application_round,
            this.Marketing_Strategy,
            this.Competitors,
            this.Business_Model,
            this.Total_Investment,
            this.Foundation_Date});
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(14, 11);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(992, 405);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // Startup
            // 
            this.Startup.Text = "Startup";
            this.Startup.Width = 102;
            // 
            // Manager
            // 
            this.Manager.Text = "Manager";
            this.Manager.Width = 96;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 104;
            // 
            // Application_round
            // 
            this.Application_round.Text = "Application round";
            this.Application_round.Width = 117;
            // 
            // Foundation_Date
            // 
            this.Foundation_Date.Text = "Foundation Date";
            this.Foundation_Date.Width = 134;
            // 
            // Total_Investment
            // 
            this.Total_Investment.Text = "Total Investment";
            this.Total_Investment.Width = 113;
            // 
            // Marketing_Strategy
            // 
            this.Marketing_Strategy.Text = "Marketing Strategy";
            this.Marketing_Strategy.Width = 126;
            // 
            // Competitors
            // 
            this.Competitors.Text = "Competitors";
            this.Competitors.Width = 85;
            // 
            // Business_Model
            // 
            this.Business_Model.Text = "Business Model";
            this.Business_Model.Width = 109;
            // 
            // pnl_startup
            // 
            this.pnl_startup.BackColor = System.Drawing.Color.Transparent;
            this.pnl_startup.Controls.Add(this.listView2);
            this.pnl_startup.Location = new System.Drawing.Point(0, 25);
            this.pnl_startup.Name = "pnl_startup";
            this.pnl_startup.Size = new System.Drawing.Size(1020, 429);
            this.pnl_startup.TabIndex = 4;
            // 
            // btm_Back
            // 
            this.btm_Back.BackColor = System.Drawing.Color.Transparent;
            this.btm_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btm_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btm_Back.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btm_Back.Location = new System.Drawing.Point(861, 479);
            this.btm_Back.Name = "btm_Back";
            this.btm_Back.Size = new System.Drawing.Size(155, 25);
            this.btm_Back.TabIndex = 6;
            this.btm_Back.Text = "Back";
            this.btm_Back.UseVisualStyleBackColor = false;
            this.btm_Back.Click += new System.EventHandler(this.btm_Back_Click);
            // 
            // pnl_User
            // 
            this.pnl_User.BackColor = System.Drawing.Color.Transparent;
            this.pnl_User.Controls.Add(this.listView1);
            this.pnl_User.Location = new System.Drawing.Point(3, 30);
            this.pnl_User.Name = "pnl_User";
            this.pnl_User.Size = new System.Drawing.Size(1030, 434);
            this.pnl_User.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Username,
            this.Email,
            this.Password,
            this.RegDate,
            this.LoggedDate});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(14, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(992, 405);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 102;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 96;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 104;
            // 
            // RegDate
            // 
            this.RegDate.Text = "RegDate";
            this.RegDate.Width = 117;
            // 
            // LoggedDate
            // 
            this.LoggedDate.Text = "LoggedDate";
            this.LoggedDate.Width = 126;
            // 
            // pnl_main
            // 
            this.pnl_main.BackColor = System.Drawing.Color.Transparent;
            this.pnl_main.Controls.Add(this.btm_Invest_Company);
            this.pnl_main.Controls.Add(this.btm_show_user);
            this.pnl_main.Controls.Add(this.btm_show_startup);
            this.pnl_main.Location = new System.Drawing.Point(3, 17);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1020, 447);
            this.pnl_main.TabIndex = 8;
            // 
            // btm_show_startup
            // 
            this.btm_show_startup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btm_show_startup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btm_show_startup.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btm_show_startup.Location = new System.Drawing.Point(54, 39);
            this.btm_show_startup.Name = "btm_show_startup";
            this.btm_show_startup.Size = new System.Drawing.Size(155, 25);
            this.btm_show_startup.TabIndex = 6;
            this.btm_show_startup.Text = "Show Startup";
            this.btm_show_startup.UseVisualStyleBackColor = true;
            this.btm_show_startup.Click += new System.EventHandler(this.btm_show_startup_Click);
            // 
            // btm_show_user
            // 
            this.btm_show_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btm_show_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btm_show_user.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btm_show_user.Location = new System.Drawing.Point(54, 81);
            this.btm_show_user.Name = "btm_show_user";
            this.btm_show_user.Size = new System.Drawing.Size(155, 25);
            this.btm_show_user.TabIndex = 7;
            this.btm_show_user.Text = "Show User";
            this.btm_show_user.UseVisualStyleBackColor = true;
            this.btm_show_user.Click += new System.EventHandler(this.btm_show_user_Click);
            // 
            // btm_Invest_Company
            // 
            this.btm_Invest_Company.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btm_Invest_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btm_Invest_Company.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btm_Invest_Company.Location = new System.Drawing.Point(54, 121);
            this.btm_Invest_Company.Name = "btm_Invest_Company";
            this.btm_Invest_Company.Size = new System.Drawing.Size(155, 25);
            this.btm_Invest_Company.TabIndex = 8;
            this.btm_Invest_Company.Text = "Show Invest Company";
            this.btm_Invest_Company.UseVisualStyleBackColor = true;
            this.btm_Invest_Company.Click += new System.EventHandler(this.btm_Invest_Company_Click);
            // 
            // pnl_inv_company
            // 
            this.pnl_inv_company.BackColor = System.Drawing.Color.Transparent;
            this.pnl_inv_company.Controls.Add(this.listView3);
            this.pnl_inv_company.Location = new System.Drawing.Point(0, 26);
            this.pnl_inv_company.Name = "pnl_inv_company";
            this.pnl_inv_company.Size = new System.Drawing.Size(1020, 431);
            this.pnl_inv_company.TabIndex = 8;
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Description,
            this.Website,
            this.Found_Date,
            this.Office_Address,
            this.CEO});
            this.listView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView3.GridLines = true;
            this.listView3.Location = new System.Drawing.Point(14, 13);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(992, 405);
            this.listView3.TabIndex = 4;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 102;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 326;
            // 
            // Website
            // 
            this.Website.Text = "Website";
            this.Website.Width = 104;
            // 
            // Found_Date
            // 
            this.Found_Date.Text = "Foundation Date";
            this.Found_Date.Width = 163;
            // 
            // Office_Address
            // 
            this.Office_Address.Text = "Office Address";
            this.Office_Address.Width = 135;
            // 
            // CEO
            // 
            this.CEO.Text = "CEO";
            this.CEO.Width = 389;
            // 
            // AdminProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1044, 603);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Profile - Venture Market";
            this.tabControl1.ResumeLayout(false);
            this.tabPg_Detailed.ResumeLayout(false);
            this.tabPg_Actions.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.pnl_startup.ResumeLayout(false);
            this.pnl_User.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.pnl_inv_company.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPg_Detailed;
        private System.Windows.Forms.TabPage tabPg_Actions;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RemoveIncubator;
        private System.Windows.Forms.Button btn_AddIncubator;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_AddInvestCompany;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_AddStartup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddAngelIv;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Panel pnl_startup;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader Startup;
        private System.Windows.Forms.ColumnHeader Manager;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Application_round;
        private System.Windows.Forms.ColumnHeader Marketing_Strategy;
        private System.Windows.Forms.ColumnHeader Competitors;
        private System.Windows.Forms.ColumnHeader Business_Model;
        private System.Windows.Forms.ColumnHeader Total_Investment;
        private System.Windows.Forms.ColumnHeader Foundation_Date;
        private System.Windows.Forms.Button btm_Back;
        private System.Windows.Forms.Panel pnl_User;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader RegDate;
        private System.Windows.Forms.ColumnHeader LoggedDate;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Button btm_show_user;
        private System.Windows.Forms.Button btm_show_startup;
        private System.Windows.Forms.Panel pnl_inv_company;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Website;
        private System.Windows.Forms.ColumnHeader Found_Date;
        private System.Windows.Forms.ColumnHeader Office_Address;
        private System.Windows.Forms.ColumnHeader CEO;
        private System.Windows.Forms.Button btm_Invest_Company;
    }
}