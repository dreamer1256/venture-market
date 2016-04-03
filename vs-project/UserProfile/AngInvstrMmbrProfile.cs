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

namespace code.UserProfile
{
    public partial class AngInvstrMmbrProfile : Form
    {
        User user;
        int ind = 0;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        public AngInvstrMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            var angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
            pnl_startups.Hide();
            pnl_edit.Hide();
            st_view.Hide();
            //pictureBox1.Image = Image.FromFile(user.acc_pic);
            lbl_name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_phone.Text = string.Format("Phone: {0}", angel.Phone);
            lbl_email.Text = string.Format("Email: {0}", user.Email);
            lbl_skype.Text = string.Format("Skype: {0}", angel.Skype);
            lbl_geoint.Text = string.Format("Geo interests: {0}", angel.Geo_Inerests);
            lbl_twitter.Text = string.Format("Twitter: {0}", angel.Twitter);
            lbl_imax.Text = string.Format("Max: {0}", angel.Max_amount);
            lbl_imin.Text = string.Format("Min: {0}", angel.Min_Amount);
            lbl_iexperience.Text = string.Format("Investment experience: {0}", angel.Investment_Experience);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm icmp = new LoginForm();
            icmp.Show();
        }

        private void showprofile_Click(object sender, EventArgs e)
        {
            ind = 0;
            listView1.Items.Clear();
            appic_view.Items.Clear();
            st_view.Hide();
            pnl_startups.Hide();
            pnl_edit.Hide();
            pnl_profile.Show();
        }

        private void startupslist_Click(object sender, EventArgs e)
        {
            if (ind == 1)
            {
                listView1.Items.Clear();
                appic_view.Items.Clear();
            }
            st_view.Hide();
            pnl_profile.Hide();
            pnl_edit.Hide();
            pnl_startups.Show();
            applications_view();
            var jr = (from p in vmDB.Startups
                      orderby p.IncubatorID

                      join t in vmDB.Business_Incubators on p.IncubatorID equals t.ID

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

            ind = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            int userID = user.ID;
            User addim = vmDB.Users.Single(r => r.ID == userID);
            openFileDialog1.InitialDirectory = "d:";
            openFileDialog1.Filter = "image (JPEG,PNG) files (*.jpg)|*.jpg|*.png)|*.png|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string flnm = openFileDialog1.FileName;
                //addim.acc_pic = flnm;
                //vmDB.SubmitChanges();
            } else { MessageBox.Show("Изображение не загружено!"); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pnl_startups.Hide();
            pnl_profile.Hide();
            pnl_edit.Show();
        }

        private void applications_view()
        {
            ListViewItem itm;
            string[] arr = new string[3];
            var snm = from s in vmDB.Applications
                      select s;
            foreach (var s in snm)
            {
                if (s.State == "no state" && s.Startup.IncubatorID == null)
                {
                    arr[0] = s.Startup.Title;
                    arr[1] = s.State;
                    arr[2] = s.Application_Round.ToString();
                    itm = new ListViewItem(arr);
                    appic_view.Items.Add(itm);
                }
            }
        }

        private void appic_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (appic_view.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (appic_view.SelectedIndices.Count >= 0)
            {
                pnl_startups.Hide();
                st_view.Show();
                angel_invest.Hide();
                Startup st = vmDB.Startups.Single(u => u.Title.Equals(appic_view.SelectedItems[0].Text));
                angel_startup_investment(st,1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (listView1.SelectedIndices.Count >= 0)
            {
                pnl_startups.Hide();
                st_view.Show();
                Startup st1 = vmDB.Startups.Single(u => u.Title.Equals(listView1.SelectedItems[0].Text));
                angel_startup_investment(st1, 0);
            }
        }
        private void angel_startup_investment(Startup st, int noIncubator)
        {
            angel_invest.Hide();
            if (noIncubator == 1)
            {
                btn_make_invest.Enabled = true;
                string stage = "seed stage";
                lbl_invest_info.Text = stage + "\n" + st.Total_Investment;
            } else {
                     btn_make_invest.Enabled = false;
                     lbl_invest_info.Text = st.Development_Stage.Stage + "\n" + st.Total_Investment;
            }
            stname.Text = st.Title; 
            lbl_startup_inf.Text = st.CEO + "\n" + 
                                   st.Foundation_Date + "\n" + 
                                   st.Business_Model + "\n" +
                                   st.Marketing_Strategy;
            lbl_st_inf_con.Text =  st.Website + "\n" + st.Twitter;
 
        }

        private void btn_make_invest_Click(object sender, EventArgs e)
        {
            angel_invest.Show();
        }

        private void AngInvstrMmbrProfile_Load(object sender, EventArgs e)
        {

        }

        private void btn_inv_Click(object sender, EventArgs e)
        {
            if (txt_inv.Text == "")
            {
                MessageBox.Show("Amount is null", "", MessageBoxButtons.OK);
            } else {
                Startup star = vmDB.Startups.Single(u => u.Title == stname.Text);
                Application app = vmDB.Applications.Single(s => s.StartupID == star.ID);
                decimal invamount = Decimal.Parse(txt_inv.Text);
                decimal old_amount = Decimal.Parse(star.Total_Investment.ToString());
                int old_app_round = app.Application_Round;
                decimal tmp = invamount + old_amount;
                int tmp2 = old_app_round + 1;
                star.Total_Investment = tmp;
                app.Application_Round = tmp2;
                vmDB.SubmitChanges();
                if (MessageBox.Show("Operation completed", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    angel_invest.Hide();
                }
            }
        }
    }
}
