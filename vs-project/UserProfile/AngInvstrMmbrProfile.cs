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
    public partial class AngInvstrMmbrProfile : Form
    {
        User user;
        int ind = 0;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        //Startup startup;
        public AngInvstrMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            var angel = user.AngelInvestors.SingleOrDefault(u => u.UserID == user.ID);
            pnl_startups.Hide();
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

        private void AngInvstrMmbrProfile_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            pnl_startups.Hide();
            pnl_profile.Show();
        }

        private void startupslist_Click(object sender, EventArgs e)
        {
            if(ind == 1) { listView1.Items.Clear(); }
            pnl_profile.Hide();
            pnl_startups.Show();
            string arr = null;
            string dll = "sdsdds";
            var jr = (from p in vmDB.Startups
                      orderby p.IncubatorID

                      join t in vmDB.Business_Incubators on p.IncubatorID equals t.ID

                      select new { starname = p.Title, businame = t.Title, idb = p.IncubatorID });
            foreach (var group in jr)
            {
                arr = group.businame;
                ListViewGroup csharp_group = new ListViewGroup(arr);
                listView1.Groups.Add(csharp_group);
                var itm = new ListViewItem { Text = group.starname, Group = csharp_group };
                listView1.Items.Add(itm);
            }
            ind = 1;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sname = null;

            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (listView1.SelectedIndices.Count >= 0)
            {
                sname = listView1.SelectedItems[0].Text;
                MessageBox.Show(sname);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sname = null;
            string iname = null;

            sname = listView1.SelectedItems[0].SubItems[0].Text;
            iname = listView1.SelectedItems[0].SubItems[1].Text;
            MessageBox.Show(sname + " , " + iname);
        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }
    }
}
