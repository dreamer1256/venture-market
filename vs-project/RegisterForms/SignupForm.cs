using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code
{
    public partial class SignInForm : Form
    {
        private DataClasses1DataContext vmDB;
        private User user;

        private RadioButton radioBtn = new RadioButton();
        public SignInForm()
        {
            InitializeComponent();
            rdBttn_AngelInvestor.Checked = true;
            rdBttn_InvManager.Checked = false;
            rdBttn_Startuper.Checked = false;
            rdBttn_CompanyMemeber.Checked = false;

        }
        
        private void btnTop_Login_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
            
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            vmDB = new DataClasses1DataContext();
            var qry = from u in vmDB.Users
                      where u.Username.Equals(txt_Username)
                      select u;
       
            if(qry.Count() == 0)
            {
                user = new User();
                user.Username = txt_Username.Text;
                user.Password = txt_Password.Text;
                user.Email = txt_Email.Text;
                user.FName = txt_FName.Text;
                user.LName = txt_LName.Text;
                vmDB.Users.InsertOnSubmit(user);
                vmDB.SubmitChanges();
                pnl_Sign_Role.Show();
                pnl_Sign1.Hide();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_BackToSign1_Click(object sender, EventArgs e)
        {
            pnl_Sign_Role.Hide();
            pnl_Sign1.Show();
        }
        
        private void btn_NextToSpec_Click(object sender, EventArgs e)
        {
            if (rdBttn_AngelInvestor.Checked == true)
            {
                vmDB = new DataClasses1DataContext();
                RegisterForms.Signup_AngelInv s_ai = new RegisterForms.Signup_AngelInv();
                s_ai.Show();
                this.Hide();

            }
            else
            if (rdBttn_InvManager.Checked == true)
            {
                vmDB = new DataClasses1DataContext();
                RegisterForms.Signup_InvestManager s_im = new RegisterForms.Signup_InvestManager();                
                s_im.Show();
                this.Hide();
            }
            else
            if (rdBttn_Startuper.Checked == true)
            {
                vmDB = new DataClasses1DataContext();
                RegisterForms.Signup_StartupMember s_sm = new RegisterForms.Signup_StartupMember(user);
                s_sm.Show();
                this.Hide();
            }
            else
            if (rdBttn_CompanyMemeber.Checked == true)
            {
                vmDB = new DataClasses1DataContext();
                RegisterForms.Signup_CompanyMember s_cm = new RegisterForms.Signup_CompanyMember();
                
                s_cm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Error!");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
    }
}
