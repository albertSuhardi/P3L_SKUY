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
    public partial class frmAddEditLayanan : Form
    {
        Layanans crud = new Layanans();
        string id_layanan = null;
        public frmAddEditLayanan()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Layanan";
            pnlError.Visible = false;
        }

        public frmAddEditLayanan(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Layanan";
            id_layanan = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            crud.nama = txtLayanan.Text;
            crud.harga = txtHargaL.Text;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.nama = txtLayanan.Text;
            crud.harga = txtHargaL.Text;
            crud.id_layanan = id_layanan;

            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtLayanan.Text == "")
            {
                lblError.Text = "Please Insert Service Pet!";
            }
            else if (txtHargaL.Text == "")
            {
                lblError.Text = "Please Insert Price for this Service!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLayanan.Text == "" || txtHargaL.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_layanan == null)
                {
                    //New Jenis
                    CREATE();
                    MessageBox.Show("Data Layanan Baru Tersimpan");
                    this.Hide();
                    
                }
                else
                {
                    //Update
                    UPDATE();
                    MessageBox.Show("Data Layanan Terupdate");
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
