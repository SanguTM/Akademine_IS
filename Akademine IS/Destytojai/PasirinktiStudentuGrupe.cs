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
    public partial class PasirinktiStudentuGrupe : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int std;
        int dest;
        public PasirinktiStudentuGrupe(t_DataHandler DataHandler, int StdDalykoId, int DestytojaiId)
        {
            std = StdDalykoId;
            dh = DataHandler;
            dest = DestytojaiId;
            t_StoredProc uspv_StudentuGrupes = new t_StoredProc(DataHandler, "uspv_StudentuGrupes");
            uspv_StudentuGrupes.ParamByName("@piStdDalykoId").Value = StdDalykoId;
            DataTable table_uspv_StudentuGrupes = uspv_StudentuGrupes.Open();

            InitializeComponent();
            DestStudentuGrupesGridView.DataSource = table_uspv_StudentuGrupes;

            int i = 0;
            while (i < DestStudentuGrupesGridView.Columns.Count)
            {
                if (DestStudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS") || DestStudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("Kodas")
                    || DestStudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("STUDENTUGRUPESID") || DestStudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("STDDALYKOID"))
                {
                    DestStudentuGrupesGridView.Columns[i].Visible = true;
                }
                else
                {
                    DestStudentuGrupesGridView.Columns[i].Visible = false;
                }
                i++;
            }

            DestStudentuGrupesGridView.Columns[0].HeaderText = "Studentų grupės pavadinimas";
            DestStudentuGrupesGridView.Columns[1].HeaderText = "Studentų grupės kodas";
        }

        private void DestStudentuGrupesGridView_DoubleClick(object sender, EventArgs e)
        {
            if (DestStudentuGrupesGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)DestStudentuGrupesGridView.DataSource).DefaultView[DestStudentuGrupesGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StudentuGrupesId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                        PasirinktiStudenta v = new PasirinktiStudenta(dh, Id, std, dest);
                        v.ShowDialog();
                    }
                }
            }
        }

        private void Pasirinkti_Click(object sender, EventArgs e)
        {
            if (DestStudentuGrupesGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)DestStudentuGrupesGridView.DataSource).DefaultView[DestStudentuGrupesGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StudentuGrupesId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                        PasirinktiStudenta v = new PasirinktiStudenta(dh, Id, std, dest);
                        v.ShowDialog();
                    }
                }
            }
        }
    }
}
