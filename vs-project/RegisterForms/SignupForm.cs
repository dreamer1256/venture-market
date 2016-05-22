using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.Net;

namespace code
{
    public partial class SignInForm : Form
    {
        private DataClasses1DataContext vmDB;
        private User user;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        bool isvalidemail;
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
            
            var usr = vmDB.Users.Where(u => u.Username.Equals(txt_Username.Text)).Select(u => u.Username);
            var mail = vmDB.Users.Where(u => u.Email.Equals(txt_Email.Text)).Select(u => u.Email);

            if(usr.Count() != 0)
            {
                logger.Info("This username already exists[{0}]", txt_Username.Text);
                MessageBox.Show("This username already exists [" + txt_Username.Text + "].\n"
                                    + "Please choose another username.");
            }
            else if(mail.Count() != 0)
            {
                logger.Info("This mail already exists[{0}]", txt_Email.Text);
                MessageBox.Show("This username already mail: [" + txt_Email.Text + "].\n");
            }
            else if(txt_Password.Text == "" || txt_Password.TextLength < 6)
            {
                MessageBox.Show("Password is too short.\nMinimum length is 6 symbols");
            }
            else if (txt_Password.Text != txt_PasswordConfirm.Text)
            {
                MessageBox.Show("The repeat password you typed does not match!");
            }
            else if (code.ValidateEmail.IsValidEmail(txt_Email.Text) == false)
            {
                MessageBox.Show("Email is not valid!");
            }
            else
            {
                user = new User();
                user.Username = txt_Username.Text;
                user.Password = txt_Password.Text;
                user.Email = txt_Email.Text;
                user.FName = txt_FName.Text;
                user.LName = txt_LName.Text;
                user.RegDate = DateTime.Now;
                user.LoggedDate = DateTime.Now;
                
                vmDB.Users.InsertOnSubmit(user);
                try
                {
                    vmDB.SubmitChanges();
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message);
                }

                var newUser = vmDB.Users.Single(u => u.Username.Equals(txt_Username.Text));
                UserLoginHistory uLogHist = new UserLoginHistory
                {
                    UserID = newUser.ID,
                    OS = (System.Environment.OSVersion.Platform + " " + System.Environment.OSVersion.Version).ToString(),
                    IP = (Dns.Resolve(Dns.GetHostName()).AddressList[0]).ToString(),
                    Domain = System.Environment.UserDomainName.ToString(),
                    LoggedDate = DateTime.Now
                };

                vmDB.UserLoginHistories.InsertOnSubmit(uLogHist);
                try
                {
                    vmDB.SubmitChanges();
                    pnl_Sign_Role.Show();
                    pnl_Sign1.Hide();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message);
                }
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
                RegisterForms.Signup_AngelInv s_ai = new RegisterForms.Signup_AngelInv(user);
                s_ai.Show();
                this.Hide();
            }
            else
            if (rdBttn_InvManager.Checked == true)
            {
                vmDB = new DataClasses1DataContext();
                RegisterForms.Signup_InvestManager s_im = new RegisterForms.Signup_InvestManager(user);                
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
                RegisterForms.Signup_CompanyMember s_cm = new RegisterForms.Signup_CompanyMember(user);
                
                s_cm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Error!");
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            isvalidemail = code.ValidateEmail.IsValidEmail(txt_Email.Text);
            if (isvalidemail == true)
            {
                lbl_isvalid_email.ForeColor = System.Drawing.Color.Green;
                lbl_isvalid_email.Text = "email is valid";
            } else if (isvalidemail == false)
            {
                lbl_isvalid_email.ForeColor = System.Drawing.Color.Red;
                lbl_isvalid_email.Text = "email is not valid";
            }
        }
    }
}
