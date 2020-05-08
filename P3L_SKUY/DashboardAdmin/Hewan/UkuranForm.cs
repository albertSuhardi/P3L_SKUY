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

namespace P3L_SKUY.DashboardAdmin.Hewan
{
    public partial class UkuranForm : Form
    {
        Ukurans crud = new Ukurans();
        public UkuranForm()
        {
            InitializeComponent();
            READ();
        }

        private void btnAddJenis_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Hewan.frmAddEditUkuran().ShowDialog();
        }

        public void READ()
        {
            dataGridView1.Rows.Clear();
            DataSet ukuran = crud.read_data();


            for (int i = 0; i < ukuran.Tables["ukuran_hewan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    ukuran.Tables["ukuran_hewan"].Rows[i]["id_ukuran"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["ukuran"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["harga"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["created_at"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["update_at"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DashboardAdmin.Hewan.frmAddEditUkuran frmJenis = new DashboardAdmin.Hewan.frmAddEditUkuran(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmJenis.txtUkuran.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmJenis.txtHargaU.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmJenis.ShowDialog();
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_ukuran = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
            DataSet ukuran = crud.search_data(search);


            for (int i = 0; i < ukuran.Tables["ukuran_hewan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    ukuran.Tables["ukuran_hewan"].Rows[i]["id_ukuran"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["ukuran"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["harga"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["created_at"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["update_at"].ToString(),
                    ukuran.Tables["ukuran_hewan"].Rows[i]["aktor"].ToString(),
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
