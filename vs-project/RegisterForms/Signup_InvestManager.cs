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
    public partial class Signup_InvestManager : Form
    {
        //private int newUserID = 0;
        public Signup_InvestManager()
        {
            InitializeComponent();
            //this.newUserID = newUserID;
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            /*
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            var qry = from m in vmDB.AngelInvestors
                     
                      select m;
            
                Investment_Manager manager = new Investment_Manager();

                manager.UserID = newUserID;
                manager.Investment_CompanyID = 2;
                //manager.Geo_Inerests = 
                vmDB.Investment_Managers.InsertOnSubmit(manager);
                vmDB.SubmitChanges();
           */
        }
    }
}
