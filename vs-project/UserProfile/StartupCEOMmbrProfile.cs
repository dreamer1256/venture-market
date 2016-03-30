using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code.UserProfile
{
    public partial class StartupCEOMmbrProfile : Form
    {
        /// <summary>
        /// Клас StartupCEOMmbrProfile
        /// форма профілю користувача - керівника стартапом
        /// </summary>
        User user = null;
        Startup_Member startupCEO = null;
        DataClasses1DataContext vmDB;
        string incubatorTitle = null;
        /// <summary>
        /// Витягується основна інформація про користувача
        /// </summary>
        /// <param name="user">Поточний користувач</param>
        public StartupCEOMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;
            vmDB = new DataClasses1DataContext();
            
            // Інформація про користувача.
            startupCEO = vmDB.Startup_Members.Single(u => u.UserID == user.ID);
            
            lbl_Name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_Country.Text = string.Format("Country: {0}", startupCEO.Country);
            lbl_City.Text = string.Format("City: {0}", startupCEO.Address);
            lbl_Phone.Text = string.Format("Phone: {0}", startupCEO.Phone);
            lbl_Email.Text = string.Format("Email: {0}", user.Email);
            lbl_Skype.Text = string.Format("Skype: {0}", startupCEO.Skype);
            lbl_Twitter.Text = string.Format("Twitter: {0}", startupCEO.Twitter);
            //lbl_Facebook.Text = string.Format("Facebook:\t{0}", ceo.Facebook);
            //lbl_Website.Text = string.Format("Website:\t{0}", ceo.Website);
            rchTxtBx_About.Text = startupCEO.About;

            pnl_Incubators.Hide();
            lbl_StartupsInIncubator.Hide();
            lbl_StartupsInIncubList.Hide();
            btn_Join.Hide();
            lbl_JoinError.Hide();

            // Вивести бізнес інкубатори та інформацію про них
            // в ListView
            var incubators = vmDB.Business_Incubators.Select(inc => inc);
            ListViewItem lvi;
            listView1.FullRowSelect = true;
            listView1.GridLines = false;

            listView1.Columns.Add("Title", 120);
            listView1.Columns.Add("Location", 180);
            listView1.Columns.Add("Number Of Seats", 150);

            string[] arr = new string[3];
            foreach (var s in incubators)
            {
                arr[0] = s.Title;
                arr[1] = s.Address;
                arr[2] = s.Number_Of_Seats.ToString();
                lvi = new ListViewItem(arr);
                listView1.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Метод відкриває профіль користувача при кліку на кнопку My Profile
        /// </summary>
        private void btn_LinkToProfile_Click(object sender, EventArgs e)
        {
            pnl_Profile.Show();
            pnl_Incubators.Hide();
            lbl_StartupsInIncubator.Hide();
            lbl_StartupsInIncubList.Hide();
            btn_Join.Hide();
            lbl_JoinError.Hide();
        }

        /// <summary>
        /// Метод відкриває панель зі списком інкубаторів
        /// </summary>
        private void btn_LinkToIncubators_Click(object sender, EventArgs e)
        {
            pnl_Profile.Hide();
            pnl_Incubators.Show();
        }

        /// <summary>
        /// Метод виводить детальну інформацію про вибраний у ListView бізнес інкубатор
        /// при кліку по стрічці зі списку інкубаторів
        /// </summary>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            incubatorTitle = null;

            if (listView1.SelectedIndices.Count <= 0)
                return;
            if (listView1.SelectedIndices.Count > 0)
            {
                lbl_StartupsInIncubList.Text = null;
                incubatorTitle = listView1.SelectedItems[0].Text;

                // Вивести стартапи, які вже розташовані у вибраному інкубаторі
                lbl_StartupsInIncubator.Text = 
                    string.Format("In the {0} incubator are already working: ", incubatorTitle);
                var incubator = vmDB.Business_Incubators.Single(i => incubatorTitle.Equals(i.Title));
                var startups = vmDB.Startups.Where(s => s.IncubatorID == incubator.ID);
                foreach (var s in startups)
                    lbl_StartupsInIncubList.Text += "\n" + s.Title;
                
                // Перевірити, чи розташований стартап у інкубаторі.
                // Якщо так - вивести повідомлення про це.
                // В іншому випадку - показати кнопку Join Incubator
                if (startupCEO.Startup.IncubatorID != null)
                {
                    btn_Join.Hide();
                    ShowJoinErrorMessage();
                }
                else
                {
                    btn_Join.Text = "Join " + incubatorTitle;
                    btn_Join.Show();
                }
                
                lbl_StartupsInIncubator.Show();
                lbl_StartupsInIncubList.Show();
            }
        }

        /// <summary>
        /// Метод, при кліку по кнопці Join Incubator,
        /// розташовує стартап у вибраному інкубаторі
        /// </summary>
        private void btn_Join_Click(object sender, EventArgs e)
        {
            int incubatorID = vmDB.Business_Incubators.Single(i => i.Title.Equals(incubatorTitle)).ID;
            var strtp = vmDB.Startups.Single(s => s.Title.Equals(startupCEO.Startup.Title));
            var incubID_Before = strtp.IncubatorID;
            strtp.IncubatorID = incubatorID;
            vmDB.SubmitChanges();
            var incubID_After = strtp.IncubatorID;

            // Перевірка успішності розміщення стартапу в інкубаторі
            if (incubID_Before != incubID_After)
                MessageBox.Show("Your startup successfully joined\n to " 
                    + incubatorTitle + " business incubator");
            else
                MessageBox.Show("Oops! An error occurred.\n"
                    + "Your startup is failed to connect to the business incubator");

            btn_Join.Hide();
            ShowJoinErrorMessage();
        }

        /// <summary>
        /// Метод показує повідомлення про те, що стартап вже розміщений у інкубаторі
        /// </summary>
        private void ShowJoinErrorMessage()
        {
            int incID = (int)startupCEO.Startup.IncubatorID;
            string incubator = vmDB.Business_Incubators.Single(i => i.ID == incID).Title;
            lbl_JoinError.Text = "Your startup are located in the " + incubator 
                + " business incubator." + "\nYou can\'t join a new incubator now.";
            lbl_JoinError.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm icmp = new LoginForm();
            icmp.Show();
        }
    }
}
