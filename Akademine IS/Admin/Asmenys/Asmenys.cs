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
    public partial class Asmenys : Form
    {
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = LENOVO; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");

        private string usertype;
        private string user;
        t_DataHandler dh;

        public Asmenys(t_DataHandler DataHandler, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_Asmenys = new t_StoredProc(DataHandler, "uspv_Asmenys");
            DataTable table_uspv_Asmenys = uspv_Asmenys.Open();

            InitializeComponent();
            AsmenysGridView.DataSource = GetAsmenys();

            int i = 0;
            while (i < AsmenysGridView.Columns.Count)
            {
                if (AsmenysGridView.Columns[i].Name.ToUpper().Equals("VARDAS") || AsmenysGridView.Columns[i].Name.ToUpper().Equals("PAVARDE")
                    || AsmenysGridView.Columns[i].Name.ToUpper().Equals("AMZIUS") || AsmenysGridView.Columns[i].Name.ToUpper().Equals("ASMENSKODAS")
                    || AsmenysGridView.Columns[i].Name.ToUpper().Equals("ASMUOID"))
                {
                    AsmenysGridView.Columns[i].Visible = true;
                }
                else
                {
                    AsmenysGridView.Columns[i].Visible = false;
                }
                i++;
            }

            AsmenysGridView.Columns[0].HeaderText = "Asmuo Id";
            AsmenysGridView.Columns[1].HeaderText = "Vardas";
            AsmenysGridView.Columns[2].HeaderText = "Pavardė";
            AsmenysGridView.Columns[3].HeaderText = "Amžius";
            AsmenysGridView.Columns[4].HeaderText = "Asmens kodas";

            usertype = UserType;
            user = User;

        }

        private DataTable GetAsmenys()
        {
            t_StoredProc uspv_Asmenys = new t_StoredProc(dh, "uspv_Asmenys");
            return uspv_Asmenys.Open();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)AsmenysGridView.DataSource).DefaultView[AsmenysGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["AsmuoId"] != null)
                {
                    int Id = Convert.ToInt32(drv.Row["AsmuoId"]);
                    AsmenysEdit ae = new AsmenysEdit(dh, Id, user, usertype);
                    if (ae.ShowDialog() == DialogResult.OK)
                    {
                        AsmenysGridView.DataSource = GetAsmenys();
                    };
                }
            }
        }

        private void AsmenysGridView_DoubleClick(object sender, EventArgs e)
        {
            if (AsmenysGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)AsmenysGridView.DataSource).DefaultView[AsmenysGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["AsmuoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["AsmuoId"]);
                        AsmenysEdit ae = new AsmenysEdit(dh, Id, user, usertype);
                        if (ae.ShowDialog() == DialogResult.OK)
                        {
                            AsmenysGridView.DataSource = GetAsmenys();
                        }; ;
                    }
                }
            }
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            AsmenysCreate ae = new AsmenysCreate(dh);
            if (ae.ShowDialog() == DialogResult.OK)
            {
                AsmenysGridView.DataSource = GetAsmenys();
            }; ;
        }

        private void Istrinti_Click(object sender, EventArgs e)
        {
            if (AsmenysGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)AsmenysGridView.DataSource).DefaultView[AsmenysGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["AsmuoId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["AsmuoId"]);
                        t_StoredProc uspd_Asmenys = new t_StoredProc(dh, "uspd_Asmenys");
                        uspd_Asmenys.ParamByName("@piAsmuoId").Value = Id;
                        uspd_Asmenys.Execute();
                    }
                }
            }
        }
    }
}
