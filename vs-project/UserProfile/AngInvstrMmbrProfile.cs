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
        Image MemForImage;
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
            pnl_edit.Hide();
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
            pnl_edit.Hide();
            pnl_profile.Show();
        }

        private void startupslist_Click(object sender, EventArgs e)
        {
            if (ind == 1) { listView1.Items.Clear(); }
            pnl_profile.Hide();
            pnl_edit.Hide();
            pnl_startups.Show();
            string arr = null;
            string dll = "sdsdds";
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

        private void button3_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pnl_startups.Hide();
            pnl_profile.Hide();
            pnl_edit.Show();
        }
        private void LoadImage()
        {

            // директория, которая будет выбрана как начальная в окне для выбора файла 
            openFileDialog1.InitialDirectory = "c:";
            // устанавливаем формат файлов для загрузки - jpg 
                openFileDialog1.Filter = "image (JPEG,PNG) files (*.jpg)|*.jpg|*.png)|*.png|All files (*.*)|*.*";

            // если открытие окна выбора файла завершилось выбором файла и нажатием кнопки ОК 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try // безопасная попытка 
                {
                    // пытаемся загрузить файл с именем openFileDialog1.FileName - выбранный пользователем файл. 
                    MemForImage = Image.FromFile(openFileDialog1.FileName);
                    // устанавливаем картинку в поле элемента PictureBox 
                    pictureBox1.Image = MemForImage;
                }
                catch (Exception ex) // если попытка загрузки не удалась 
                {
                    // выводим сообщение с причиной ошибки 
                    MessageBox.Show("Не удалось загрузить файл: " + ex.Message);
                }

            }

        }
    }
}
