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
    public partial class StudijuDalykaiCreate : Form
    {
        string poValue;
        string vtPavad = "";
        int VartotojuTipaiId = 0;
        t_DataHandler dh;
        public StudijuDalykaiCreate(t_DataHandler DataHandler)
        {
            dh = DataHandler;
            InitializeComponent();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspi_StudijuDalykai = new t_StoredProc(dh, "uspi_StudijuDalykai");
            uspi_StudijuDalykai.ParamByName("@piKodas").Value = KodasBox.Text;
            uspi_StudijuDalykai.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;
            uspi_StudijuDalykai.ParamByName("@piAprasymas").Value = AprasymasBox.Text;

            uspi_StudijuDalykai.Execute();
            Close();
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
