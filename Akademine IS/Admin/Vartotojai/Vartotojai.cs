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
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = LENOVO; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
   
        private string usertype;
        private string user;
        t_DataHandler dh;

        public Vartotojai(t_DataHandler DataHandler, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_Vartotojai = new t_StoredProc(DataHandler, "uspv_Vartotojai");
            DataTable table_uspv_Vartotojai = uspv_Vartotojai.Open();

            InitializeComponent();
            VartotojaiGridView.DataSource = table_uspv_Vartotojai;

            int i = 0;
            while (i < VartotojaiGridView.Columns.Count)
            {
                if (VartotojaiGridView.Columns[i].Name.ToUpper().Equals("KODAS") || VartotojaiGridView.Columns[i].Name.ToUpper().Equals("VARTOTOJAIID")
                    || VartotojaiGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS") || VartotojaiGridView.Columns[i].Name.ToUpper().Equals("VARTOTOJUTIPAS")
                    || VartotojaiGridView.Columns[i].Name.ToUpper().Equals("ASMUO") || VartotojaiGridView.Columns[i].Name.ToUpper().Equals("SLAPTAZODIS")
                    || VartotojaiGridView.Columns[i].Name.ToUpper().Equals("ARAKTYVUS"))
                {
                    VartotojaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    VartotojaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

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

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)VartotojaiGridView.DataSource).DefaultView[VartotojaiGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["VartotojaiId"] != null)
                {
                    int vartId = Convert.ToInt32(drv.Row["VartotojaiId"]);
                    VartotojaiEdit ve = new VartotojaiEdit(dh, vartId, user, usertype);
                    ve.ShowDialog();
                }
            }
        }

        private void VartotojaiGridView_DoubleClick(object sender, EventArgs e)
        {

            if (VartotojaiGridView.SelectedCells.Count > 0)
            {
                /*
                int rowIndex = VartotojaiGridView.CurrentCell.RowIndex;
                int colIndex = VartotojaiGridView.CurrentCell.ColumnIndex;

                DataRow R = ((DataTable)VartotojaiGridView.DataSource).Rows[rowIndex];
                int Id = Convert.ToInt32(R["VartotojaiId"]);

                //string id = VartotojaiGridView.SelectedCells[0].Value.ToString();

                VartotojaiEdit ve = new VartotojaiEdit(Id, user, usertype);
                ve.ShowDialog();
                */

                DataRowView drv = ((DataTable)VartotojaiGridView.DataSource).DefaultView[VartotojaiGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["VartotojaiId"] != null)
                    {
                        int vartId = Convert.ToInt32(drv.Row["VartotojaiId"]);
                        VartotojaiEdit ve = new VartotojaiEdit(dh, vartId, user, usertype);
                        ve.ShowDialog();
                    }
                    
                }

            }
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            VartotojaiCreate ve = new VartotojaiCreate(dh);
            ve.ShowDialog();
        }
    }
}
