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
    public partial class AsmenysCreate : Form
    {
        string vtPavad = "";
        int VartotojuTipaiId = 0;
        t_DataHandler dh;
        public AsmenysCreate(t_DataHandler DataHandler)
        {
            dh = DataHandler;
            InitializeComponent();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspi_Asmenys = new t_StoredProc(dh, "uspi_Asmenys");
            uspi_Asmenys.ParamByName("@piVardas").Value = VardasBox.Text;
            uspi_Asmenys.ParamByName("@piPavarde").Value = PavardeBox.Text;
            uspi_Asmenys.ParamByName("@piAmzius").Value = Convert.ToInt32(AmziusBox.Text);
            uspi_Asmenys.ParamByName("@piAsmensKodas").Value = AsmensKodasBox.Text;

            uspi_Asmenys.Execute();
            this.DialogResult = DialogResult.OK;
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
