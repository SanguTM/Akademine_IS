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
    public partial class StudijuDalykaiEdit : Form
    {
        string EditUserId;
        string vtPavad = "";
        int VartotojuTipaiId = 0;
        t_DataHandler dh;
        public StudijuDalykaiEdit(t_DataHandler DataHandler, int EditUserId, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_StudijuDalykai = new t_StoredProc(DataHandler, "uspv_StudijuDalykai");
            uspv_StudijuDalykai.ParamByName("@piStdDalykoId").Value = EditUserId;
            uspv_StudijuDalykai.ParamByName("@piEditForm").Value = 1;
            DataTable table_uspv_StudijuDalykai = uspv_StudijuDalykai.Open();

            InitializeComponent();

            StdDalykoIdBox.Text = table_uspv_StudijuDalykai.Rows[0][0].ToString();
            KodasBox.Text = table_uspv_StudijuDalykai.Rows[0][1].ToString();
            PavadinimasBox.Text = table_uspv_StudijuDalykai.Rows[0][2].ToString();
            AprasymasBox.Text = table_uspv_StudijuDalykai.Rows[0][3].ToString();
        }

        private void PriskirtiDestytoja_Click(object sender, EventArgs e)
        {
            PriskirtiDestytoja pd = new PriskirtiDestytoja(dh, Convert.ToInt32(StdDalykoIdBox.Text));
            pd.ShowDialog();
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspu_StudijuDalykai = new t_StoredProc(dh, "uspu_StudijuDalykai");

            uspu_StudijuDalykai.ParamByName("@piStdDalykoId").Value = Convert.ToInt32(StdDalykoIdBox.Text);
            uspu_StudijuDalykai.ParamByName("@piKodas").Value = KodasBox.Text;
            uspu_StudijuDalykai.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;
            uspu_StudijuDalykai.ParamByName("@piAprasymas").Value = Convert.ToInt32(AprasymasBox.Text);

            uspu_StudijuDalykai.Execute();
            this.DialogResult = DialogResult.OK;
        }
    }
}
