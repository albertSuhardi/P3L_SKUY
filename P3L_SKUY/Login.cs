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

namespace P3L_SKUY
{
    
    public partial class Login : Form
    {
        LoginLogout accnt = new LoginLogout();
        public Login()
        {
            InitializeComponent();
        }

        public void login()
        {
            /*MySqlConnection conn;
            string myConnectionString, myQuery;
            int i = 0;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=;database=p3l_gaskuy;";

            myQuery = "select * from pegawai where username = '" + this.txtUsername.Text.ToString() + "' and password = '" + this.txtPassword.Text.ToString() + "';";

            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                //MessageBox.Show("Success!");
                MySqlCommand cmd = new MySqlCommand(myQuery, conn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                MyAdapter.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Username/password salah...", "Peringatan!");
                }
                else
                {
                    //User U = new User(dt.Rows[0][0].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][1].ToString());
                    //U = dt.Rows[0];

                    
                    new DashboardAdmin.Dashboard().Show();
                    this.Hide();
                }
                //dataPegawai.DataSource = dt;
                conn.Close();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

            }*/
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            /*string user = txtUsername.Text;
            string passwd = txtPassword.Text;
            MySqlConnection conn = new MySqlConnection("server = localhost; user id=root; database=p3l_gaskuy");
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from pegawai where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString()!="0")
            {
                MessageBox.Show("Username and Password are matched!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new DashboardAdmin.Dashboard().Show();
                this.Hide();
            }
            else if(dt.Rows[0][0].ToString() == "")
            {
                MessageBox.Show("Incorect username and password", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            label1.ForeColor = Color.White;

            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                if(txtUsername.Text == "")
                {
                    label1.ForeColor = Color.FromArgb(255, 128, 128);
                    label1.Text = "Please insert your username!";
                }else if (txtPassword.Text == ""){
                    label5.ForeColor = Color.FromArgb(255, 128, 128);
                    label5.Text = "Please insert the password!";
                }

            }
            else
            {
                accnt.username = txtUsername.Text;
                accnt.password = txtPassword.Text;
                bool verify = accnt.validate_user();

                if (verify)
                {
                    if(accnt.role == "OWNER")
                    {
                        MessageBox.Show("Welcome My Beloved Admin " + accnt.nama);
                        new DashboardAdmin.Dashboard().Show();
                        this.Hide();
                    }
                    else if(accnt.role == "KASIR")
                    {
                        MessageBox.Show("Welcome " + accnt.nama);
                        new DashboardKasir.DashboardKasir().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Maaf " + accnt.nama + " kamu bukan owner atau kasir :(");
                    }

                }
                else
                {
                    MessageBox.Show("Please Check Usernam or Your Password!");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
