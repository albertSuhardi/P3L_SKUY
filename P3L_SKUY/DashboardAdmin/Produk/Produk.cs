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
using System.IO;

namespace P3L_SKUY.DashboardAdmin.Produk
{
    public partial class Produk : Form
    {
        Produks crud = new Produks();

        public Produk()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            dataGridView1.Rows.Clear();
            DataSet produk = crud.read_data();

            for (int i = 0; i < produk.Tables["produk"].Rows.Count; i++)
            {
                dataGridView1.RowTemplate.Height = 120;
                dataGridView1.Rows.Add(new object[]
                {
                    produk.Tables["produk"].Rows[i]["id_produk"].ToString(),
                    produk.Tables["produk"].Rows[i]["nama"].ToString(),
                    produk.Tables["produk"].Rows[i]["unit"].ToString(),
                    produk.Tables["produk"].Rows[i]["stok"].ToString(),
                    produk.Tables["produk"].Rows[i]["min_stok"].ToString(),
                    produk.Tables["produk"].Rows[i]["harga"].ToString(),
                    produk.Tables["produk"].Rows[i]["fotos"],
                    produk.Tables["produk"].Rows[i]["created_at"].ToString(),
                    produk.Tables["produk"].Rows[i]["update_at"].ToString(),
                    produk.Tables["produk"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
                
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[6];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                produk.Dispose();
            }
            
        }

        private void btnAddHewan_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Produk.frmAddEditProduk().ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                DashboardAdmin.Produk.frmAddEditProduk frmProduk = new DashboardAdmin.Produk.frmAddEditProduk(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmProduk.txtNamaPro.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmProduk.txtUnitPro.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmProduk.txtJumlahPro.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frmProduk.txtMinStok.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frmProduk.txtHargaPro .Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

                MemoryStream ms = new MemoryStream((byte[])this.dataGridView1.CurrentRow.Cells[6].Value);
                frmProduk.pictureBox1.Image = Image.FromStream(ms);
                frmProduk.ShowDialog();
            }
            if (e.ColumnIndex == 11)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_produk = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
            DataSet produk = crud.search_data(search);


            for (int i = 0; i < produk.Tables["produk"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    produk.Tables["produk"].Rows[i]["id_produk"].ToString(),
                    produk.Tables["produk"].Rows[i]["nama"].ToString(),
                    produk.Tables["produk"].Rows[i]["unit"].ToString(),
                    produk.Tables["produk"].Rows[i]["stok"].ToString(),
                    produk.Tables["produk"].Rows[i]["min_stok"].ToString(),
                    produk.Tables["produk"].Rows[i]["harga"].ToString(),
                    produk.Tables["produk"].Rows[i]["fotos"],
                    produk.Tables["produk"].Rows[i]["created_at"].ToString(),
                    produk.Tables["produk"].Rows[i]["update_at"].ToString(),
                    produk.Tables["produk"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

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
