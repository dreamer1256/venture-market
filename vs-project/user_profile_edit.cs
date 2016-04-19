using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace code
{
    public partial class user_profile_edit : Form
    {
        User user;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        public user_profile_edit(User user)
        {
            InitializeComponent();
            //you should close all panels on "User profile information"
            pnl_angl.Hide();
            //

            this.user = user;
            lbl_cur_address.Text = user.Email;
            User_Role userRole = vmDB.User_Roles.Single(r => r.UserId == user.ID);
            //show panel which refers to a role
            switch (userRole.RoleID)
            {
                case (int)URoles.Role.AnglInvestor:
                    intialiseangel();
                    break;
                case (int)URoles.Role.InvCompanyMember:
                    //show panel
                    break;
                case (int)URoles.Role.StartupCEO:
                    //show panel
                    break;
                case (int)URoles.Role.InvestManager:
                    //show panel
                    break;
                case (int)URoles.Role.StartupMember:
                    //show panel
                    break;
            }
        }
        //show angel panel and check items in checkboxlist
        private void intialiseangel()
        {
            pnl_angl.Show();
            var angel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
            var checkeditems = from n in vmDB.Angel_Interests
                               where n.AngelID == angel.ID
                               select n;
            foreach(var j in checkeditems)
            {
                chlist_ind_int.SetItemChecked(j.InterestID - 1, true);
            }
        }

        //change image of account
        private void change_image()
        {
            int userID = user.ID;
            User addim = vmDB.Users.Single(r => r.ID == userID);

            openFileDialog1.InitialDirectory = "c:";
            openFileDialog1.Filter = "image (JPEG,PNG) files (*.jpg)|*.jpg|*.png)|*.png|All files (*.*)|*.*";

            try
            {
                openFileDialog1.ShowDialog();
                var fileName = openFileDialog1.FileName;
                string str = Path.GetFileName(fileName);
                string destpath = @"C:\VentureMarket\image_cache\";
                bool exists = System.IO.Directory.Exists(destpath);
                if (!exists) { System.IO.Directory.CreateDirectory(destpath); }
                File.Copy(fileName, destpath + str, true);
                addim.Accaunt_Pic = destpath + str;
                vmDB.SubmitChanges();
                MessageBox.Show("Изображение загружено!");
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Изображение не загружено!");
            }
        }

        private void btn_change_image_Click(object sender, EventArgs e)
        {
            change_image();
        }

        //submit changes for user edit panel(General)
        private void button1_Click(object sender, EventArgs e)
        {
            int userID = user.ID;
            User changePRFL = vmDB.Users.Single(r => r.ID == userID);
            if (txt_new_email.Text != "")
            {
                changePRFL.Email = txt_new_email.Text;
            }
            if (txt_fname_ch.Text != "")
            {
                changePRFL.FName = txt_fname_ch.Text;
            }
            if (txt_lname_ch.Text != "")
            {
                changePRFL.LName = txt_lname_ch.Text;
            }
            if (txt_old_pass.Text != "" && txt_new_pass.Text != "" && txt_repeat_pass.Text != "")
            {
                if(txt_old_pass.Text == changePRFL.Password)
                {
                    if(txt_new_pass.Text == txt_repeat_pass.Text)
                    {
                        changePRFL.Password = txt_new_pass.Text;
                    }
                    else { MessageBox.Show("New and repeated passwords don't match!"); }
                }
                else { MessageBox.Show("Old password is incorrect!"); }
            }
            vmDB.SubmitChanges();
        }
        //submit changes for angel investor edit panel
        private void btn_sbm_ch_angel_Click(object sender, EventArgs e)
        {
            int userID = user.ID;
            var changel = vmDB.AngelInvestors.Single(u => u.UserID == user.ID);
            if (txt_angel_phone.Text != "")
            {
                changel.Phone = txt_angel_phone.Text;
            }
            if (txt_angel_skype.Text != "")
            {
                changel.Skype = txt_angel_skype.Text;
            }
            if (txt_angel_twitter.Text != "")
            {
                changel.Twitter = txt_angel_twitter.Text;
            }
            if (txt_angel_exp.Text != "")
            {
                changel.Investment_Experience = txt_angel_exp.Text;
            }
            if (txt_angel_max.Text != "")
            {
                changel.Max_amount = Decimal.Parse(txt_angel_max.Text);
            }
            if (txt_angel_min.Text != "")
            {
                changel.Min_Amount = Decimal.Parse(txt_angel_min.Text);
            }
            var checkeditems = from n in vmDB.Angel_Interests
                               where n.AngelID == changel.ID
                               select n;
            int num = checkeditems.Count();
            foreach (var j in checkeditems)
            {
                vmDB.Angel_Interests.DeleteOnSubmit(j);
            }
            vmDB.SubmitChanges();
            for (int i = 0; i < chlist_ind_int.CheckedIndices.Count; i++)
            {
                Angel_Interest addint = new Angel_Interest();
                addint.InterestID = (chlist_ind_int.CheckedIndices[i] + 1);
                addint.AngelID = changel.ID;
                vmDB.Angel_Interests.InsertOnSubmit(addint);
                vmDB.SubmitChanges();
            }
        }
    }
}
