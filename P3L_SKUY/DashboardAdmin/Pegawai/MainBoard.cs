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
using System.Data.SqlClient;

namespace P3L_SKUY
{
    public partial class MainBoard : Form
    {
        LoginLogout accnt = new LoginLogout();
        Pegawais crud = new Pegawais();
        public MainBoard()
        {
            InitializeComponent();
            READ();

        }

        private void btnAddPegawai_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Pegawai.frmAddEditPegawai().ShowDialog();
        }

        public void READ()
        {

            dataGridView1.Rows.Clear();
            DataSet pegawai = crud.read_data();


            for (int i = 0; i < pegawai.Tables["pegawai"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    pegawai.Tables["pegawai"].Rows[i]["id_pegawai"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["nama"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["alamat"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["tgl_lhr"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["no_telp"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["role"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["username"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["created_at"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["update_at"].ToString(),
                    "OWNER",
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                DashboardAdmin.Pegawai.frmAddEditPegawai frmPegawai = new DashboardAdmin.Pegawai.frmAddEditPegawai(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmPegawai.txtNamaP.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmPegawai.txtAlamatP.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmPegawai.TglP.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[3].Value);
                frmPegawai.txtNoP.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if (this.dataGridView1.CurrentRow.Cells[5].Value.ToString() == "CS")
                {
                    frmPegawai.gunaRadioButton1.Checked = true;
                }
                else
                {
                    frmPegawai.gunaRadioButton2.Checked = true;
                }
                frmPegawai.txtUserP.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
//                frmPegawai.txtPassP.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                frmPegawai.ShowDialog();
            }
            if (e.ColumnIndex == 11)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_pegawai = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    crud.delete_data();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Row Not Removed", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SEARCH(String search)
        {
            dataGridView1.Rows.Clear();
            DataSet pegawai = crud.search_data(search);


            for (int i = 0; i < pegawai.Tables["pegawai"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    pegawai.Tables["pegawai"].Rows[i]["id_pegawai"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["nama"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["alamat"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["tgl_lhr"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["no_telp"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["role"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["username"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["created_at"].ToString(),
                    pegawai.Tables["pegawai"].Rows[i]["update_at"].ToString(),
                    "OWNER",
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




