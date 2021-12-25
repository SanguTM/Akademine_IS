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
    public partial class PerziuretiPazymi : Form
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
        public PerziuretiPazymi(t_DataHandler DataHandler, int StudentoId, int StdDalykoId)
        {
            std = StudentoId;
            dh = DataHandler;
            stddalykaiId = StdDalykoId;

            t_StoredProc uspv_DalykoVertinimai = new t_StoredProc(DataHandler, "uspv_DalykoVertinimai");
            uspv_DalykoVertinimai.ParamByName("@piDestytojas").Value = 0;
            uspv_DalykoVertinimai.ParamByName("@piStudentaiId").Value = StudentoId;
            uspv_DalykoVertinimai.ParamByName("@piStdDalykoId").Value = StdDalykoId;
            DataTable table_uspv_StudentuGrupesStudentai = uspv_DalykoVertinimai.Open();
            InitializeComponent();

            StudPazymiaiGridView.DataSource = table_uspv_StudentuGrupesStudentai;

            int i = 0;
            while (i < StudPazymiaiGridView.Columns.Count)
            {
                if (StudPazymiaiGridView.Columns[i].Name.ToUpper().Equals("VERTINIMAS") || StudPazymiaiGridView.Columns[i].Name.ToUpper().Equals("DATA")
                    || StudPazymiaiGridView.Columns[i].Name.ToUpper().Equals("PASTABA") || StudPazymiaiGridView.Columns[i].Name.ToUpper().Equals("DESTYTOJAS"))
                {
                    StudPazymiaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    StudPazymiaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

            StudPazymiaiGridView.Columns[0].HeaderText = "Vertinimas";
            StudPazymiaiGridView.Columns[1].HeaderText = "Data";
            StudPazymiaiGridView.Columns[1].HeaderText = "Pastaba";
            StudPazymiaiGridView.Columns[1].HeaderText = "Destytojas";
        }
    }
}
