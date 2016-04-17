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
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        public AngInvstrMmbrProfile(User user)
        {
            InitializeComponent();
            pnl_startups.Hide();
            pnl_edit.Hide();
            st_view.Hide();
            this.user = user;
            var angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
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
            lbl_lastlogreg.Text = user.RegDate.ToShortDateString() + "\n" + user.LoggedDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm icmp = new LoginForm();
            icmp.Show();
        }

        private void showprofile_Click(object sender, EventArgs e)
        {
            st_view.Hide();
            pnl_startups.Hide();
            pnl_edit.Hide();
            pnl_profile.Show();
        }

        private void startupslist_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            appic_view.Items.Clear();

            st_view.Hide();
            pnl_profile.Hide();
            pnl_edit.Hide();
            pnl_startups.Show();

            applications_view();

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

        private void button3_Click(object sender, EventArgs e)
        {
            int userID = user.ID;
            User addim = vmDB.Users.Single(r => r.ID == userID);
            openFileDialog1.InitialDirectory = "d:";
            openFileDialog1.Filter = "image (JPEG,PNG) files (*.jpg)|*.jpg|*.png)|*.png|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string flnm = openFileDialog1.FileName;
                addim.Accaunt_Pic = flnm;
                vmDB.SubmitChanges();
                MessageBox.Show("Изображение загружено!");
            }
            else { MessageBox.Show("Изображение не загружено!"); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pnl_startups.Hide();
            pnl_profile.Hide();
            pnl_edit.Show();
        }

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
            if (txt_inv.Text == "" && txt_inv_title.Text == "" && txt_inv_description.Text == "")
            {
                MessageBox.Show("Complete all fields", "", MessageBoxButtons.OK);
            } else {
                Startup star = vmDB.Startups.Single(u => u.Title == stname.Text);
                var angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
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
                star.Total_Investment = invamount + old_amount;
                vmDB.Round_Investors.InsertOnSubmit(newRI);
                vmDB.Round_Of_Fundings.InsertOnSubmit(newRF);
                try {
                    vmDB.SubmitChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (MessageBox.Show("Operation completed", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    angel_invest.Hide();
                }
            }
        }
    }
}
