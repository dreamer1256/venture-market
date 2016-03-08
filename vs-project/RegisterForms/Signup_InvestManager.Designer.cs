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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_GeoInterests = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Finish
            // 
            this.btn_Finish.Location = new System.Drawing.Point(304, 312);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(75, 52);
            this.btn_Finish.TabIndex = 0;
            this.btn_Finish.Text = "Finish";
            this.btn_Finish.UseVisualStyleBackColor = true;
            this.btn_Finish.Click += new System.EventHandler(this.btn_Finish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select your \r\ncompany";
            // 
            // cmbBx_Company
            // 
            this.cmbBx_Company.FormattingEnabled = true;
            this.cmbBx_Company.Location = new System.Drawing.Point(203, 146);
            this.cmbBx_Company.Name = "cmbBx_Company";
            this.cmbBx_Company.Size = new System.Drawing.Size(248, 21);
            this.cmbBx_Company.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type your\r\ngeo interest";
            // 
            // txt_GeoInterests
            // 
            this.txt_GeoInterests.Location = new System.Drawing.Point(203, 248);
            this.txt_GeoInterests.Name = "txt_GeoInterests";
            this.txt_GeoInterests.Size = new System.Drawing.Size(248, 20);
            this.txt_GeoInterests.TabIndex = 4;
            // 
            // Signup_InvestManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.txt_GeoInterests);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBx_Company);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Finish);
            this.Name = "Signup_InvestManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invest Manager Sign Up - Venture Market";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Finish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBx_Company;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_GeoInterests;
    }
}