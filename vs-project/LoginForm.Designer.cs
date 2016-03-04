namespace code
{
    partial class LoginForm
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
            this.pnl_Login = new System.Windows.Forms.Panel();
            this.lbl_FrgtPsswrd = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTop_Login = new System.Windows.Forms.Button();
            this.btnTop_Signup = new System.Windows.Forms.Button();
            this.pnl_Login.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Login
            // 
            this.pnl_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_Login.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Login.Controls.Add(this.lbl_FrgtPsswrd);
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.txt_Password);
            this.pnl_Login.Controls.Add(this.txt_Username);
            this.pnl_Login.Controls.Add(this.lbl_Password);
            this.pnl_Login.Controls.Add(this.lbl_Username);
            this.pnl_Login.Location = new System.Drawing.Point(103, 102);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(501, 287);
            this.pnl_Login.TabIndex = 0;
            // 
            // lbl_FrgtPsswrd
            // 
            this.lbl_FrgtPsswrd.ActiveLinkColor = System.Drawing.Color.Black;
            this.lbl_FrgtPsswrd.AutoSize = true;
            this.lbl_FrgtPsswrd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_FrgtPsswrd.LinkColor = System.Drawing.Color.Black;
            this.lbl_FrgtPsswrd.Location = new System.Drawing.Point(285, 244);
            this.lbl_FrgtPsswrd.Name = "lbl_FrgtPsswrd";
            this.lbl_FrgtPsswrd.Size = new System.Drawing.Size(175, 13);
            this.lbl_FrgtPsswrd.TabIndex = 5;
            this.lbl_FrgtPsswrd.TabStop = true;
            this.lbl_FrgtPsswrd.Text = "Forgot your username or password?";
            this.lbl_FrgtPsswrd.VisitedLinkColor = System.Drawing.Color.White;
            this.lbl_FrgtPsswrd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_FrgtPsswrd_LinkClicked);
            // 
            // btn_Login
            // 
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Login.Location = new System.Drawing.Point(158, 170);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(229, 38);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(158, 59);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(229, 20);
            this.txt_Password.TabIndex = 3;
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(158, 20);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(229, 20);
            this.txt_Username.TabIndex = 2;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(48, 62);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Password";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(48, 23);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(55, 13);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "Username";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnTop_Login, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTop_Signup, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(500, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(164, 33);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnTop_Login
            // 
            this.btnTop_Login.Enabled = false;
            this.btnTop_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTop_Login.Location = new System.Drawing.Point(3, 3);
            this.btnTop_Login.Name = "btnTop_Login";
            this.btnTop_Login.Size = new System.Drawing.Size(76, 27);
            this.btnTop_Login.TabIndex = 0;
            this.btnTop_Login.Text = "Login";
            this.btnTop_Login.UseVisualStyleBackColor = true;
            this.btnTop_Login.Click += new System.EventHandler(this.btnTop_Login_Click);
            // 
            // btnTop_Signup
            // 
            this.btnTop_Signup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTop_Signup.Location = new System.Drawing.Point(85, 3);
            this.btnTop_Signup.Name = "btnTop_Signup";
            this.btnTop_Signup.Size = new System.Drawing.Size(75, 27);
            this.btnTop_Signup.TabIndex = 1;
            this.btnTop_Signup.Text = "Sign Up";
            this.btnTop_Signup.UseVisualStyleBackColor = true;
            this.btnTop_Signup.Click += new System.EventHandler(this.btnTop_Signup_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnl_Login);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Venture Market";
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Login;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTop_Login;
        private System.Windows.Forms.Button btnTop_Signup;
        private System.Windows.Forms.LinkLabel lbl_FrgtPsswrd;
    }
}