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
            // Sigin_InvestManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.btn_Finish);
            this.Name = "Sigin_InvestManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invest Manager Sign Up - Venture Market";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Finish;
    }
}