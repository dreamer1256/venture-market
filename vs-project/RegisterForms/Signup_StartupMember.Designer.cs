namespace code.RegisterForms
{
    partial class Signup_StartupMember
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbBx_Startups = new System.Windows.Forms.ComboBox();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.rchTxtBx_About = new System.Windows.Forms.RichTextBox();
            this.txt_Twitter = new System.Windows.Forms.TextBox();
            this.txt_Skype = new System.Windows.Forms.TextBox();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.chckBx_IsCEO = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.venture_MarketDataSet = new code.Venture_MarketDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new code.Venture_MarketDataSetTableAdapters.UsersTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venture_MarketDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Startup";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cmbBx_Startups);
            this.panel1.Controls.Add(this.btn_Finish);
            this.panel1.Controls.Add(this.rchTxtBx_About);
            this.panel1.Controls.Add(this.txt_Twitter);
            this.panel1.Controls.Add(this.txt_Skype);
            this.panel1.Controls.Add(this.txt_Phone);
            this.panel1.Controls.Add(this.txt_City);
            this.panel1.Controls.Add(this.chckBx_IsCEO);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(257, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 306);
            this.panel1.TabIndex = 2;
            // 
            // cmbBx_Startups
            // 
            this.cmbBx_Startups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBx_Startups.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.cmbBx_Startups.FormattingEnabled = true;
            this.cmbBx_Startups.Location = new System.Drawing.Point(115, 27);
            this.cmbBx_Startups.Name = "cmbBx_Startups";
            this.cmbBx_Startups.Size = new System.Drawing.Size(134, 25);
            this.cmbBx_Startups.TabIndex = 1;
            // 
            // btn_Finish
            // 
            this.btn_Finish.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btn_Finish.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Finish.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Finish.Location = new System.Drawing.Point(209, 257);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(75, 38);
            this.btn_Finish.TabIndex = 9;
            this.btn_Finish.Text = "Finish";
            this.btn_Finish.UseVisualStyleBackColor = true;
            this.btn_Finish.Click += new System.EventHandler(this.button1_Click);
            // 
            // rchTxtBx_About
            // 
            this.rchTxtBx_About.Location = new System.Drawing.Point(114, 177);
            this.rchTxtBx_About.Name = "rchTxtBx_About";
            this.rchTxtBx_About.Size = new System.Drawing.Size(350, 63);
            this.rchTxtBx_About.TabIndex = 8;
            this.rchTxtBx_About.Text = "";
            // 
            // txt_Twitter
            // 
            this.txt_Twitter.Location = new System.Drawing.Point(329, 124);
            this.txt_Twitter.Name = "txt_Twitter";
            this.txt_Twitter.Size = new System.Drawing.Size(135, 25);
            this.txt_Twitter.TabIndex = 7;
            // 
            // txt_Skype
            // 
            this.txt_Skype.Location = new System.Drawing.Point(329, 80);
            this.txt_Skype.Name = "txt_Skype";
            this.txt_Skype.Size = new System.Drawing.Size(135, 25);
            this.txt_Skype.TabIndex = 6;
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(114, 124);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(135, 25);
            this.txt_Phone.TabIndex = 4;
            // 
            // txt_City
            // 
            this.txt_City.Location = new System.Drawing.Point(115, 80);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(135, 25);
            this.txt_City.TabIndex = 3;
            // 
            // chckBx_IsCEO
            // 
            this.chckBx_IsCEO.AutoSize = true;
            this.chckBx_IsCEO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chckBx_IsCEO.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chckBx_IsCEO.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chckBx_IsCEO.Location = new System.Drawing.Point(418, 28);
            this.chckBx_IsCEO.Name = "chckBx_IsCEO";
            this.chckBx_IsCEO.Size = new System.Drawing.Size(48, 21);
            this.chckBx_IsCEO.TabIndex = 5;
            this.chckBx_IsCEO.Text = "Yes";
            this.chckBx_IsCEO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chckBx_IsCEO.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Are you CEO?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "About ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Twitter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Skype";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Location";
            // 
            // venture_MarketDataSet
            // 
            this.venture_MarketDataSet.DataSetName = "Venture_MarketDataSet";
            this.venture_MarketDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.venture_MarketDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // Signup_StartupMember
            // 
            this.AcceptButton = this.btn_Finish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.BackgroundImage = global::code.Properties.Resources.LOGIN;
            this.ClientSize = new System.Drawing.Size(999, 602);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Signup_StartupMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup Member Sign Up - Venture Market";
            this.Load += new System.EventHandler(this.Signup_StartupMember_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.venture_MarketDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rchTxtBx_About;
        private System.Windows.Forms.TextBox txt_Twitter;
        private System.Windows.Forms.TextBox txt_Skype;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.CheckBox chckBx_IsCEO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.ComboBox cmbBx_Startups;
        private Venture_MarketDataSet venture_MarketDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private Venture_MarketDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
    }
}