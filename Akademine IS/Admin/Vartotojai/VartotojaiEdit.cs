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
    public partial class VartotojaiEdit : Form
    {
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = LENOVO; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string vtPavad = "";
        int VartotojuTipaiId = 0;

        t_DataHandler dh;
        public VartotojaiEdit(t_DataHandler DataHandler, int EditUserId, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_Vartotojai = new t_StoredProc(DataHandler, "uspv_Vartotojai");
            uspv_Vartotojai.ParamByName("@piVartotojaiId").Value = EditUserId;
            uspv_Vartotojai.ParamByName("@piEditForm").Value = 1;
            DataTable table_uspv_Vartotojai = uspv_Vartotojai.Open();

            InitializeComponent();

            VartotojaiIdBox.Text = table_uspv_Vartotojai.Rows[0][0].ToString();
            KodasBox.Text = table_uspv_Vartotojai.Rows[0][1].ToString();
            PavadinimasBox.Text = table_uspv_Vartotojai.Rows[0][2].ToString();
            VartotojoTipasBox.Text = table_uspv_Vartotojai.Rows[0][3].ToString();
            AsmuoBox.Text = table_uspv_Vartotojai.Rows[0][4].ToString();
            SlaptazodisBox.Text = table_uspv_Vartotojai.Rows[0][5].ToString();
            checkBox_ArAktyvus.Checked = table_uspv_Vartotojai.Rows[0]["ArAktyvus"] == DBNull.Value ? false : Convert.ToInt32(table_uspv_Vartotojai.Rows[0]["ArAktyvus"]) == 0 ? false : true;

            AsmuoId = Convert.ToInt32(table_uspv_Vartotojai.Rows[0][7]);
            VartotojuTipaiId = Convert.ToInt32(table_uspv_Vartotojai.Rows[0][8]);

        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspu_Vartotojai = new t_StoredProc(dh, "uspu_Vartotojai");
            
            uspu_Vartotojai.ParamByName("@piVartotojaiId").Value = Convert.ToInt32(VartotojaiIdBox.Text);
            uspu_Vartotojai.ParamByName("@piKodas").Value = KodasBox.Text;
            uspu_Vartotojai.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;
            uspu_Vartotojai.ParamByName("@piVartotojuTipaiId").Value = VartotojuTipaiId;
            uspu_Vartotojai.ParamByName("@piAsmuoId").Value = AsmuoId;
            uspu_Vartotojai.ParamByName("@piSlaptazodis").Value = SlaptazodisBox.Text;
            uspu_Vartotojai.ParamByName("@piArAktyvus").Value = checkBox_ArAktyvus.Checked;

            uspu_Vartotojai.Execute();
            this.DialogResult = DialogResult.OK;
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AsmenysSelection_Click(object sender, EventArgs e)
        {
            AsmenysSelection asms = new AsmenysSelection(dh);
            if (asms.ShowDialog() == DialogResult.OK)
            {
                AsmuoId = asms.AsmenysId;
                Vardas = asms.Vardas;
                Pavarde = asms.Pavarde;
                AsmuoBox.Text = Vardas + " " + Pavarde;

            }
        }

        private void VartotojuTipaiSelection_Click(object sender, EventArgs e)
        {
            VartTipaiSelection vt = new VartTipaiSelection(dh);
            if (vt.ShowDialog() == DialogResult.OK)
            {
                VartotojuTipaiId = vt.VartotojuTipaiId;
                vtPavad = vt.Pavadinimas;
                VartotojoTipasBox.Text = vtPavad;

            }
        }
    }
}
