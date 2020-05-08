﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P3L_SKUY.myclass;
using MySql.Data.MySqlClient;

namespace P3L_SKUY.DashboardAdmin.Hewan
{
    public partial class JenisHewan : Form
    {
        Jeniss crud = new Jeniss();
        public JenisHewan()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            dataGridView1.Rows.Clear();
            DataSet jenis_hewan = crud.read_data();


            for (int i = 0; i < jenis_hewan.Tables["jenis_hewan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["id_jenis"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["jenis"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["harga"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["created_at"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["update_at"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch
            {
                MessageBox.Show("Dont Click The Header!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
        }

        private void btnAddJenis_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Hewan.frmAddEditJenis().ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DashboardAdmin.Hewan.frmAddEditJenis frmJenis = new DashboardAdmin.Hewan.frmAddEditJenis(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmJenis.txtJenis.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmJenis.txtHargaH.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmJenis.ShowDialog();
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_jenis = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    crud.delete_data();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Row Not Removed", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        public void SEARCH(String search)
        {
            dataGridView1.Rows.Clear();
            DataSet jenis_hewan = crud.search_data(search);


            for (int i = 0; i < jenis_hewan.Tables["jenis_hewan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["id_jenis"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["jenis"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["harga"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["created_at"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["update_at"].ToString(),
                    jenis_hewan.Tables["jenis_hewan"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void textBoxSearch2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch2.Text == "")
            {
                READ();
            }
            else
            {
                SEARCH(textBoxSearch2.Text);
            }
        }
    }
}
