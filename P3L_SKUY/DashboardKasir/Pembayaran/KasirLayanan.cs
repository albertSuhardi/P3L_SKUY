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

namespace P3L_SKUY.DashboardKasir.Pembayaran
{
    public partial class KasirLayanan : Form
    {
        TransaksiLayanan crud = new TransaksiLayanan();
        public KasirLayanan()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            gunaDataGridView1.Rows.Clear();
            DataSet supplier = crud.read_data();


            for (int i = 0; i < supplier.Tables["transaksi_layanan"].Rows.Count; i++)
            {
                gunaDataGridView1.Rows.Add(new object[]
                {
                    supplier.Tables["transaksi_layanan"].Rows[i]["id_transaksi_layanan"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["member"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["hewan"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["status_layanan"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["sub_total"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["diskon"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["total_harga"].ToString(),
                    "Update",
                    "Delete"
                });
                gunaDataGridView1.Rows[gunaDataGridView1.RowCount - 1].Tag = i;
            }
        }

        public void SEARCH(String search)
        {
            gunaDataGridView1.Rows.Clear();
            DataSet supplier = crud.search_data(search);


            for (int i = 0; i < supplier.Tables["transaksi_layanan"].Rows.Count; i++)
            {
                gunaDataGridView1.Rows.Add(new object[]
                {
                    supplier.Tables["transaksi_layanan"].Rows[i]["id_transaksi_layanan"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["member"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["hewan"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["status_layanan"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["sub_total"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["diskon"].ToString(),
                    supplier.Tables["transaksi_layanan"].Rows[i]["total_harga"].ToString(),
                    "Update",
                    "Delete"
                });
                gunaDataGridView1.Rows[gunaDataGridView1.RowCount - 1].Tag = i;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
        }
    }
}
