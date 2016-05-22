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
            this.btnTop_Signup = new System.Windows.Forms.Button();
            this.lbl_FrgtPsswrd = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.pnl_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Login
            // 
            this.pnl_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_Login.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Login.Controls.Add(this.btnTop_Signup);
            this.pnl_Login.Controls.Add(this.lbl_FrgtPsswrd);
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.txt_Password);
            this.pnl_Login.Controls.Add(this.txt_Username);
            this.pnl_Login.Controls.Add(this.lbl_Password);
            this.pnl_Login.Controls.Add(this.lbl_Username);
            this.pnl_Login.Location = new System.Drawing.Point(256, 157);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(485, 310);
            this.pnl_Login.TabIndex = 0;
            // 
            // btnTop_Signup
            // 
            this.btnTop_Signup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTop_Signup.BackColor = System.Drawing.Color.Transparent;
            this.btnTop_Signup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTop_Signup.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTop_Signup.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnTop_Signup.Location = new System.Drawing.Point(379, 19);
            this.btnTop_Signup.Name = "btnTop_Signup";
            this.btnTop_Signup.Size = new System.Drawing.Size(87, 27);
            this.btnTop_Signup.TabIndex = 1;
            this.btnTop_Signup.Text = "Sign Up";
            this.btnTop_Signup.UseVisualStyleBackColor = false;
            this.btnTop_Signup.Click += new System.EventHandler(this.btnTop_Signup_Click);
            // 
            // lbl_FrgtPsswrd
            // 
            this.lbl_FrgtPsswrd.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.lbl_FrgtPsswrd.AutoSize = true;
            this.lbl_FrgtPsswrd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_FrgtPsswrd.DisabledLinkColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_FrgtPsswrd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_FrgtPsswrd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_FrgtPsswrd.LinkColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_FrgtPsswrd.Location = new System.Drawing.Point(208, 179);
            this.lbl_FrgtPsswrd.Name = "lbl_FrgtPsswrd";
            this.lbl_FrgtPsswrd.Size = new System.Drawing.Size(230, 17);
            this.lbl_FrgtPsswrd.TabIndex = 5;
            this.lbl_FrgtPsswrd.TabStop = true;
            this.lbl_FrgtPsswrd.Text = "Forgot your username or password?";
            this.lbl_FrgtPsswrd.VisitedLinkColor = System.Drawing.Color.White;
            this.lbl_FrgtPsswrd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_FrgtPsswrd_LinkClicked);
            // 
            // btn_Login
            // 
            this.btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Login.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Login.Location = new System.Drawing.Point(135, 241);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(229, 38);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Password.HideSelection = false;
            this.txt_Password.Location = new System.Drawing.Point(187, 135);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(251, 25);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // txt_Username
            // 
            this.txt_Username.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Username.Location = new System.Drawing.Point(187, 89);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(251, 25);
            this.txt_Username.TabIndex = 2;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Password.Location = new System.Drawing.Point(60, 135);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(66, 17);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Password";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Username.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Username.Location = new System.Drawing.Point(60, 89);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(69, 17);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "Username";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.BackgroundImage = global::code.Properties.Resources.LOGIN;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(999, 602);
            this.Controls.Add(this.pnl_Login);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Venture Market";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Login;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Button btnTop_Signup;
        private System.Windows.Forms.LinkLabel lbl_FrgtPsswrd;
    }
}