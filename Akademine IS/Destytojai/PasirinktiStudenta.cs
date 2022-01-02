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
    public partial class PasirinktiStudenta : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int std;
        int stddalykaiId;
        int dest;
        public PasirinktiStudenta(t_DataHandler DataHandler, int StudentoGrupesId, int StdDalykoId, int DestytojaiId)
        {
            std = StudentoGrupesId;
            dh = DataHandler;
            stddalykaiId = StdDalykoId;
            dest = DestytojaiId;
            t_StoredProc uspv_StudentuGrupesStudentai = new t_StoredProc(DataHandler, "uspv_StudentuGrupesStudentai");
            uspv_StudentuGrupesStudentai.ParamByName("@piPriskirtiStudenta").Value = 1;
            uspv_StudentuGrupesStudentai.ParamByName("@piStudentuGrupesId").Value = StudentoGrupesId;
            DataTable table_uspv_StudentuGrupesStudentai = uspv_StudentuGrupesStudentai.Open();

            InitializeComponent();
            DestStudentaiGridView.DataSource = table_uspv_StudentuGrupesStudentai;

            int i = 0;
            while (i < DestStudentaiGridView.Columns.Count)
            {
                if (DestStudentaiGridView.Columns[i].Name.ToUpper().Equals("VARDAS") || DestStudentaiGridView.Columns[i].Name.ToUpper().Equals("PAVARDE")
                    || DestStudentaiGridView.Columns[i].Name.ToUpper().Equals("STUDENTOID"))
                {
                    DestStudentaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    DestStudentaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

            DestStudentaiGridView.Columns[0].HeaderText = "Studento vardas";
            DestStudentaiGridView.Columns[1].HeaderText = "Studento pavardė";
        }

        private void DestStudentaiGridView_DoubleClick(object sender, EventArgs e)
        {
            if (DestStudentaiGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)DestStudentaiGridView.DataSource).DefaultView[DestStudentaiGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StudentoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StudentoId"]);
                        StudentoPazymiai v = new StudentoPazymiai(dh, Id, stddalykaiId, dest);
                        v.ShowDialog();
                    }
                }
            }
        }
    }
}
