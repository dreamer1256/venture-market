namespace code.RegisterForms
{
    partial class Signup_InvestManager
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
            this.btn_Finish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBx_Company = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Finish
            // 
            this.btn_Finish.BackColor = System.Drawing.Color.Transparent;
            this.btn_Finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_Finish.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Finish.Location = new System.Drawing.Point(405, 399);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(186, 40);
            this.btn_Finish.TabIndex = 0;
            this.btn_Finish.Text = "Finish";
            this.btn_Finish.UseVisualStyleBackColor = false;
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(318, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select your \r\ncompany";
            // 
            // cmbBx_Company
            // 
            this.cmbBx_Company.FormattingEnabled = true;
            this.cmbBx_Company.Location = new System.Drawing.Point(413, 281);
            this.cmbBx_Company.Name = "cmbBx_Company";
            this.cmbBx_Company.Size = new System.Drawing.Size(248, 21);
            this.cmbBx_Company.TabIndex = 2;
            // 
            // Signup_InvestManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.BackgroundImage = global::code.Properties.Resources.LOGIN;
            this.ClientSize = new System.Drawing.Size(999, 602);
            this.Controls.Add(this.cmbBx_Company);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Finish);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Signup_InvestManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invest Manager Sign Up - Venture Market";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBx_Company;
    }
}