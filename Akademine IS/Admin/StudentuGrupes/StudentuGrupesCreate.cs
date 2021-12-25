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
    public partial class StudentuGrupesCreate : Form
    {
        string poValue;
        string vtPavad = "";
        int VartotojuTipaiId = 0;
        t_DataHandler dh;
        public StudentuGrupesCreate(t_DataHandler DataHandler)
        {
            dh = DataHandler;
            InitializeComponent();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspi_StudentuGrupes = new t_StoredProc(dh, "uspi_StudentuGrupes");
            uspi_StudentuGrupes.ParamByName("@piKodas").Value = KodasBox.Text;
            uspi_StudentuGrupes.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;

            uspi_StudentuGrupes.Execute();

            if (!uspi_StudentuGrupes.ParamByName("@poValue").Value.ToString().Equals("")) ;
            {
                poValue = uspi_StudentuGrupes.ParamByName("@poValue").Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PriskirtiStudenta_Click(object sender, EventArgs e)
        {
            PriskirtiStudenta ps = new PriskirtiStudenta(dh, Convert.ToInt32(poValue));
            ps.ShowDialog();
        }

        private void PriskirtiDalykus_Click(object sender, EventArgs e)
        {
            PriskirtiStudentuGrupesDalykus pd = new PriskirtiStudentuGrupesDalykus(dh, Convert.ToInt32(poValue));
        }
    }
}
