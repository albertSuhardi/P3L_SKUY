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

namespace P3L_SKUY.DashboardAdmin.Supplier
{
    public partial class frmAddEditSupplier : Form
    {
        Suppliers crud = new Suppliers();
        string id_supplier = null;

        public frmAddEditSupplier()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Supplier";
            pnlError.Visible = false;
        }

        public frmAddEditSupplier(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Supplier";
            id_supplier = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            crud.nama = txtNamaS.Text;
            crud.alamat = txtAlamatS.Text;
            crud.no_telp = txtNoS.Text;
            
            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.nama = txtNamaS.Text;
            crud.alamat = txtAlamatS.Text;
            crud.no_telp = txtNoS.Text;
            crud.id_supplier = id_supplier;

            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtNamaS.Text == "")
            {
                lblError.Text = "Please Insert Supplier Name!";
            }
            else if (txtNoS.Text == "")
            {
                lblError.Text = "Please Insert Supplier Nomor Telephone!";
            }
            else if (txtAlamatS.Text == "")
            {
                lblError.Text = "Please Insert Supplier Alamat!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNamaS.Text == "" || txtNoS.Text == "" || txtAlamatS.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_supplier == null)
                {
                    //New Jenis
                    CREATE();
                    MessageBox.Show("Data Supplier Baru Tersimpan");
                    this.Hide();
                    
                }
                else
                {
                    //Update
                    UPDATE();
                    MessageBox.Show("Data Supplier Baru Terupdate");
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
