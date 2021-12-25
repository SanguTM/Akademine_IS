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
    public partial class StudentuGrupesEdit : Form
    {
        string EditUserId;
        string vtPavad = "";
        int VartotojuTipaiId = 0;
        t_DataHandler dh;
        public StudentuGrupesEdit(t_DataHandler DataHandler, int EditUserId, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_StudentuGrupes = new t_StoredProc(DataHandler, "uspv_StudentuGrupes");
            uspv_StudentuGrupes.ParamByName("@piStudentuGrupesId").Value = EditUserId;
            uspv_StudentuGrupes.ParamByName("@piEditForm").Value = 1;
            DataTable table_uspv_StudentuGrupes = uspv_StudentuGrupes.Open();

            InitializeComponent();

            StudentuGrupesIdBox.Text = table_uspv_StudentuGrupes.Rows[0][0].ToString();
            KodasBox.Text = table_uspv_StudentuGrupes.Rows[0][1].ToString();
            PavadinimasBox.Text = table_uspv_StudentuGrupes.Rows[0][2].ToString();
        }

        private void PriskirtiStudenta_Click(object sender, EventArgs e)
        {
            PriskirtiStudenta ps = new PriskirtiStudenta(dh, Convert.ToInt32(StudentuGrupesIdBox.Text));
            ps.ShowDialog();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspu_StudentuGrupes = new t_StoredProc(dh, "uspu_StudentuGrupes");

            uspu_StudentuGrupes.ParamByName("@piStudentuGrupesId").Value = Convert.ToInt32(StudentuGrupesIdBox.Text);
            uspu_StudentuGrupes.ParamByName("@piKodas").Value = KodasBox.Text;
            uspu_StudentuGrupes.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;

            uspu_StudentuGrupes.Execute();
            this.DialogResult = DialogResult.OK;
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PriskirtiDalykus_Click(object sender, EventArgs e)
        {
            PriskirtiStudentuGrupesDalykus pd = new PriskirtiStudentuGrupesDalykus(dh, Convert.ToInt32(StudentuGrupesIdBox.Text));
            pd.ShowDialog();
        }
    }
}
