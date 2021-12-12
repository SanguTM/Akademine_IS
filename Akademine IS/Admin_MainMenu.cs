using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akademine_IS
{
    public partial class Admin_MainMenu : Form
    {
        private string usertype;

        public Admin_MainMenu(string UserType, string User)
        {
            InitializeComponent();
            CurrentUser.Text = User;
            usertype = UserType;

            Login_screen ls = new Login_screen();
            ls.Close();
        }

        private void Vartotojai_Click(object sender, EventArgs e)
        {
            Vartotojai v = new Vartotojai(usertype, CurrentUser.Text);
            v.ShowDialog();
        }
    }
}
