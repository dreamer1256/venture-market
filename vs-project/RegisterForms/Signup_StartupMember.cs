using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code.RegisterForms
{
    public partial class Signup_StartupMember : Form
    {
        private DataClasses1DataContext vmDB;
        private int userID;
        private User user;
        public Signup_StartupMember(User user)
        {
            InitializeComponent();
            userID = user.ID;
            
            // Отримання наз стартапів, які вже є у системі
            vmDB = new DataClasses1DataContext();
            var ur = from u in vmDB.Startups
                     select u.Title;
            foreach (var s in ur)
                cmbBx_Startups.Items.Add(s);
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            vmDB = new DataClasses1DataContext();
            Startup_Member sm = new Startup_Member();
            User_Role ur = new User_Role();
            ur.UserId = userID;
            sm.UserID = userID;
            if (chckBx_IsCEO.Checked == true)
            {   sm.Is_CEO = true;
                ur.RoleID = (int)URoles.Role.StartupCEO;  // роль керівника стартапу
                vmDB.User_Roles.InsertOnSubmit(ur);
                UserProfile.StartupCEOMmbrProfile scpm = new UserProfile.StartupCEOMmbrProfile(user);
                scpm.Show();
            }
            else
            {
                sm.Is_CEO = false;
                ur.RoleID = (int)URoles.Role.StartupMember; // роль учасника стартапу
                UserProfile.StartupMmbrProfile smp = new UserProfile.StartupMmbrProfile(user);
                smp.Show();
            }

            // Присвоїти учаснику ID стартапу залежно від вибору в полі comboBox
            Startup startup = vmDB.Startups.Single(u => u.Title == cmbBx_Startups.Text);
            sm.StartupID = startup.ID;

            sm.Country = txt_Country.Text;
            sm.Address = txt_City.Text;
            sm.Phone = txt_Phone.Text;
            sm.Skype = txt_Skype.Text;
            sm.Twitter = txt_Twitter.Text;
            sm.About = rchTxtBx_About.Text;
            vmDB.Startup_Members.InsertOnSubmit(sm);
            vmDB.User_Roles.InsertOnSubmit(ur);
            vmDB.SubmitChanges();
            this.Hide();
        }

        private void Signup_StartupMember_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'venture_MarketDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.venture_MarketDataSet.Users);

        }
    }
}
