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
    public partial class PriskirtiStudenta : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int std;
        public PriskirtiStudenta(t_DataHandler DataHandler, int StudentuGrupesId)
        {
            std = StudentuGrupesId;
            dh = DataHandler;
            t_StoredProc uspv_StudentuGrupesStudentai = new t_StoredProc(DataHandler, "uspv_StudentuGrupesStudentai");
            uspv_StudentuGrupesStudentai.ParamByName("@piPriskirtiStudenta").Value = 1;
            uspv_StudentuGrupesStudentai.ParamByName("@piStudentuGrupesId").Value = StudentuGrupesId;
            DataTable table_uspv_StudentuGrupesStudentai = uspv_StudentuGrupesStudentai.Open();

            InitializeComponent();
            PriskirtiStudentaGridView.DataSource = GetStudentai(StudentuGrupesId);

            int i = 0;
            while (i < PriskirtiStudentaGridView.Columns.Count)
            {
                if (PriskirtiStudentaGridView.Columns[i].Name.ToUpper().Equals("VARDAS") || PriskirtiStudentaGridView.Columns[i].Name.ToUpper().Equals("PAVARDE")
                    || PriskirtiStudentaGridView.Columns[i].Name.ToUpper().Equals("STUDENTUGRUPESID") || PriskirtiStudentaGridView.Columns[i].Name.ToUpper().Equals("STUDENTAIID"))
                {
                    PriskirtiStudentaGridView.Columns[i].Visible = true;
                }
                else
                {
                    PriskirtiStudentaGridView.Columns[i].Visible = false;
                }
                i++;
            }

            PriskirtiStudentaGridView.Columns[0].HeaderText = "Studento vardas";
            PriskirtiStudentaGridView.Columns[1].HeaderText = "Studento Pavardė";
        }

        private DataTable GetStudentai(int StudentuGrupesId)
        {
            t_StoredProc uspv_StudentuGrupesStudentai = new t_StoredProc(dh, "uspv_StudentuGrupesStudentai");
            uspv_StudentuGrupesStudentai.ParamByName("@piPriskirtiStudenta").Value = 1;
            uspv_StudentuGrupesStudentai.ParamByName("@piStudentuGrupesId").Value = StudentuGrupesId;
            return uspv_StudentuGrupesStudentai.Open();
        }


        private void PriskirtiStudentaGridView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            StudentaiSelection asms = new StudentaiSelection(dh);
            if (asms.ShowDialog() == DialogResult.OK)
            {
                AsmuoId = asms.AsmenysId;
                Vardas = asms.Vardas;
                Pavarde = asms.Pavarde;

                t_StoredProc uspi_StudentuGrupesStudentai = new t_StoredProc(dh, "uspi_StudentuGrupesStudentai");
                uspi_StudentuGrupesStudentai.ParamByName("@piStudentuGrupesId").Value = std;
                uspi_StudentuGrupesStudentai.ParamByName("@piStudentoId").Value = AsmuoId;

                uspi_StudentuGrupesStudentai.Execute();
                PriskirtiStudentaGridView.DataSource = GetStudentai(std);
            }
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {

        }

        private void Istrinti_Click(object sender, EventArgs e)
        {
            if (PriskirtiStudentaGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)PriskirtiStudentaGridView.DataSource).DefaultView[PriskirtiStudentaGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StdDalykoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                        int StudentaiId = Convert.ToInt32(drv.Row["StudentoId"]);
                        t_StoredProc uspd_DestytojuPaskaitos = new t_StoredProc(dh, "uspd_StudentuGrupesStudentai");
                        uspd_DestytojuPaskaitos.ParamByName("@piStudentuGrupesId").Value = Id;
                        uspd_DestytojuPaskaitos.ParamByName("@piStudentoId").Value = StudentaiId;
                        uspd_DestytojuPaskaitos.Execute();
                        PriskirtiStudentaGridView.DataSource = GetStudentai(Id);
                    }
                }
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
