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
    public partial class Vartotojai : Form
    {
        static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        private string usertype;
        private string user;
        int VartojaiId;

        public Vartotojai(string UserType, string User)
        {
            t_StoredProc uspv_Vartotojai = new t_StoredProc(DataHandler, "uspv_Vartotojai");
            DataTable table_uspv_Vartotojai = uspv_Vartotojai.Open();

            InitializeComponent();
            VartotojaiGridView.DataSource = table_uspv_Vartotojai;

            VartotojaiGridView.Columns[0].HeaderText = "Vartotojai Id";
            VartotojaiGridView.Columns[1].HeaderText = "Kodas";
            VartotojaiGridView.Columns[2].HeaderText = "Pavadinimas";
            VartotojaiGridView.Columns[3].HeaderText = "Vartotojų Tipas";
            VartotojaiGridView.Columns[4].HeaderText = "Asmuo";
            VartotojaiGridView.Columns[5].HeaderText = "Slaptažodis";
            VartotojaiGridView.Columns[6].HeaderText = "Ar aktyvus";

            usertype = UserType;
            user = User;

        }
        private void VartotojaiGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
              
                VartotojaiEdit ve = new VartotojaiEdit(VartojaiId, user, usertype);
                ve.ShowDialog();
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Admin_MainMenu mm = new Admin_MainMenu(usertype, user);
            mm.ShowDialog();
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {
            VartotojaiEdit ve = new VartotojaiEdit(VartojaiId, user, usertype);
            ve.ShowDialog();
        }
    }
}
