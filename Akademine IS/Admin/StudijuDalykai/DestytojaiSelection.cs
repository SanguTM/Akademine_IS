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
    public partial class DestytojaiSelection : Form
    {
        t_DataHandler dh;
        public int AsmenysId = 0;
        public string Vardas = "";
        public string Pavarde = "";
        string user;
        string usertype;

        public DestytojaiSelection(t_DataHandler DataHandler)
        {
            user = null;
            usertype = null;

            dh = DataHandler;
            t_StoredProc uspv_Asmenys = new t_StoredProc(DataHandler, "uspv_Asmenys");
            uspv_Asmenys.ParamByName("@piPriskirti").Value = 1;
            DataTable table_uspv_Asmenys = uspv_Asmenys.Open();

            InitializeComponent();
            AsmSelectionGridView.DataSource = table_uspv_Asmenys;

            int i = 0;
            while (i < AsmSelectionGridView.Columns.Count)
            {
                if (AsmSelectionGridView.Columns[i].Name.ToUpper().Equals("VARDAS") || AsmSelectionGridView.Columns[i].Name.ToUpper().Equals("PAVARDE")
                    || AsmSelectionGridView.Columns[i].Name.ToUpper().Equals("AMZIUS") || AsmSelectionGridView.Columns[i].Name.ToUpper().Equals("ASMENSKODAS")
                    || AsmSelectionGridView.Columns[i].Name.ToUpper().Equals("ASMUOID"))
                {
                    AsmSelectionGridView.Columns[i].Visible = true;
                }
                else
                {
                    AsmSelectionGridView.Columns[i].Visible = false;
                }
                i++;
            }
            AsmSelectionGridView.Columns[0].HeaderText = "Asmuo Id";
            AsmSelectionGridView.Columns[1].HeaderText = "Vardas";
            AsmSelectionGridView.Columns[2].HeaderText = "Pavardė";
            AsmSelectionGridView.Columns[3].HeaderText = "Amžius";
            AsmSelectionGridView.Columns[4].HeaderText = "Asmens kodas";
        }

        private void AsmSelectionGridView_DoubleClick(object sender, EventArgs e)
        {

            if (AsmSelectionGridView.SelectedCells.Count > 0)
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

                DataRowView drv = ((DataTable)AsmSelectionGridView.DataSource).DefaultView[AsmSelectionGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["AsmuoId"] != null)
                    {
                        AsmenysId = Convert.ToInt32(drv.Row["AsmuoId"]);
                        Vardas = Convert.ToString(drv.Row["Vardas"]);
                        Pavarde = Convert.ToString(drv.Row["Pavarde"]);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }
    }
}
