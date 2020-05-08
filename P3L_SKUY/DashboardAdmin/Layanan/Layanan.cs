using System;
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

namespace P3L_SKUY.DashboardAdmin.Layanan
{
    public partial class Layanan : Form
    {
        Layanans crud = new Layanans();
        public Layanan()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            dataGridView1.Rows.Clear();
            DataSet layanan = crud.read_data();


            for (int i = 0; i < layanan.Tables["layanan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    layanan.Tables["layanan"].Rows[i]["id_layanan"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["nama"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["harga"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["created_at"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["update_at"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        public void SEARCH(String search)
        {
            dataGridView1.Rows.Clear();
            DataSet layanan = crud.search_data(search);

            for (int i = 0; i < layanan.Tables["layanan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    layanan.Tables["layanan"].Rows[i]["id_layanan"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["nama"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["harga"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["created_at"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["update_at"].ToString(),
                    layanan.Tables["layanan"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void btnAddJenis_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Layanan.frmAddEditLayanan().ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DashboardAdmin.Layanan.frmAddEditLayanan frmLayanan = new frmAddEditLayanan(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmLayanan.txtLayanan.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmLayanan.txtHargaL.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmLayanan.ShowDialog();
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_layanan = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    crud.delete_data();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Row Not Removed", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
