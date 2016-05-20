using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace code.UserProfile
{
    public partial class AngInvstrMmbrProfile : Form
    {
        User user;
        AngelInvestor global_angel;
        private Startup global_starup;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        ///
        ///Ініціалізація основної інформації Angel investor profile
        ///
        public AngInvstrMmbrProfile(User user)
        {
            this.user = user;
            InitializeComponent();

            pnl_startups.Hide();
            st_view.Hide();
            pnl_startups.Hide();
            st_view.Hide();
            angel_invest.Hide();
            pnl_my_investitions.Hide();

            global_angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
            var angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
            int logID = vmDB.UserLoginHistories.Where(h => h.UserID == user.ID)
                .OrderByDescending(h => h.LoggedDate).Select(h => h.ID).First();
            var userLogHist = vmDB.UserLoginHistories.Single(h => h.ID == logID);

            //основна інформація про користувача user
            if (user.Accaunt_Pic != null)
            {
                pictureBox1.Image = Image.FromFile(user.Accaunt_Pic);
            }
            lbl_name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_iexperience.Text = string.Format("Investment experience: {0}", angel.Investment_Experience);
            lbl_imax.Text = angel.Min_Amount + "\n" + angel.Max_amount;
            lbl_angel_info.Text = user.Email + "\n" 
                                  + angel.Skype + "\n" 
                                  + angel.Phone + "\n" 
                                  + angel.Twitter;
            lbl_joined.Text = "Joined on   " + user.RegDate.ToShortDateString();
            lbl_lastlog.Text = "Last seen   " + user.LoggedDate.ToString() +
                "\nIP:  " + userLogHist.IP + "\nOS:  " + userLogHist.OS + "\nDomain:  " + userLogHist.Domain;
            //вивід industry interests користувача user
            var checkeditems = from n in vmDB.Angel_Interests
                               where n.AngelID == angel.ID
                               select n;
            foreach (var j in checkeditems)
            {
                chlist_angel.Items.Add(j.Industry_Interests_List.Title);
            }
            code.LoginHistory.LoadUserLoginHistory(user.ID, lbl_LogHist);   // Завантажити історію логувань користувача
            code.SystemNews.LoadNews(pnl_News); // Завантажити стрічку новин
        }

        //вихід з профілю користувача
        private void button1_Click(object sender, EventArgs e)
        {
            UserExit.SaveUserStoryOnExit(user.ID);
            this.Close();
            LoginForm icmp = new LoginForm();
            icmp.Show();
        }

        //показ профілю користувача, обновлення фотографії профілю
        private void showprofile_Click(object sender, EventArgs e)
        {
            vmDB = new DataClasses1DataContext();
            string impath = vmDB.Users.Single(u => u.ID == user.ID).Accaunt_Pic;
            if (impath != null)
            {
                pictureBox1.Image = Image.FromFile(impath);
            }
            pnl_startups.Hide();
            st_view.Hide();
            angel_invest.Hide();
            pnl_my_investitions.Hide();
            pnl_profile.Show();
        }

        //вивід списку стартапів і заявок на фінансування
        private void startupslist_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            appic_view.Items.Clear();

            pnl_profile.Hide();
            st_view.Hide();
            pnl_my_investitions.Hide();
            angel_invest.Hide();
            pnl_startups.Show();

            applications_view();
            //вивід списку стартапів які не перебувають в інкубаторах засобами "Dictionary"
            var jr = (from p in vmDB.Startups
                      orderby p.IncubID

                      join t in vmDB.Business_Incubators on p.IncubID equals t.ID

                      select new { starname = p.Title, businame = t.Title });

            var strartupsByCompany = new Dictionary<string, List<string>>();
            foreach (var group in jr)
            {
                if (!strartupsByCompany.ContainsKey(group.businame))
                {
                    strartupsByCompany.Add(group.businame, new List<string>());
                }

                strartupsByCompany[group.businame].Add(group.starname);
            }

            foreach (var startups in strartupsByCompany)
            {
                ListViewGroup csharp_group = new ListViewGroup(startups.Key);
                listView1.Groups.Add(csharp_group);

                foreach (var startup in startups.Value)
                {
                    var itm = new ListViewItem { Text = startup, Group = csharp_group };
                    listView1.Items.Add(itm);
                }
            }
        }

        //відкриття форми редагування інформації про користувача
        private void button2_Click_1(object sender, EventArgs e)
        {
            int ifwasopened = code.user_profile_edit.getstate();
            if (ifwasopened != 1)
            {
                user_profile_edit open = new user_profile_edit(user);
                open.Show();
            }
        }

        //вивід вільних заявок
        private void applications_view()
        {
            appic_view.Clear();

            ListViewItem itm;

            string[] arr = new string[4];
            var snm = from s in vmDB.Applications
                      select s;
            appic_view.FullRowSelect = true;
            appic_view.GridLines = false;

            appic_view.Columns.Add("Startup name", 94);
            appic_view.Columns.Add("State", 101);
            appic_view.Columns.Add("Application round", 96);
            appic_view.Columns.Add("Creation date", 127);
            foreach (var s in snm)
            {
                if (s.State == "no state" && s.Startup.IncubID == null)
                {
                    arr[0] = s.Startup.Title;
                    arr[1] = s.State;
                    arr[2] = s.Application_Round.ToString();
                    arr[3] = s.CreationDate.ToLongDateString();
                    itm = new ListViewItem(arr);
                    appic_view.Items.Add(itm);
                }
            }
        }
        //реакція на вибір елемента у таблиці заявок на фінансування
        private void appic_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (appic_view.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (appic_view.SelectedIndices.Count >= 0)
            {
                pnl_profile.Hide();
                pnl_startups.Hide();
                angel_invest.Hide();
                pnl_my_investitions.Hide();
                st_view.Show();
                Startup st = vmDB.Startups.Single(u => u.Title.Equals(appic_view.SelectedItems[0].Text));
                angel_startup_investment(st,1);
            }
        }
        //реакція на вибір елемента у таблиці стартапів
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (listView1.SelectedIndices.Count >= 0)
            {
                pnl_profile.Hide();
                pnl_startups.Hide();
                angel_invest.Hide();
                pnl_my_investitions.Hide();
                st_view.Show();
                Startup st1 = vmDB.Startups.Single(u => u.Title.Equals(listView1.SelectedItems[0].Text));
                angel_startup_investment(st1, 0);
            }
        }
        //функція яка забечує перегляд інформації і інвестування у стартап
        private void angel_startup_investment(Startup st, int noIncubator)
        {
            pnl_profile.Hide();
            pnl_startups.Hide();
            angel_invest.Hide();
            pnl_my_investitions.Hide();
            if (noIncubator == 1)
            {
                btn_make_invest.Enabled = true;
                string stage = "seed stage";
                lbl_invest_info.Text = stage + "\n" + st.Total_Investment;
            } else {
                     btn_make_invest.Enabled = false;
                     lbl_invest_info.Text = st.Development_Stage1.Stage + "\n" + st.Total_Investment;
            }
            stname.Text = st.Title;
            User seoname = vmDB.Users.Single(u => u.ID.Equals(st.ceoID)); 
            lbl_startup_inf.Text = seoname.FName + " " + seoname.LName + "\n" + 
                                   st.Foundation_Date + "\n" + 
                                   st.Business_Model + "\n" +
                                   st.Marketing_Strategy;
            lbl_st_inf_con.Text =  st.Website + "\n" + st.Twitter;
            if (st.IncubID != null)
            {
                lbl_businc.Text = st.Business_Incubator.Title;
            } else { lbl_businc.Text = " "; }
            global_starup = null;
        }

        private void btn_make_invest_Click(object sender, EventArgs e)
        {
            angel_invest.Show();
        }

        private void AngInvstrMmbrProfile_Load(object sender, EventArgs e)
        {

        }
        //завершення операції інвестування
        private void btn_inv_Click(object sender, EventArgs e)
        {
            if (txt_inv.Text == "" && txt_inv_title.Text == "" && txt_inv_description.Text == "")
            {
                MessageBox.Show("Fill in a fields!", "", MessageBoxButtons.OK);
            } else {
                Startup star = vmDB.Startups.Single(u => u.Title == stname.Text);
                var angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
                Application app = vmDB.Applications.Single(u => u.StartupID == star.ID);
                app.State = "accepted";
                app.Angel_ID = angel.ID;
                app.Application_Round += 1;
                Round_Investor newRI= new Round_Investor();
                Round_Of_Funding newRF = new Round_Of_Funding();
                decimal invamount = Decimal.Parse(txt_inv.Text);
                decimal old_amount = Decimal.Parse(star.Total_Investment.ToString());
                newRI.AngelID = angel.ID;
                newRF.StartupID = star.ID;
                newRF.Title = txt_inv_title.Text;
                newRF.Description = txt_inv_description.Text;
                newRF.Total_Investment = invamount;
                newRI.RoundID = 1;
                newRF.invest_date = DateTime.Now;
                star.Total_Investment = invamount + old_amount;
                vmDB.Round_Investors.InsertOnSubmit(newRI);
                vmDB.Round_Of_Fundings.InsertOnSubmit(newRF);

                News news = new News
                {
                    Information = user.FName + " " + user.LName + " has allocated money for the "
                        + star.Title + " startup",
                    Date = DateTime.Now,
                    Type = "Application"
                };
                vmDB.News.InsertOnSubmit(news);
                try
                {
                    vmDB.SubmitChanges();
                    logger.Info("Angel investor has allocated money for the " + star.Title + " startup\n"
                         + "\t[UserID: " + user.ID + ", UserName: " + user.Username + ", Startup: ]" + star.Title);
                }
                catch(Exception ex)
                {
                    logger.Info("An error occured when Angel investor tried to allocate money for the " + star.Title + " startup\n"
                         + "\t[UserID: " + user.ID + ", UserName: " + user.Username + ", Startup: ]" + star.Title);
                    MessageBox.Show(ex.Message);
                }
                if (MessageBox.Show("Operation completed", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    angel_invest.Hide();
                }
            }
        }
        //перегляд прийнятих заявок
        private void btn_my_inv_Click(object sender, EventArgs e)
        {
            pnl_profile.Hide();
            pnl_startups.Hide();
            st_view.Hide();
            angel_invest.Hide();
            pnl_my_investitions.Show();
            lv_my_investitions.Clear();
            lbl_myinv_stinfo.Text = "";
            list_history_inv.Clear();
            ListViewItem item;

            string[] additm = new string[2];
            var myinv = from s in vmDB.Applications
                      select s;
            lv_my_investitions.FullRowSelect = true;
            lv_my_investitions.GridLines = false;

            lv_my_investitions.Columns.Add("Startup name", 94);
            lv_my_investitions.Columns.Add("Application round", 96);
            foreach (var s in myinv)
            {
                if (s.State == "accepted" && s.Angel_ID == global_angel.ID)
                {
                    additm[0] = s.Startup.Title;
                    additm[1] = s.Application_Round.ToString();
                    item = new ListViewItem(additm);
                    lv_my_investitions.Items.Add(item);
                }
            }
        }
        //реакція на вибір елемента в списку прийнятих заявок
        private void lv_my_investitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_myinv_stinfo.Text = "";
            list_history_inv.Clear();
            if (lv_my_investitions.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (lv_my_investitions.SelectedIndices.Count >= 0)
            {
                btn_view_st_home.Enabled = true;
                global_starup = vmDB.Startups.Single(u => u.Title.Equals(lv_my_investitions.SelectedItems[0].Text));
                my_investitions_startup_info(global_starup);
            }
        }

        //відображення інформації про вибраний стартап(із прийнятих заявок)
        private void my_investitions_startup_info(Startup startup)
        {
            lbl_myinv_stinfo.Text = startup.Title + "\n" +
                                   startup.Total_Investment + "\n" +
                                   startup.Development_Stage1.Stage;

            ListViewItem history_item;
            string[] history_list = new string[2];
            list_history_inv.FullRowSelect = true;
            list_history_inv.GridLines = false;
            list_history_inv.Columns.Add("Total investments", 102);
            list_history_inv.Columns.Add("Date", 162);

            var history = (from ARF in vmDB.Round_Of_Fundings
                           join ARI in vmDB.Round_Investors on ARF.ID equals ARI.ID
                           select new {startupid = ARF.StartupID, title = ARF.Title, total_inv = ARF.Total_Investment, description = ARF.Description, angelid = ARI.AngelID, date = ARF.invest_date});

            foreach (var kk in history)
            {
                if (kk.angelid == global_angel.ID && kk.startupid == startup.ID)
                {
                    history_list[0] = kk.total_inv.ToString();
                    history_list[1] = kk.date.ToString();
                    history_item = new ListViewItem(history_list);
                    list_history_inv.Items.Add(history_item);
                }
            }
        }

        //відобразити загальну інформацію про стартап
        private void btn_view_st_home_Click(object sender, EventArgs e)
        {
            btn_view_st_home.Enabled = false;
            pnl_profile.Hide();
            pnl_startups.Hide();
            angel_invest.Hide();
            pnl_my_investitions.Hide();
            st_view.Show();
            angel_startup_investment(global_starup, 1);
        }
    }
}
