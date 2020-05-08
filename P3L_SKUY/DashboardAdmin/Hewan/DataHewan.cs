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

    public partial class DataHewan : Form
    {
        DataHewans crud = new DataHewans();
        public List<string> dataHewan = new List<string>();

        public DataHewan()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            int j = 0;
            dataGridView1.Rows.Clear();
            DataSet dataHewan = crud.read_data();

            for (int i = 0; i < dataHewan.Tables["data_hewan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    dataHewan.Tables["data_hewan"].Rows[i]["id_hewan"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["jenis"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["ukuran"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["nama"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["tgl_lhr"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["member"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["created_at"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["update_at"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["aktor"].ToString(),
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

        private void btnAddHewan_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Hewan.frmEditDataHewan().ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            if (e.ColumnIndex == 9)
            {
                DashboardAdmin.Hewan.frmEditDataHewan frmHewan = new DashboardAdmin.Hewan.frmEditDataHewan(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                

                frmHewan.txtNamaDH.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                frmHewan.TglDH.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[4].Value);

                //frmHewan.comboBox1.Items.Add(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());

                crud.jenis_data();
                dataHewan = crud.dataJenis;
                for (i = 0; i < dataHewan.Count; i++)
                {
                    frmHewan.comboBox1.Items.Add(dataHewan[i]);
                }
                frmHewan.comboBox1.SelectedItem = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                frmHewan.comboBox1.Items.Add(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                frmHewan.comboBox2.Items.Add(this.dataGridView1.CurrentRow.Cells[2].Value.ToString());
                frmHewan.comboBox3.Items.Add(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());

                frmHewan .ShowDialog();
            }
            if (e.ColumnIndex == 10)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_hewan = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
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

        public void SEARCH(String search)
        {
            dataGridView1.Rows.Clear();
            DataSet dataHewan = crud.search_data(search);

            for (int i = 0; i < dataHewan.Tables["data_hewan"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    dataHewan.Tables["data_hewan"].Rows[i]["id_hewan"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["jenis"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["ukuran"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["nama"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["tgl_lhr"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["member"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["created_at"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["update_at"].ToString(),
                    dataHewan.Tables["data_hewan"].Rows[i]["aktor"].ToString(),
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

