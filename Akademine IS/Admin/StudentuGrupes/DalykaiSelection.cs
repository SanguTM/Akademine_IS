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
    public partial class DalykaiSelection : Form
    {
        t_DataHandler dh;
        public int StdDalykoId = 0;
        public string Kodas = "";
        public string Pavadinimas = "";
        public string Aprasymas = "";
        string user;
        string usertype;
        public DalykaiSelection(t_DataHandler DataHandler)
        {
            user = null;
            usertype = null;

            dh = DataHandler;
            t_StoredProc uspv_StudijuDalykai = new t_StoredProc(DataHandler, "uspv_StudijuDalykai");
            DataTable table_uspv_StudijuDalykai = uspv_StudijuDalykai.Open();

            InitializeComponent();

            DalykaiSelectionGridView.DataSource = GetStudijuDalykai();

            int i = 0;
            while (i < DalykaiSelectionGridView.Columns.Count)
            {
                if (DalykaiSelectionGridView.Columns[i].Name.ToUpper().Equals("STDDALYKAIID") || DalykaiSelectionGridView.Columns[i].Name.ToUpper().Equals("KODAS")
                    || DalykaiSelectionGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS") || DalykaiSelectionGridView.Columns[i].Name.ToUpper().Equals("APRASYMAS"))
                {
                    DalykaiSelectionGridView.Columns[i].Visible = true;
                }
                else
                {
                    DalykaiSelectionGridView.Columns[i].Visible = false;
                }
                i++;
            }
            DalykaiSelectionGridView.Columns[0].HeaderText = "Studijų dalykai Id";
            DalykaiSelectionGridView.Columns[1].HeaderText = "Kodas";
            DalykaiSelectionGridView.Columns[2].HeaderText = "Pavadinimas";
            DalykaiSelectionGridView.Columns[3].HeaderText = "Aprašymas";
        }

        private DataTable GetStudijuDalykai()
        {
            t_StoredProc uspv_StudijuDalykai = new t_StoredProc(dh, "uspv_StudijuDalykai");
            return uspv_StudijuDalykai.Open();
        }

        private void DalykaiSelectionGridView_DoubleClick(object sender, EventArgs e)
        {
            if (DalykaiSelectionGridView.SelectedCells.Count > 0)
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

                DataRowView drv = ((DataTable)DalykaiSelectionGridView.DataSource).DefaultView[DalykaiSelectionGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StdDalykoId"] != null)
                    {
                        StdDalykoId = Convert.ToInt32(drv.Row["StdDalykoId"]);
                        Kodas = Convert.ToString(drv.Row["Kodas"]);
                        Pavadinimas = Convert.ToString(drv.Row["Pavadinimas"]);
                        Aprasymas = Convert.ToString(drv.Row["Aprasymas"]);

                        this.DialogResult = DialogResult.OK; ;
                    }
                }
            }
        }
    }
}
