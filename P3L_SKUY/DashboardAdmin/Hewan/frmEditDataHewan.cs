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
    public partial class frmEditDataHewan : Form
    {
        DataHewans crud = new DataHewans();
        string id_hewan = null;
        public string jenis;
        public string ukuran;
        public string owner;

        public frmEditDataHewan()
        {
            InitializeComponent();
            lbltitle.Text = "Tambah Data Hewan";
            pnlError.Visible = false;
        }

        public frmEditDataHewan(string i)
        {
            InitializeComponent();
            lbltitle.Text = "Update Data Hewan";
            id_hewan = i;
            pnlError.Visible = false;
        }

        public void CREATE()
        {
            /*crud.id_jenis = ;
            crud.id_member = txtHargaH.Text;*/

            crud.jenis = jenis;
            crud.ukuran = ukuran;
            crud.owner = owner;

            bool IDjenis = crud.search_idJenis();
            bool IDUkuran = crud.search_idUkuran();
            bool IDMember = crud.search_idMember();

            crud.id_jenis = crud.id_jenis;
            crud.id_ukuran = crud.id_ukuran;
            crud.id_member = crud.id_member;
            crud.nama = txtNamaDH.Text;
            crud.tgl_lhr = TglDH.Text;
            crud.id_pegawai_cs = idLog.id;

            crud.Create_data();
        }

        public void UPDATE()
        {
            crud.id_hewan = id_hewan;
            crud.jenis = jenis;
            crud.ukuran = ukuran;
            crud.owner = owner;

            bool IDjenis = crud.search_idJenis();
            bool IDUkuran = crud.search_idUkuran();
            bool IDMember = crud.search_idMember();

            crud.id_jenis = crud.id_jenis;
            crud.id_ukuran = crud.id_ukuran;
            crud.id_member = crud.id_member;
            crud.nama = txtNamaDH.Text;
            crud.tgl_lhr = TglDH.Text;


            crud.Update_data();
        }

        void ShowError()
        {
            pnlError.Visible = true;
            tmrError.Start();
            if (txtNamaDH.Text == "")
            {
                lblError.Text = "Please Insert Name for this Pet!";
            }
            else if (TglDH.Text == "")
            {
                lblError.Text = "Please Input his Birthdate!";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNamaDH.Text == "" || TglDH.Text == "")
            {
                ShowError();
            }
            else
            { 
                if(id_hewan == null)
                {
                    DialogResult dialogResult = MessageBox.Show("Sure Want to Add Data Hewan?", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CREATE();
                        MessageBox.Show("Data Hewan Baru Tersimpan");
                        this.Hide();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //noaction
                    }
                }
                else
                {
                    UPDATE();
                    MessageBox.Show("Data Hewan Baru Terupdate");
                    this.Hide();
                }
            }
                
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void frmEditDataHewan_Load(object sender, EventArgs e)
        {
            crud.jenis_data();
            comboBox1.DataSource = crud.dataJenis;

            crud.ukuran_data();
            comboBox2.DataSource = crud.dataUkuran;

            crud.owner_data();
            comboBox3.DataSource = crud.dataMember;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            jenis = comboBox1.Text.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ukuran = comboBox2.Text.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            owner = comboBox3.Text.ToString();
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

