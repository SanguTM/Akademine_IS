﻿using System;
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
    public partial class StudijuDalykai : Form
    {
        private string usertype;
        private string user;
        t_DataHandler dh;
        public StudijuDalykai(t_DataHandler DataHandler, string UserType, string User)
        {
            dh = DataHandler;
            t_StoredProc uspv_StudijuDalykai = new t_StoredProc(DataHandler, "uspv_StudijuDalykai");
            DataTable table_uspv_StudijuDalykai = uspv_StudijuDalykai.Open();

            InitializeComponent();
            StudijuDalykaiGridView.DataSource = table_uspv_StudijuDalykai;

            int i = 0;
            while (i < StudijuDalykaiGridView.Columns.Count)
            {
                if (StudijuDalykaiGridView.Columns[i].Name.ToUpper().Equals("KODAS") || StudijuDalykaiGridView.Columns[i].Name.ToUpper().Equals("STDDALYKOID")
                    || StudijuDalykaiGridView.Columns[i].Name.ToUpper().Equals("PAVADINIMAS") || StudijuDalykaiGridView.Columns[i].Name.ToUpper().Equals("APRASYMAS"))
                {
                    StudijuDalykaiGridView.Columns[i].Visible = true;
                }
                else
                {
                    StudijuDalykaiGridView.Columns[i].Visible = false;
                }
                i++;
            }

            StudijuDalykaiGridView.Columns[0].HeaderText = "Studijų dalyko Id";
            StudijuDalykaiGridView.Columns[1].HeaderText = "Kodas";
            StudijuDalykaiGridView.Columns[2].HeaderText = "Pavadinimas";
            StudijuDalykaiGridView.Columns[3].HeaderText = "Aprašymas";

            usertype = UserType;
            user = User;
        }

        private void Naujas_Click(object sender, EventArgs e)
        {
            StudijuDalykaiCreate sdc = new StudijuDalykaiCreate(dh);
            sdc.ShowDialog();
        }

        private void Redaguoti_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudijuDalykaiGridView.DataSource).DefaultView[StudijuDalykaiGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StdDalykoId"] != null)
                {
                    int vartId = Convert.ToInt32(drv.Row["StdDalykoId"]);
                    VartotojaiEdit ve = new VartotojaiEdit(dh, vartId, user, usertype);
                    ve.ShowDialog();
                }
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StudijuDalykaiGridView_DoubleClick(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudijuDalykaiGridView.DataSource).DefaultView[StudijuDalykaiGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StdDalykoId"] != null)
                {
                    int vartId = Convert.ToInt32(drv.Row["StdDalykoId"]);
                    VartotojaiEdit ve = new VartotojaiEdit(dh, vartId, user, usertype);
                    ve.ShowDialog();
                }
            }
        }

        private void PriskirtiDestytojus_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataTable)StudijuDalykaiGridView.DataSource).DefaultView[StudijuDalykaiGridView.SelectedCells[0].RowIndex];
            if (drv != null)
            {
                if (drv.Row["StdDalykoId"] != null)
                {
                    int Id = Convert.ToInt32(drv.Row["StdDalykoId"]);
                    PriskirtiDestytoja pd = new PriskirtiDestytoja(dh, Id);
                    pd.ShowDialog();
                }
            }
        }
    }
}
