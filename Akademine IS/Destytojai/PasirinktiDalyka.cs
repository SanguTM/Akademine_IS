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
    public partial class PasirinktiDalyka : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int dest;
        public PasirinktiDalyka(t_DataHandler DataHandler, int DestytojaiId)
        {
            dest = DestytojaiId;
            dh = DataHandler;
            t_StoredProc uspv_DestytojuPaskaitos = new t_StoredProc(DataHandler, "uspv_DestytojuPaskaitos");
            uspv_DestytojuPaskaitos.ParamByName("@piPriskirtiDestytojus").Value = 0;
            uspv_DestytojuPaskaitos.ParamByName("@piDestytojaiId").Value = DestytojaiId;
            DataTable table_uspv_DestytojuPaskaitos = uspv_DestytojuPaskaitos.Open();

            InitializeComponent();
            DestDalykaiGridView.DataSource = table_uspv_DestytojuPaskaitos;

            int i = 0;
            while (i < DestDalykaiGridView.Columns.Count)
            {
                if (DestDalykaiGridView.Columns[i].Name.ToUpper().Equals("STDDALYKOID") || DestDalykaiGridView.Columns[i].Name.ToUpper().Equals("DALYKOPAVAD")
                    || DestDalykaiGridView.Columns[i].Name.ToUpper().Equals("DALYKOKODAS") || DestDalykaiGridView.Columns[i].Name.ToUpper().Equals("DALYKOAPRASYMAS"))
                {
                    DestDalykaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    DestDalykaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

            DestDalykaiGridView.Columns[1].HeaderText = "Dalyko pavadinimas";
            DestDalykaiGridView.Columns[2].HeaderText = "Dalyko kodas";
            DestDalykaiGridView.Columns[3].HeaderText = "Dalyko aprašymas";
        }

        private void DestDalykaiGridView_DoubleClick(object sender, EventArgs e)
        {
            if (DestDalykaiGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)DestDalykaiGridView.DataSource).DefaultView[DestDalykaiGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StdDalykoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StdDalykoId"]);
                        PasirinktiStudentuGrupe v = new PasirinktiStudentuGrupe(dh, Id, dest);
                        v.ShowDialog();
                    }
                }
            }
        }
    }
}
