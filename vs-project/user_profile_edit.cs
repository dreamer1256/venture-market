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
        bool isvalidemailcheck;
        public static int wasopened;
        public user_profile_edit(User user)
        {
            InitializeComponent();
            wasopened = 1;
            //you should close all panels on "User profile information"
            pnl_angl.Hide();
            pnl_combr_edit.Hide();
            pnl_startupceo_edit_prfl2.Hide();
            pnl_inv_mngr_edit.Hide();
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
                    pnl_combr_edit.Show();
                    break;
                case (int)URoles.Role.StartupCEO:
                    pnl_startupceo_edit_prfl2.Show();
                    break;
                case (int)URoles.Role.InvestManager:
                    initialise_invest_manager_edit_page();
                    break;
                case (int)URoles.Role.StartupMember:
                    pnl_startupceo_edit_prfl2.Show();
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
            if (txt_new_email.Text != "" && code.ValidateEmail.IsValidEmail(txt_new_email.Text) == true)
            {
                changePRFL.Email = txt_new_email.Text;
            } else if (txt_new_email.Text == "" || code.ValidateEmail.IsValidEmail(txt_new_email.Text) == false)
            {
                MessageBox.Show("Email is not valid!");
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
        //submit changes for company member edit panel
        private void btn_cmbr_esit_confirm_Click(object sender, EventArgs e)
        {
            if (txt_cmbr_phone.Text != "" && txt_cmbr_twitter.Text != "" && txt_cmbr_skype.Text != "")
            {
                var cmbr = vmDB.CompanyMember.Single(u => u.UserID == user.ID);
                cmbr.Phone = txt_cmbr_phone.Text;
                cmbr.Twitter = txt_cmbr_twitter.Text;
                cmbr.Skype = txt_cmbr_skype.Text;
                vmDB.SubmitChanges();
            }
        }
        //submit changes for startup member edit panel
        private void btn_ceo_submit_ch_Click(object sender, EventArgs e)
        {
            if (txt_ceo_edit_phone.Text != "" && txt_ceo_edit_adress.Text  != "" && txt_ceo_edit_about.Text != "" && txt_ceo_edit_twitter.Text  != "" && txt_ceo_edit_skype.Text != "")
            {
                var ceo = vmDB.Startup_Members.Single(u => u.UserID == user.ID);
                ceo.Phone = txt_ceo_edit_phone.Text;
                ceo.Address = txt_ceo_edit_adress.Text;
                ceo.About = txt_ceo_edit_about.Text;
                ceo.Twitter = txt_ceo_edit_twitter.Text;
                ceo.Skype = txt_ceo_edit_skype.Text;
            }
        }
        //initialise invest manager panel, put companies in cmbx
        private void initialise_invest_manager_edit_page()
        {
            pnl_inv_mngr_edit.Show();
            var im_company = from c in vmDB.Investment_Companies
                             select c.Title;
            foreach (var l in im_company)
                cmbx_change_comp.Items.Add(l);
        }
        //submit changes for inves manager edit panel
        private void btn_invmngr_edit_Click(object sender, EventArgs e)
        {
            if (cmbx_change_comp.Text != null)
            {
                var invmngr = vmDB.Investment_Managers.Single(u => u.UserID == user.ID);
                Investment_Company ch_company = vmDB.Investment_Companies.Single(c => c.Title == cmbx_change_comp.Text);
                invmngr.Investment_CompanyID = ch_company.ID;
            }
        }

        private void user_profile_edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            wasopened = 0;
        }
        public static int getstate()
        {
            return wasopened;
        }

        private void txt_new_email_Leave(object sender, EventArgs e)
        {
            isvalidemailcheck = code.ValidateEmail.IsValidEmail(txt_new_email.Text);
            if (isvalidemailcheck == true)
            {
                lbl_email_isv.ForeColor = System.Drawing.Color.Green;
                lbl_email_isv.Text = "email is valid";
            }
            else if (isvalidemailcheck == false)
            {
                lbl_email_isv.ForeColor = System.Drawing.Color.Red;
                lbl_email_isv.Text = "email is not valid";
            }
        }
    }
}
