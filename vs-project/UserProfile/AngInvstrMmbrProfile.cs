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
        public AngInvstrMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;
            InitializeComponent();
        }
    }
}
