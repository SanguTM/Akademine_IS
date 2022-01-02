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
    public partial class PasirinktiStudentoDalyka : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int stud;
        public PasirinktiStudentoDalyka(t_DataHandler DataHandler, int StudentaiId)
        {
            stud = StudentaiId;
            dh = DataHandler;
            t_StoredProc uspv_StudentoDalykai = new t_StoredProc(DataHandler, "uspv_StudentoDalykai");
            uspv_StudentoDalykai.ParamByName("@piStudentaiId").Value = StudentaiId;
            DataTable table_uspv_DestytojuPaskaitos = uspv_StudentoDalykai.Open();

            InitializeComponent();
            StudDalykaiGridView.DataSource = table_uspv_DestytojuPaskaitos;

            int i = 0;
            while (i < StudDalykaiGridView.Columns.Count)
            {
                if (StudDalykaiGridView.Columns[i].Name.ToUpper().Equals("STDDALYKOID") || StudDalykaiGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS")
                    || StudDalykaiGridView.Columns[i].Name.ToUpper().Equals("KODAS") || StudDalykaiGridView.Columns[i].Name.ToUpper().Equals("APRASYMAS"))
                {
                    StudDalykaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    StudDalykaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

            StudDalykaiGridView.Columns[1].HeaderText = "Dalyko pavadinimas";
            StudDalykaiGridView.Columns[2].HeaderText = "Dalyko kodas";
            StudDalykaiGridView.Columns[3].HeaderText = "Dalyko aprašymas";
        }

        private void StudDalykaiGridView_DoubleClick(object sender, EventArgs e)
        {
            if (StudDalykaiGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)StudDalykaiGridView.DataSource).DefaultView[StudDalykaiGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StdDalykoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StdDalykoId"]);
                        PerziuretiPazymi v = new PerziuretiPazymi(dh, stud, Id);
                        v.ShowDialog();
                    }
                }
            }
        }
    }
}
