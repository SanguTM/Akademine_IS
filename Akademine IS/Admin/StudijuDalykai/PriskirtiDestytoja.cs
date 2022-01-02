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
    public partial class PriskirtiDestytoja : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int std;
        public PriskirtiDestytoja(t_DataHandler DataHandler, int StdDalykoId)
        {
            std = StdDalykoId;
            dh = DataHandler;
            t_StoredProc uspv_DestytojuPaskaitos = new t_StoredProc(DataHandler, "uspv_DestytojuPaskaitos");
            uspv_DestytojuPaskaitos.ParamByName("@piPriskirtiDestytojus").Value = 1;
            uspv_DestytojuPaskaitos.ParamByName("@piStdDalykoId").Value = StdDalykoId;
            DataTable table_uspv_DestytojuPaskaitos = uspv_DestytojuPaskaitos.Open();

            InitializeComponent();
            DestytojuPaskaitosGridView.DataSource = GetDestytojai(StdDalykoId);

            int i = 0;
            while (i < DestytojuPaskaitosGridView.Columns.Count)
            {
                if (DestytojuPaskaitosGridView.Columns[i].Name.ToUpper().Equals("VARDAS") || DestytojuPaskaitosGridView.Columns[i].Name.ToUpper().Equals("PAVARDE")
                    || DestytojuPaskaitosGridView.Columns[i].Name.ToUpper().Equals("STDDALYKAIID") || DestytojuPaskaitosGridView.Columns[i].Name.ToUpper().Equals("DESTYTOJAIID"))
                {
                    DestytojuPaskaitosGridView.Columns[i].Visible = true;
                }
                else
                {
                    DestytojuPaskaitosGridView.Columns[i].Visible = false;
                }
                i++;
            }

            DestytojuPaskaitosGridView.Columns[0].HeaderText = "Dėstytojo vardas";
            DestytojuPaskaitosGridView.Columns[1].HeaderText = "Dėstytojo Pavardė";
        }
        private DataTable GetDestytojai(int StdDalykoId)
        {
            t_StoredProc uspv_DestytojuPaskaitos = new t_StoredProc(dh, "uspv_DestytojuPaskaitos");
            uspv_DestytojuPaskaitos.ParamByName("@piPriskirtiDestytojus").Value = 1;
            uspv_DestytojuPaskaitos.ParamByName("@piStdDalykoId").Value = StdDalykoId;
            return uspv_DestytojuPaskaitos.Open();
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            DestytojaiSelection asms = new DestytojaiSelection(dh);
            if (asms.ShowDialog() == DialogResult.OK)
            {
                AsmuoId = asms.AsmenysId;
                Vardas = asms.Vardas;
                Pavarde = asms.Pavarde;

                t_StoredProc uspi_DestytojuPaskaitos = new t_StoredProc(dh, "uspi_DestytojuPaskaitos");
                uspi_DestytojuPaskaitos.ParamByName("@piStdDalykoId").Value = std;
                uspi_DestytojuPaskaitos.ParamByName("@piDestytojaiId").Value = AsmuoId;

                uspi_DestytojuPaskaitos.Execute();
                DestytojuPaskaitosGridView.DataSource = GetDestytojai(std);
            }
        }
        private void Istrinti_Click(object sender, EventArgs e)
        {
            if (DestytojuPaskaitosGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)DestytojuPaskaitosGridView.DataSource).DefaultView[DestytojuPaskaitosGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StdDalykoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StdDalykoId"]);
                        int DestytojaiId = Convert.ToInt32(drv.Row["DestytojaiId"]);
                        t_StoredProc uspd_DestytojuPaskaitos = new t_StoredProc(dh, "uspd_DestytojuPaskaitos");
                        uspd_DestytojuPaskaitos.ParamByName("@piStdDalykoId").Value = Id;
                        uspd_DestytojuPaskaitos.ParamByName("@piDestytojaiId").Value = DestytojaiId;
                        uspd_DestytojuPaskaitos.Execute();
                        DestytojuPaskaitosGridView.DataSource = GetDestytojai(Id);
                    }
                }
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DestytojuPaskaitosGridView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {

        }
    }
}
