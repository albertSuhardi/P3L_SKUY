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

namespace P3L_SKUY.DashboardAdmin.Supplier
{
    public partial class Supplier : Form
    {
        Suppliers crud = new Suppliers();
        public Supplier()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            dataGridView1.Rows.Clear();
            DataSet supplier = crud.read_data();


            for (int i = 0; i < supplier.Tables["supplier"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    supplier.Tables["supplier"].Rows[i]["id_supplier"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["nama"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["no_telp"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["alamat"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["created_at"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["update_at"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void btnAddJenis_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Supplier.frmAddEditSupplier().ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DashboardAdmin.Supplier.frmAddEditSupplier frmSupplier = new DashboardAdmin.Supplier.frmAddEditSupplier(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmSupplier.txtNamaS.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmSupplier.txtNoS.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmSupplier.txtAlamatS.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frmSupplier.ShowDialog();
            }
            if (e.ColumnIndex == 8)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_supplier = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
            DataSet supplier = crud.search_data(search);


            for (int i = 0; i < supplier.Tables["supplier"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    supplier.Tables["supplier"].Rows[i]["id_supplier"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["nama"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["no_telp"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["alamat"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["created_at"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["update_at"].ToString(),
                    supplier.Tables["supplier"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            
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
