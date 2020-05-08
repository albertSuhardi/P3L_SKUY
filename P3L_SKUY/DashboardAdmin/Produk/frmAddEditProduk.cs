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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace P3L_SKUY.DashboardAdmin.Produk
{
    public partial class frmAddEditProduk : Form
    {
        Produks crud = new Produks();
        public string imglocation = "";
        string id_produk = null;
        public byte[] fotos;

        public frmAddEditProduk()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Produk";
            pnlError.Visible = false;
        }

        public frmAddEditProduk(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Produk";
            id_produk = i;
            pnlError.Visible = false;
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtNamaPro.Text == "")
            {
                lblError.Text = "Please Insert Product's Name!";
            }
            else if (txtJumlahPro.Text == "")
            {
                lblError.Text = "Please Insert Product's Stok!";
            }
            else if (txtMinStok.Text == "")
            {
                lblError.Text = "Please Insert Product's Minimum!";
            }
            else if (txtUnitPro.Text == "")
            {
                lblError.Text = "Please Insert Product's Note!";
            }
            else if (txtHargaPro.Text == "")
            {
                lblError.Text = "Please Insert Product's Price!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNamaPro.Text == "" || txtJumlahPro.Text == "" || txtMinStok.Text == "" || txtUnitPro.Text == "" || txtHargaPro.Text == "")
            {
                ShowError();
            }
            else
            {
                if (id_produk == null)
                {
                    //New Jenis
                    CREATE();
                    MessageBox.Show("Data Produk Baru Tersimpan");
                    this.Hide();
                }
                else
                {

                    //Update
                    UPDATE();
                    MessageBox.Show("Data Produk Baru Terupdate");
                    this.Hide();
                    //save
                }
            }
            
        }

        public void CREATE()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            crud.nama = txtNamaPro.Text;
            crud.unit = txtUnitPro.Text;
            crud.stok = txtJumlahPro.Text;
            crud.min_stok = txtMinStok.Text;
            crud.harga = txtHargaPro.Text;
            
            crud.fotos = img;

            crud.create_data();
        }

        public void BROWSER()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|JPG files(*.JPG)|*.JPG|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
                /*imglocation = dialog.FileName.ToString();*/
                pictureBox1.ImageLocation = imglocation;
                
            }
        }

        public void UPDATE()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            crud.nama = txtNamaPro.Text;
            crud.unit = txtHargaPro.Text;
            crud.stok = txtJumlahPro.Text;
            crud.min_stok = txtMinStok.Text;
            crud.harga = txtUnitPro.Text;

            crud.id_produk = id_produk;
            /*byte[] foto = null;
            FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            foto = brs.ReadBytes((byte)stream.Length);*/
            crud.fotos = img;

            crud.update_data();
        }

        private void btnGambar_Click(object sender, EventArgs e)
        {
            BROWSER();
        }

        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlError.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
