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
    public partial class frmEditMember : Form
    {
        Members crud = new Members();
        string id_member = null;

        public frmEditMember()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Member";
            pnlError.Visible = false;
        }

        public frmEditMember(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Member";
            id_member = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            crud.nama = txtNamaM.Text;
            crud.alamat = txtAlamatM.Text;
            crud.tgl_lhr = TglM.Value.ToString("yyyy-MM-dd");
            crud.no_telp = txtNoM.Text;
            crud.status = txtStatusM.Text;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.id_member = id_member;
            crud.nama = txtNamaM.Text;
            crud.alamat = txtAlamatM.Text;
            crud.tgl_lhr = TglM.Value.ToString("yyyy-MM-dd");
            crud.no_telp = txtNoM.Text;
            crud.status = txtStatusM.Text;

            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtNamaM.Text == "")
            {
                lblError.Text = "Please Insert Member's Name!";
            }
            else if (txtAlamatM.Text == "")
            {
                lblError.Text = "Please Insert Member's Address!";
            }
            else if (TglM.Text == "")
            {
                lblError.Text = "Please Insert Member's Birthdate!";
            }
            else if (txtNoM.Text == "")
            {
                lblError.Text = "Please Insert Member's Phone Number!";
            }
            else if (txtStatusM.Text == "")
            {
                lblError.Text = "Please Insert Member's Status!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNamaM.Text == "" || txtAlamatM.Text == "" || TglM.Text == "" || txtNoM.Text == "" || txtStatusM.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_member == null)
                {
                    CREATE();
                    MessageBox.Show("Data Member Baru Ditambah");
                    this.Hide();
                }
                else
                {
                    UPDATE();
                    MessageBox.Show("Data Member Terupdate");
                    this.Hide();
                }
            }
            
        }

        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlError.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
