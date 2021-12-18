using Akademine_IS;
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
        t_DataHandler dh;

        public Admin_MainMenu(t_DataHandler DataHandler, string UserType, string User)
        {
            InitializeComponent();
            CurrentUser.Text = User;
            usertype = UserType;
            dh = DataHandler;

            Login_screen ls = new Login_screen();
            ls.Close();
        }

        private void Vartotojai_Click(object sender, EventArgs e)
        {
            Vartotojai v = new Vartotojai(dh, usertype, CurrentUser.Text);
            v.ShowDialog();
        }

        private void Asmenys_Click(object sender, EventArgs e)
        {
            Asmenys a = new Asmenys(dh, usertype, CurrentUser.Text);
            a.ShowDialog();
        }

        private void StudijuDalykai_Click(object sender, EventArgs e)
        {
            StudijuDalykai sd = new StudijuDalykai(dh, usertype, CurrentUser.Text);
            sd.ShowDialog();
        }
    }
}
