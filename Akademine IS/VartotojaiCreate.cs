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
    public partial class VartotojaiCreate : Form
    {
        static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        public VartotojaiCreate()
        {
            InitializeComponent();
        }
        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspi_Vartotojai = new t_StoredProc(DataHandler, "uspi_Vartotojai");
            uspi_Vartotojai.ParamByName("@piKodas").Value = KodasBox.Text;
            uspi_Vartotojai.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;
            uspi_Vartotojai.ParamByName("@piVartotojuTipas").Value = VartotojoTipasBox.Text;
            uspi_Vartotojai.ParamByName("@piAsmuoId").Value = AsmuoBox.Text;
            uspi_Vartotojai.ParamByName("@piSlaptazodis").Value = SlaptazodisBox.Text;
            uspi_Vartotojai.ParamByName("@piArAktyvus").Value = ArAktyvusBox.Text;

            uspi_Vartotojai.Execute();
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {

        }
    }
}
