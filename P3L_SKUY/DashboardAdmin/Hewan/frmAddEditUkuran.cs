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
    public partial class frmAddEditUkuran : Form
    {
        Ukurans crud = new Ukurans();
        string id_ukuran = null;
        public frmAddEditUkuran()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Ukuran";
            pnlError.Visible = false;
        }

        public frmAddEditUkuran(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Ukuran";
            id_ukuran = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            crud.ukuran = txtUkuran.Text;
            crud.harga = txtHargaU.Text;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.ukuran = txtUkuran.Text;
            crud.harga = txtHargaU.Text;
            crud.id_ukuran = id_ukuran;

            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtUkuran.Text == "")
            {
                lblError.Text = "Please Insert Size Pet!";
            }
            else if (txtHargaU.Text == "")
            {
                lblError.Text = "Please Insert Price for this Size!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUkuran.Text == "" || txtHargaU.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_ukuran == null)
                {
                    //New Jenis
                    CREATE();
                    MessageBox.Show("Data Ukuran Hewan Baru Tersimpan");
                    this.Hide();
                    
                }
                else
                {
                    //Update
                    UPDATE();
                    MessageBox.Show("Data Ukuran Hewan Baru Terupdate");
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
