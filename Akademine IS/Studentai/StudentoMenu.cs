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

    public partial class StudentoMenu : Form
    {
        int userid;
        private string usertype;
        t_DataHandler dh;
        int asmuoid;
        public StudentoMenu(t_DataHandler DataHandler, string UserType, string User, int UserId, int AsmuoId)
        {
            InitializeComponent();
        }

        private void Nustatymai_Click(object sender, EventArgs e)
        {
            Nustatymai v = new Nustatymai(dh, userid, usertype, CurrentUser.Text);
            v.ShowDialog();
        }

        private void PerziuretiPazymi_Click(object sender, EventArgs e)
        {
            PasirinktiStudentoDalyka v = new PasirinktiStudentoDalyka(dh, asmuoid);
            v.ShowDialog();
        }
    }
}
