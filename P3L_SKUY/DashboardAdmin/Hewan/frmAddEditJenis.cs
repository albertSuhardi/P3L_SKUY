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
    public partial class frmAddEditJenis : Form
    {
        Jeniss crud = new Jeniss();
        string id_jenis = null;
        public frmAddEditJenis()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Jenis";
            pnlError.Visible = false;
        }

        public frmAddEditJenis(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Jenis";
            id_jenis = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            crud.jenis = txtJenis.Text;
            crud.harga = txtHargaH.Text;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.jenis = txtJenis.Text;
            crud.harga = txtHargaH.Text;
            crud.id_jenis = id_jenis;

            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtJenis.Text == "")
            {
                lblError.Text = "Please Insert Type Pet!";
            }
            else if (txtHargaH.Text == "")
            {
                lblError.Text = "Please Insert Price for this Pet!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtJenis.Text == "" || txtHargaH.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_jenis == null)
                {
                    //New Jenis
                    CREATE();
                    MessageBox.Show("Data Jenis Hewan Baru Tersimpan");
                    this.Hide();
                }
                else
                {
                    //Update
                    UPDATE();
                    MessageBox.Show("Data Jenis Hewan Baru Terupdate");
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
