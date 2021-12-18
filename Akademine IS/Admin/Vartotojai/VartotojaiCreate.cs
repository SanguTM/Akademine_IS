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
        int AsmuoId = 0;
        string Vardas = "";
        string Pavarde = "";
        string poValue;
        string vtPavad = "";
        int VartotojuTipaiId = 0;
        t_DataHandler dh;
        
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = LENOVO; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");

        public VartotojaiCreate(t_DataHandler DataHandler)
        {
            dh = DataHandler;
            InitializeComponent();
        }
        private void Isaugoti_Click(object sender, EventArgs e)
        {
            
            t_StoredProc uspi_Vartotojai = new t_StoredProc(dh, "uspi_Vartotojai");
            uspi_Vartotojai.ParamByName("@piKodas").Value = KodasBox.Text;
            uspi_Vartotojai.ParamByName("@piPavadinimas").Value = PavadinimasBox.Text;
            uspi_Vartotojai.ParamByName("@piVartotojuTipaiId").Value = VartotojuTipaiId;
            uspi_Vartotojai.ParamByName("@piAsmuoId").Value = AsmuoId;
            uspi_Vartotojai.ParamByName("@piSlaptazodis").Value = SlaptazodisBox.Text;

            if (checkBox_ArAktyvus.Checked)
            {
                uspi_Vartotojai.ParamByName("@piArAktyvus").Value = 1;
            }
            else if (!checkBox_ArAktyvus.Checked)
            {
                uspi_Vartotojai.ParamByName("@piArAktyvus").Value = 0;
            }           

            uspi_Vartotojai.Execute();

            if (!uspi_Vartotojai.ParamByName("@poValue").Value.ToString().Equals("")) ;
            {
                poValue = uspi_Vartotojai.ParamByName("@poValue").Value.ToString();
            }

            MessageBox.Show("Jusu slaptazodis: " + poValue);
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
