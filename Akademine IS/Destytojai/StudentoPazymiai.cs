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
    public partial class StudentoPazymiai : Form
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
        public StudentoPazymiai(t_DataHandler DataHandler, int StudentoId, int StdDalykoId, int DestytojaiId)
        {
            std = StudentoId;
            dh = DataHandler;
            stddalykaiId = StdDalykoId;
            dest = DestytojaiId;

            t_StoredProc uspv_DalykoVertinimai = new t_StoredProc(DataHandler, "uspv_DalykoVertinimai");
            uspv_DalykoVertinimai.ParamByName("@piDestytojas").Value = 1;
            uspv_DalykoVertinimai.ParamByName("@piStudentaiId").Value = StudentoId;
            uspv_DalykoVertinimai.ParamByName("@piStdDalykoId").Value = StdDalykoId;
            DataTable table_uspv_StudentuGrupesStudentai = uspv_DalykoVertinimai.Open();
            InitializeComponent();

            DestStudentoPazymiaiGridView.DataSource = table_uspv_StudentuGrupesStudentai;

            int i = 0;
            while (i < DestStudentoPazymiaiGridView.Columns.Count)
            {
                if (DestStudentoPazymiaiGridView.Columns[i].Name.ToUpper().Equals("VARTINIMAS") || DestStudentoPazymiaiGridView.Columns[i].Name.ToUpper().Equals("DATA")
                    || DestStudentoPazymiaiGridView.Columns[i].Name.ToUpper().Equals("PASTABA"))
                {
                    DestStudentoPazymiaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    DestStudentoPazymiaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

            DestStudentoPazymiaiGridView.Columns[0].HeaderText = "Vertinimas";
            DestStudentoPazymiaiGridView.Columns[1].HeaderText = "Data";
            DestStudentoPazymiaiGridView.Columns[2].HeaderText = "Pastaba";

        }

        private DataTable GetVertinimai(int StudentoId, int StdDalykoId)
        {
            t_StoredProc uspv_DalykoVertinimai = new t_StoredProc(dh, "uspv_DalykoVertinimai");
            uspv_DalykoVertinimai.ParamByName("@piDestytojas").Value = 1;
            uspv_DalykoVertinimai.ParamByName("@piStudentaiId").Value = StudentoId;
            uspv_DalykoVertinimai.ParamByName("@piStdDalykoId").Value = StdDalykoId;
            return uspv_DalykoVertinimai.Open();
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            NewVertinimai ae = new NewVertinimai(dh, std, stddalykaiId, dest);
            if (ae.ShowDialog() == DialogResult.OK)
            {
                DestStudentoPazymiaiGridView.DataSource = GetVertinimai(std, stddalykaiId);
            }; ;
        }
    }
}
