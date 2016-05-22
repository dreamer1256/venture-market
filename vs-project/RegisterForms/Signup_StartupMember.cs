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

                isCEO = chckBx_IsCEO.Checked;

                if (isCEO && startup.ceoID == null)
                {
                    sm.Is_CEO = true;
                    ur.RoleID = (int)URoles.Role.StartupCEO;  // роль керівника стартапу
                    startup.ceoID = user.ID;
                }
                else
                {
                    sm.Is_CEO = false;
                    ur.RoleID = (int)URoles.Role.StartupMember; // роль учасника стартапу
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
                if (isCEO && startup.ceoID != null)
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
    }
}
