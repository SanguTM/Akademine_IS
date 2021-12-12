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
        static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        string AsmuoId;
        public VartotojaiEdit(int EditUserId, string UserType, string User)
        {
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
            ArAktyvusBox.Text = table_uspv_Vartotojai.Rows[0][6].ToString();

            AsmuoId = table_uspv_Vartotojai.Rows[0][7].ToString();

        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspu_Vartotojai = new t_StoredProc(DataHandler, "uspv_Vartotojai");
            uspu_Vartotojai.ParamByName("@piVartotojaiId").Value = VartotojaiIdBox.Text;
            uspu_Vartotojai.ParamByName("@piKodas").Value = KodasBox.Text;
            uspu_Vartotojai.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;
            uspu_Vartotojai.ParamByName("@piVartotojuTipas").Value = VartotojoTipasBox.Text;
            uspu_Vartotojai.ParamByName("@piAsmuoId").Value = AsmuoId;
            uspu_Vartotojai.ParamByName("@piSlaptazodis").Value = SlaptazodisBox.Text;
            uspu_Vartotojai.ParamByName("@piArAktyvus").Value = ArAktyvusBox.Text;

            uspu_Vartotojai.Execute();
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {

        }
    }
}
