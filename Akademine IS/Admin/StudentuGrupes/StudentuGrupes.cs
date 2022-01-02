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

    /* Studentu grupes 
     *      Studentai
     *      Studentu dalykus*/
    public partial class StudentuGrupes : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        public StudentuGrupes(t_DataHandler DataHandler, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_StudentuGrupes = new t_StoredProc(DataHandler, "uspv_StudentuGrupes");
            DataTable table_uspv_StudentuGrupes = uspv_StudentuGrupes.Open();

            InitializeComponent();
            StudentuGrupesGridView.DataSource = GetStudentuGrupes();

            int i = 0;
            while (i < StudentuGrupesGridView.Columns.Count)
            {
                if (StudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("KODAS") || StudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("STDDALYKOID")
                    || StudentuGrupesGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS"))
                {
                    StudentuGrupesGridView.Columns[i].Visible = true;
                }
                else
                {
                    StudentuGrupesGridView.Columns[i].Visible = false;
                }
                i++;
            }

            StudentuGrupesGridView.Columns[0].HeaderText = "Studentų grupės Id";
            StudentuGrupesGridView.Columns[1].HeaderText = "Kodas";
            StudentuGrupesGridView.Columns[2].HeaderText = "Pavadinimas";

            usertype = UserType;
            user = User;
        }

        private DataTable GetStudentuGrupes()
        {
            t_StoredProc uspv_StudentuGrupes = new t_StoredProc(dh, "uspv_StudentuGrupes");
            return uspv_StudentuGrupes.Open();
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            StudentuGrupesCreate sgc = new StudentuGrupesCreate(dh);
            if (sgc.ShowDialog() == DialogResult.OK)
            {
                StudentuGrupesGridView.DataSource = GetStudentuGrupes();
            };
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudentuGrupesGridView.DataSource).DefaultView[StudentuGrupesGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StudentuGrupesId"] != null)
                {
                    int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                    StudentuGrupesEdit ve = new StudentuGrupesEdit(dh, Id, user, usertype);
                    if (ve.ShowDialog() == DialogResult.OK)
                    {
                        StudentuGrupesGridView.DataSource = GetStudentuGrupes();
                    };
                }
            }
        }

        private void Istrinti_Click(object sender, EventArgs e)
        {
            if (StudentuGrupesGridView.SelectedCells.Count > 0)
            {
                DataRowView drv = ((DataTable)StudentuGrupesGridView.DataSource).DefaultView[StudentuGrupesGridView.SelectedCells[0].RowIndex];
                if (drv != null)
                {
                    if (drv.Row["StudentuGrupesId"] != null)
                    {
                        int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                        t_StoredProc uspd_StudentuGrupes = new t_StoredProc(dh, "uspd_StudentuGrupes");
                        uspd_StudentuGrupes.ParamByName("@piStudentuGrupesId").Value = Id;
                        uspd_StudentuGrupes.Execute();
                        StudentuGrupesGridView.DataSource = GetStudentuGrupes();
                    }
                }
            }
        }

        private void PriskirtiStudentus_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudentuGrupesGridView.DataSource).DefaultView[StudentuGrupesGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StudentuGrupesId"] != null)
                {
                    int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                    PriskirtiStudenta pd = new PriskirtiStudenta(dh, Id);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        StudentuGrupesGridView.DataSource = GetStudentuGrupes();
                    };
                }
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StudentuGrupesGridView_DoubleClick(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudentuGrupesGridView.DataSource).DefaultView[StudentuGrupesGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StudentuGrupesId"] != null)
                {
                    int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                    StudentuGrupesEdit ve = new StudentuGrupesEdit(dh, Id, user, usertype);
                    if (ve.ShowDialog() == DialogResult.OK)
                    {
                        StudentuGrupesGridView.DataSource = GetStudentuGrupes();
                    };
                }
            }
        }

        private void PriskirtiDalykus_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudentuGrupesGridView.DataSource).DefaultView[StudentuGrupesGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StudentuGrupesId"] != null)
                {
                    int Id = Convert.ToInt32(drv.Row["StudentuGrupesId"]);
                    PriskirtiStudentuGrupesDalykus pd = new PriskirtiStudentuGrupesDalykus(dh, Id);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        StudentuGrupesGridView.DataSource = GetStudentuGrupes();
                    };
                }
            }
        }
    }
}
