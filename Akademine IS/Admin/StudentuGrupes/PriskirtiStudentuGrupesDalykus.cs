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
    public partial class PriskirtiStudentuGrupesDalykus : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        public int StdDalykoId = 0;
        public string Kodas = "";
        public string Pavadinimas = "";
        public string Aprasymas = "";
        string vtPavad = "";
        int std;
        public PriskirtiStudentuGrupesDalykus(t_DataHandler DataHandler, int StudentuGrupesId)
        {
            std = StudentuGrupesId;
            dh = DataHandler;
            t_StoredProc uspv_StudentuGrupesDalykai = new t_StoredProc(DataHandler, "uspv_StudentuGrupesDalykai");
            uspv_StudentuGrupesDalykai.ParamByName("@piPriskirtiGrupe").Value = 1;
            uspv_StudentuGrupesDalykai.ParamByName("@piStudentuGrupesId").Value = StudentuGrupesId;
            DataTable table_uspv_StudentuGrupesStudentai = uspv_StudentuGrupesDalykai.Open();

            InitializeComponent();
            PriskirtiStudentoGrupesDalykusGridView.DataSource = GetStudentai(StudentuGrupesId);

            int i = 0;
            while (i < PriskirtiStudentoGrupesDalykusGridView.Columns.Count)
            {
                if (PriskirtiStudentoGrupesDalykusGridView.Columns[i].Name.ToUpper().Equals("KODAS") || PriskirtiStudentoGrupesDalykusGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS")
                    || PriskirtiStudentoGrupesDalykusGridView.Columns[i].Name.ToUpper().Equals("STUDENTUGRUPESID") || PriskirtiStudentoGrupesDalykusGridView.Columns[i].Name.ToUpper().Equals("STDDALYKAIID"))
                {
                    PriskirtiStudentoGrupesDalykusGridView.Columns[i].Visible = true;
                }
                else
                {
                    PriskirtiStudentoGrupesDalykusGridView.Columns[i].Visible = false;
                }
                i++;
            }

            PriskirtiStudentoGrupesDalykusGridView.Columns[0].HeaderText = "Grupės pavadinimas";
            PriskirtiStudentoGrupesDalykusGridView.Columns[1].HeaderText = "Grupės kodas";
        }

        private DataTable GetStudentai(int StudentuGrupesId)
        {
            t_StoredProc uspv_StudentuGrupesDalykai = new t_StoredProc(dh, "uspv_StudentuGrupesDalykai");
            uspv_StudentuGrupesDalykai.ParamByName("@piPriskirtiStudenta").Value = 1;
            uspv_StudentuGrupesDalykai.ParamByName("@piStudentuGrupesId").Value = StudentuGrupesId;
            return uspv_StudentuGrupesDalykai.Open();
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            DalykaiSelection dal = new DalykaiSelection(dh);
            if (dal.ShowDialog() == DialogResult.OK)
            {
                StdDalykoId = dal.StdDalykoId;
                Kodas = dal.Kodas;
                Pavadinimas = dal.Pavadinimas;
                Aprasymas = dal.Aprasymas;

                t_StoredProc uspi_StudentuGrupesStudentai = new t_StoredProc(dh, "uspi_StudentuGrupesDalykai");
                uspi_StudentuGrupesStudentai.ParamByName("@piStudentuGrupesId").Value = std;
                uspi_StudentuGrupesStudentai.ParamByName("@piStdDalykoId").Value = StdDalykoId;

                uspi_StudentuGrupesStudentai.Execute();
            }
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {

        }

        private void Istrinti_Click(object sender, EventArgs e)
        {
            if (PriskirtiStudentoGrupesDalykusGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)PriskirtiStudentoGrupesDalykusGridView.DataSource).DefaultView[PriskirtiStudentoGrupesDalykusGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StdDalykoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StdDalykoId"]);
                        int StudentuGrupesId = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                        t_StoredProc uspd_StudentuGrupesDalykai = new t_StoredProc(dh, "uspd_StudentuGrupesDalykai");
                        uspd_StudentuGrupesDalykai.ParamByName("@piStudentuGrupesId").Value = Id;
                        uspd_StudentuGrupesDalykai.ParamByName("@piStudentoId").Value = StudentuGrupesId;
                        uspd_StudentuGrupesDalykai.Execute();
                    }
                }
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {

        }

        private void PriskirtiStudentoGrupesDalykusGridView_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
