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
    public partial class VartTipaiSelection : Form
    {
        t_DataHandler dh;
        public int VartotojuTipaiId = 0;
        public string Pavadinimas = "";
        string user;
        string usertype;

        public VartTipaiSelection(t_DataHandler DataHandler)
        {
            user = null;
            usertype = null;

            dh = DataHandler;
            t_StoredProc uspv_VartotojuTipai = new t_StoredProc(DataHandler, "uspv_VartotojuTipai");
            DataTable table_uspv_VartotojuTipais = uspv_VartotojuTipai.Open();

            InitializeComponent();
            VartTipaiSelectionGridView.DataSource = table_uspv_VartotojuTipais;

            int i = 0;
            while (i < VartTipaiSelectionGridView.Columns.Count)
            {
                if (VartTipaiSelectionGridView.Columns[i].Name.ToUpper().Equals("VARTOTOJUTIPAIID") || VartTipaiSelectionGridView.Columns[i].Name.ToUpper().Equals("KODAS")
                    || VartTipaiSelectionGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS"))
                {
                    VartTipaiSelectionGridView.Columns[i].Visible = true;
                }
                else
                {
                    VartTipaiSelectionGridView.Columns[i].Visible = false;
                }
                i++;
            }
            VartTipaiSelectionGridView.Columns[0].HeaderText = "Vartotojo tipo Id";
            VartTipaiSelectionGridView.Columns[1].HeaderText = "Kodas";
            VartTipaiSelectionGridView.Columns[2].HeaderText = "Pavadinimas";

        }

        private void VartTipaiSelectionGridView_DoubleClick(object sender, EventArgs e)
        {

            if (VartTipaiSelectionGridView.SelectedCells.Count > 0)
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

                DataRowView drv = ((DataTable)VartTipaiSelectionGridView.DataSource).DefaultView[VartTipaiSelectionGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["VartotojuTipaiId"] != null)
                    {
                        VartotojuTipaiId = Convert.ToInt32(drv.Row["VartotojuTipaiId"]);
                        Pavadinimas = Convert.ToString(drv.Row["Pavadinimas"]);
        
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }
    }
}
