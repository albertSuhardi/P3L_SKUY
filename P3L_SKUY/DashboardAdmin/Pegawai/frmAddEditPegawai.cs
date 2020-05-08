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

namespace P3L_SKUY.DashboardAdmin.Pegawai
{
    public partial class frmAddEditPegawai : Form
    {
        Pegawais crud = new Pegawais();
        string id_pegawai = null;
        String role;

        public frmAddEditPegawai()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Pegawai";
            pnlError.Visible = false;
        }

        public frmAddEditPegawai(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Pegawai";
            id_pegawai = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            crud.nama = txtNamaP.Text;
            crud.alamat = txtAlamatP.Text;
            crud.tgl_lhr = TglP.Value.ToString("yyyy-MM-dd");
            crud.no_telp = txtNoP.Text;
            crud.role = role;
            crud.username = txtUserP.Text;
            crud.password = txtPassP.Text;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.id_pegawai = id_pegawai;
            crud.nama = txtNamaP.Text;
            crud.alamat = txtAlamatP.Text;
            crud.tgl_lhr = TglP.Value.ToString("yyyy-MM-dd");
            crud.no_telp = txtNoP.Text;
            crud.role = role;
            crud.username = txtUserP.Text;
            crud.password = txtPassP.Text;

            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtNamaP.Text == "")
            {
                lblError.Text = "Please Insert Employee's Name!";
            }
            else if (txtAlamatP.Text == "")
            {
                lblError.Text = "Please Insert Employee's Address!";
            }
            else if (TglP.Text == "")
            {
                lblError.Text = "Please Insert Employee's Birthdate!";
            }
            else if (txtNoP.Text == "")
            {
                lblError.Text = "Please Insert Employee's Phone Number!";
            }
            else if (txtUserP.Text == "")
            {
                lblError.Text = "Please Insert Employee's Username!";
            }
            else if (txtPassP.Text == "")
            {
                lblError.Text = "Please Insert Employee's Password!";
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (txtNamaP.Text == "" || txtAlamatP.Text == "" || TglP.Text == "" || txtNoP.Text == "" || txtUserP.Text == "" || txtPassP.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_pegawai == null)
                {
                    //New Jenis
                    CREATE();
                    MessageBox.Show("Data Pegawai Baru Tersimpan");
                    this.Hide();
                }
                else
                {
                    //Update
                    UPDATE();
                    MessageBox.Show("Data Pegawai Baru Terupdate");
                    this.Hide();
                    //save
                }
            }
        }

        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlError.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            role = "CS";
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            role = "KASIR";
        }
    }

    

}
