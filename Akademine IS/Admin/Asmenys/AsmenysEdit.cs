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
    public partial class AsmenysEdit : Form
    {
        t_DataHandler dh;
        public AsmenysEdit(t_DataHandler DataHandler, int EditUserId, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_Asmenys = new t_StoredProc(DataHandler, "uspv_Asmenys");
            uspv_Asmenys.ParamByName("@piAsmuoId").Value = EditUserId;
            uspv_Asmenys.ParamByName("@piEditForm").Value = 1;
            DataTable table_uspv_Asmenys = uspv_Asmenys.Open();

            InitializeComponent();

            AsmuoIdBox.Text = table_uspv_Asmenys.Rows[0][0].ToString();
            VardasBox.Text = table_uspv_Asmenys.Rows[0][1].ToString();
            PavardeBox.Text = table_uspv_Asmenys.Rows[0][2].ToString();
            AmziusBox.Text = table_uspv_Asmenys.Rows[0][3].ToString();
            AsmensKodasBox.Text = table_uspv_Asmenys.Rows[0][4].ToString();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspu_Asmenys = new t_StoredProc(dh, "uspu_Asmenys");

            uspu_Asmenys.ParamByName("@piAsmuoId").Value = Convert.ToInt32(AsmuoIdBox.Text);
            uspu_Asmenys.ParamByName("@piVardas").Value = VardasBox.Text;
            uspu_Asmenys.ParamByName("@piPavarde").Value = PavardeBox.Text;
            uspu_Asmenys.ParamByName("@piAmzius").Value = Convert.ToInt32(AmziusBox.Text);
            uspu_Asmenys.ParamByName("@piAsmensKodas").Value = AsmensKodasBox.Text;

            uspu_Asmenys.Execute();
            Close();
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
