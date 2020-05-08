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

namespace P3L_SKUY.DashboardAdmin.Member
{
    public partial class Member : Form
    {
        Members crud = new Members();
        public Member()
        {
            InitializeComponent();
            READ();
        }

        public void READ()
        {
            dataGridView1.Rows.Clear();
            DataSet member = crud.read_data();


            for (int i = 0; i < member.Tables["member"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    member.Tables["member"].Rows[i]["id_member"].ToString(),
                    member.Tables["member"].Rows[i]["nama"].ToString(),
                    member.Tables["member"].Rows[i]["no_telp"].ToString(),
                    member.Tables["member"].Rows[i]["tgl_lhr"].ToString(), 
                    member.Tables["member"].Rows[i]["alamat"].ToString(),
                    member.Tables["member"].Rows[i]["status"].ToString(),
                    member.Tables["member"].Rows[i]["created_at"].ToString(),
                    member.Tables["member"].Rows[i]["update_at"].ToString(),
                    member.Tables["member"].Rows[i]["aktor"].ToString(),
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

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            READ();
        }

        public void SEARCH(String search)
        {
            dataGridView1.Rows.Clear();
            DataSet member = crud.search_data(search);


            for (int i = 0; i < member.Tables["member"].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    member.Tables["member"].Rows[i]["id_member"].ToString(),
                    member.Tables["member"].Rows[i]["nama"].ToString(),
                    member.Tables["member"].Rows[i]["no_telp"].ToString(),
                    member.Tables["member"].Rows[i]["tgl_lhr"].ToString(),
                    member.Tables["member"].Rows[i]["alamat"].ToString(),
                    member.Tables["member"].Rows[i]["status"].ToString(),
                    member.Tables["member"].Rows[i]["created_at"].ToString(),
                    member.Tables["member"].Rows[i]["update_at"].ToString(),
                    member.Tables["member"].Rows[i]["aktor"].ToString(),
                    "Update",
                    "Delete"
                });
                dataGridView1.Rows[dataGridView1.RowCount - 1].Tag = i;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                DashboardAdmin.Member.frmEditMember frmMember = new DashboardAdmin.Member.frmEditMember(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmMember.txtNamaM.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmMember.txtNoM.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frmMember.TglM.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[3].Value);
                frmMember.txtAlamatM.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frmMember.txtStatusM.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                frmMember.ShowDialog();
            }
            if (e.ColumnIndex == 10)
            {
                if (MessageBox.Show("Do You Want To Remove This Row", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    crud.id_member = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    crud.delete_data();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Row Not Removed", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void btnAddPegawai_Click(object sender, EventArgs e)
        {
            new DashboardAdmin.Member.frmEditMember().ShowDialog();
        }
    }
}
