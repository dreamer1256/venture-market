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

namespace code.RegisterForms
{
    public partial class Signup_StartupMember : Form
    {
        private DataClasses1DataContext vmDB;
        private User user;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        bool isCEO = false;
        bool startuphaveceo = false;

        public Signup_StartupMember(User user)
        {
            InitializeComponent();
            AcceptButton = btn_Finish;
            this.user = user;
            label2.Visible = false;
            
            // Отримання наз стартапів, які вже є у системі
            vmDB = new DataClasses1DataContext();
        
            var st = vmDB.Startups.Select(s => s.Title);
            foreach (var s in st)
                cmbBx_Startups.Items.Add(s);
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbBx_Startups.Text != "")
            {
                label2.Visible = false;
                vmDB = new DataClasses1DataContext();
                Startup_Member sm = new Startup_Member();
                User_Role ur = new User_Role();
                ur.UserId = user.ID;
                sm.UserID = user.ID;
                Startup startup = vmDB.Startups.Single(u => u.Title == cmbBx_Startups.Text);

                if (startuphaveceo == false && chckBx_IsCEO.Checked == true)
                {
                    ur.RoleID = (int)URoles.Role.StartupCEO;  // роль керівника стартапу
                    sm.Is_CEO = true;
                }
                else
                {
                    ur.RoleID = (int)URoles.Role.StartupMember; // роль учасника стартапу
                    sm.Is_CEO = false;
                }

                // Присвоїти учаснику ID стартапу залежно від вибору в полі comboBox
                sm.StartupID = startup.ID;

                sm.Address = txt_City.Text;
                sm.Phone = txt_Phone.Text;
                sm.Skype = txt_Skype.Text;
                sm.Twitter = txt_Twitter.Text;
                sm.About = rchTxtBx_About.Text;
                vmDB.Startup_Members.InsertOnSubmit(sm);
                vmDB.User_Roles.InsertOnSubmit(ur);
                if (startuphaveceo == true)
                {
                    MessageBox.Show("You can\'t be the CEO of the choosen startup.\nThere is a startup CEO!");
                }
                else
                    try
                    {
                        vmDB.SubmitChanges();

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        MessageBox.Show(ex.Message);
                    }
                UserProfile.StartupCEOMmbrProfile scpm = new UserProfile.StartupCEOMmbrProfile(user);
                scpm.Show();
                this.Hide();
            }
            else
            {
                label2.Visible = true;
                label1.ForeColor = Color.Red;
            }
        }

        private void Signup_StartupMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            User deleteuser = vmDB.Users.Single(u => u.ID == user.ID);
            vmDB.Users.DeleteOnSubmit(deleteuser);
            try
            {
                vmDB.SubmitChanges();
                logger.Info("User " + user.Username + " was deleted from system");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error(ex.Message);
            }
        }

        private void chckBx_IsCEO_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbBx_Startups.Text == "")
            {
                lbl_chbx_is.ForeColor = System.Drawing.Color.Red;
                lbl_chbx_is.Text = "first select a startup";
                chckBx_IsCEO.Checked = false;
            }
            else if (cmbBx_Startups.Text != "")
            {
                Startup ISstartup = vmDB.Startups.Single(u => u.Title == cmbBx_Startups.Text);
                var haveceo = from s in vmDB.Startup_Members
                              where s.StartupID == ISstartup.ID
                              select s;
                foreach (var k in haveceo)
                {
                    if (k.Is_CEO == true)
                    {
                        bool startuphaveceo = true;
                        lbl_chbx_is.ForeColor = System.Drawing.Color.Red;
                        lbl_chbx_is.Text = "startup already has CEO";
                        chckBx_IsCEO.Checked = false;
                        break;
                    }
                }
            }
            else
            {
                bool startuphaveceo = false;
                lbl_chbx_is.ForeColor = System.Drawing.Color.Green;
                lbl_chbx_is.Text = "All OK";
            }
        }

        private void cmbBx_Startups_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_chbx_is.Text = "";
        }
    }
}
