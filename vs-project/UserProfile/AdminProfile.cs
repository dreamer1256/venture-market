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
    public partial class AdminProfile : Form
    {
        /// <summary>
        /// Профіль адміністратора системи
        /// </summary>
        User user;
        public AdminProfile(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btn_AddIncubator_Click(object sender, EventArgs e)
        {
            AdminPanels.AddIncubator addIncub = new AdminPanels.AddIncubator();
            addIncub.ShowDialog();
        }
        
        private void btn_RemoveIncubator_Click(object sender, EventArgs e)
        {
            AdminPanels.RemoveIncubator removeInc = new AdminPanels.RemoveIncubator();
            removeInc.Show();
        }

        private void btn_AddAngelIv_Click(object sender, EventArgs e)
        {
            AdminPanels.AddAngelInvestor addAngelInvestor = new AdminPanels.AddAngelInvestor();
            addAngelInvestor.Show();
        }

        private void btn_AddStartup_Click(object sender, EventArgs e)
        {
            AdminPanels.AddStartup addStartup = new AdminPanels.AddStartup();
            addStartup.Show();
        }

        private void btn_AddInvestCompany_Click(object sender, EventArgs e)
        {
            AdminPanels.AddInvestCompany addInvCompany = new AdminPanels.AddInvestCompany();
            addInvCompany.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
    }
}
