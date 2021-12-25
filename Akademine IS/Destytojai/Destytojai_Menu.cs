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
    public partial class Destytojai_Menu : Form
    {
        int userid;
        private string usertype;
        t_DataHandler dh;
        int asmuoid;
        public Destytojai_Menu(t_DataHandler DataHandler, string UserType, string User, int UserId, int AsmuoId)
        {
            InitializeComponent();
            CurrentUser.Text = User;
            usertype = UserType;
            userid = UserId;
            dh = DataHandler;
            asmuoid = AsmuoId;

            Login_screen ls = new Login_screen();
            ls.Close();
        }

        private void Nustatymai_Click(object sender, EventArgs e)
        {
            Nustatymai v = new Nustatymai(dh, userid, usertype, CurrentUser.Text);
            v.ShowDialog();
        }

        private void IrasytiPazymi_Click(object sender, EventArgs e)
        {
            PasirinktiDalyka v = new PasirinktiDalyka(dh, asmuoid);
            v.ShowDialog();
        }
    }
}
