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

namespace code.UserProfile
{
    public partial class StartupCEOMmbrProfile : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Клас StartupCEOMmbrProfile
        /// форма профілю користувача - керівника стартапом
        /// </summary>
        User user = null;
        Startup_Member startupCEO = null;
        DataClasses1DataContext vmDB;
        string incubatorTitle = null;
        ListViewItem lvi;
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
            lbl_City.Text = string.Format("Location: {0}", startupCEO.Address);
            lbl_Phone.Text = string.Format("Phone: {0}", startupCEO.Phone);
            lbl_Email.Text = string.Format("Email: {0}", user.Email);
            lbl_Skype.Text = string.Format("Skype: {0}", startupCEO.Skype);
            lbl_Twitter.Text = string.Format("Twitter: {0}", startupCEO.Twitter);
            rchTxtBx_About.Text = startupCEO.About;
            lbl_joinedDate.Text = "Joined on " + user.RegDate.ToShortDateString();
            lbl_lastLogin.Text = "Last login " + user.LoggedDate.ToString();
            pnl_Incubators.Hide();
            pnl_MyStartup.Hide();
            lbl_StartupsInIncubator.Hide();
            lbl_StartupsInIncubList.Hide();
            pnl_Applications.Hide();
            btn_Join.Hide();
            lbl_JoinError.Hide();
        }

        /// <summary>
        /// Метод відкриває профіль користувача при кліку на кнопку My Profile
        /// </summary>
        private void btn_LinkToProfile_Click(object sender, EventArgs e)
        {
            pnl_Profile.Show();
            pnl_Incubators.Hide();
            pnl_MyStartup.Hide();
            pnl_Applications.Hide();
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
            pnl_MyStartup.Hide();
            pnl_Applications.Hide();
            listView1.Clear();
            // Вивести бізнес інкубатори та інформацію про них
            // в ListView
            var incubators = vmDB.Business_Incubators.Select(inc => inc);
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
        /// Метод виводить детальну інформацію про вибраний у ListView бізнес інкубатор
        /// при кліку по стрічці зі списку інкубаторів
        /// </summary>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            incubatorTitle = null;
            startupCEO = vmDB.Startup_Members.Single(u => u.UserID == user.ID);

            if (listView1.SelectedIndices.Count <= 0)
                return;
            if (listView1.SelectedIndices.Count > 0)
            {
                lbl_StartupsInIncubList.Text = "";
                incubatorTitle = listView1.SelectedItems[0].Text;

                // Вивести стартапи, які вже розташовані у вибраному інкубаторі
                lbl_StartupsInIncubator.Text = 
                    string.Format("In the {0} incubator are already working: ", incubatorTitle);
                var incubator = vmDB.Business_Incubators.Single(i => incubatorTitle.Equals(i.Title));
                var startups = vmDB.Startups.Where(s => s.IncubID == incubator.ID);
                foreach (var s in startups)
                    lbl_StartupsInIncubList.Text += "\n" + s.Title;
                
                // Перевірити, чи розташований стартап у інкубаторі.
                // Якщо так - вивести повідомлення про це.
                // В іншому випадку - показати кнопку Join Incubator
                if (startupCEO.Startup.IncubID != null)
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
            startupCEO = vmDB.Startup_Members.Single(u => u.UserID == user.ID);

            int incubatorID = vmDB.Business_Incubators.Single(i => i.Title.Equals(incubatorTitle)).ID;
            var startup = vmDB.Startups.Single(s => s.Title.Equals(startupCEO.Startup.Title));
            var incubID_Before = startup.IncubID;
            startup.IncubID = incubatorID;
            try
            {
                vmDB.SubmitChanges();
            }
            catch(Exception ex)
            {
                logger.Error("Startup is failed to join to the business incubator\n{0}", ex.Message);
            }
            var incubID_After = startup.IncubID;

            // Перевірка успішності розміщення стартапу в інкубаторі
            if (incubID_Before != incubID_After)
                MessageBox.Show("Your startup successfully joined\n to " 
                    + incubatorTitle + " business incubator");
            else
                MessageBox.Show("Oops! An error occurred.\n"
                    + "Your startup is failed to join to the business incubator");

            btn_Join.Hide();
            ShowJoinErrorMessage();
        }

        /// <summary>
        /// Метод показує повідомлення про те, що стартап вже розміщений у інкубаторі
        /// </summary>
        private void ShowJoinErrorMessage()
        {
            startupCEO = vmDB.Startup_Members.Single(u => u.UserID == user.ID);

            var incubator = vmDB.Business_Incubators.Single(i => i.ID == startupCEO.Startup.Business_Incubator.ID);
            lbl_JoinError.Text = "Your startup are located in the " + incubator.Title 
                + " business incubator.\nYou can\'t join a new incubator now.";
            lbl_JoinError.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void btn_LinkToMyStartup_Click(object sender, EventArgs e)
        {
            pnl_Profile.Hide();
            pnl_Incubators.Hide();
            pnl_Applications.Hide();
            pnl_MyStartup.Show();

            var startup = vmDB.Startups.Single(s => s.Title.Equals(startupCEO.Startup.Title));
            var stceo = vmDB.Users.SingleOrDefault(u => u.ID == startup.ceoID);
            var devstage = vmDB.Development_Stages.Single(s => s.ID == startup.DevStageID);
            var icub = vmDB.Business_Incubators.SingleOrDefault(i => i.ID == startup.IncubID);

            lbl_MyStartupTitle.Text = startup.Title;
            rchTxtBox.Clear();
            if(stceo != null)
                rchTxtBox.Text = "CEO: " + stceo.FName + " " + stceo.LName;
            rchTxtBox.Text += "\nWebsite: " + startup.Website
                    + "\nDevelopment stage: " + devstage.Stage;
            if (icub != null)
                rchTxtBox.Text += "\nBusiness Incubator: " + startup.Business_Incubator.Title;
            rchTxtBox.Text += "\nTwitter: " + startup.Twitter
                    + "\nBusiness Model: " + startup.Business_Model
                    + "\nMarketing strategy: " + startup.Marketing_Strategy
                    + "\nTotal investment: " + startup.Total_Investment
                    + "\nFoundation date: " + startup.Foundation_Date.ToString().Remove(11);
         
            // Вивід у ListBox учасників команди даного стартапу
            List<string> startupTeam = new List<string>();
            var teamMember = vmDB.Startup_Members.Where(u => u.StartupID == startup.ID)
                .Select(u => u.User.FName + " " + u.User.LName);
            lstBx_StartupTeam.DataSource = teamMember;
        }

        private void btn_LinkToApplications_Click(object sender, EventArgs e)
        {
            vmDB = new DataClasses1DataContext();
            pnl_Profile.Hide();
            pnl_Incubators.Hide();
            pnl_MyStartup.Hide();
            pnl_Applications.Show();
            LoadApplicationList();
        }

        /// <summary>
        /// При кліку по кнопці створити заявку на фінансування
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CreateApplication_Click(object sender, EventArgs e)
        {
            vmDB = new DataClasses1DataContext();
            Application application = new Application();
            try
            {
                application.Application_Round = Convert.ToInt32(txtBx_RoundOfFunding.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message); 
            }
            application.StartupID = startupCEO.StartupID;
            application.State = "no state";
            application.ManagerID = null;
            application.CreationDate = DateTime.Now;
            try
            {
                vmDB.Applications.InsertOnSubmit(application);
                vmDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtBx_RoundOfFunding.Text = null;
            LoadApplicationList();
        }

        /// <summary>
        /// Метод виводить у ListView список заявок на фінансування
        /// </summary>
        private void LoadApplicationList()
        {
            var applications = vmDB.Applications.Where(a => a.StartupID == startupCEO.StartupID)
                .Select(a => a);

            lstVw_Applications.Clear();
            lstVw_Applications.FullRowSelect = true;
            lstVw_Applications.GridLines = false;

            lstVw_Applications.Columns.Add("ID", 40);
            lstVw_Applications.Columns.Add("Round", 60);
            lstVw_Applications.Columns.Add("State", 80);
            lstVw_Applications.Columns.Add("Invest Manager", 150);
            lstVw_Applications.Columns.Add("Creation Date", 125);

            string[] arr = new string[5];
            foreach (var a in applications)
            {
                arr[0] = a.ID.ToString();
                arr[1] = a.Application_Round.ToString();
                arr[2] = a.State;
                try
                {
                    arr[3] = a.Investment_Manager.User.FName + " " + a.Investment_Manager.User.LName;
                }
                catch (NullReferenceException)
                {
                    arr[3] = "Still empty";
                }
                arr[4] = a.CreationDate.ToShortDateString();
                lvi = new ListViewItem(arr);
                lstVw_Applications.Items.Add(lvi);
            }
        }
    }
}
