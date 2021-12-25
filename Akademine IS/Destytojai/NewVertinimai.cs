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
    public partial class NewVertinimai : Form
    {
        int std;
        int stddalykaiId;
        int dest;
        t_DataHandler dh;
        public NewVertinimai(t_DataHandler DataHandler, int StudentoId, int StdDalykoId, int DestytojaiId)
        {
            std = StudentoId;
            dh = DataHandler;
            stddalykaiId = StdDalykoId;
            dest = DestytojaiId;
            dh = DataHandler;
            InitializeComponent();
        }

        private void Isaugoti_Click(object sender, EventArgs e)
        {
            t_StoredProc uspi_DalykoVertinimai = new t_StoredProc(dh, "uspi_DalykoVertinimai");
            uspi_DalykoVertinimai.ParamByName("@piStdDalykoId").Value = stddalykaiId;
            uspi_DalykoVertinimai.ParamByName("@piStudentaiId").Value = std;
            uspi_DalykoVertinimai.ParamByName("@piDestytojaiId").Value = dest;
            uspi_DalykoVertinimai.ParamByName("@piVertinimas").Value = Convert.ToInt32(PazymysBox.Text);
            uspi_DalykoVertinimai.ParamByName("@piPastaba").Value = PastabaBox.Text;

            uspi_DalykoVertinimai.Execute();
            this.DialogResult = DialogResult.OK;
        }

        private void Uzdaryti_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
