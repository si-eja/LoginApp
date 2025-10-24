using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=MYPCPRO\\SQLEXPRESS; Initial Catalog=db_LoginApp; Integrated Security=True; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlConnection loginConn;
                SqlCommand loginCmd;
                SqlDataReader loginDataReader;

                loginConn = new SqlConnection("Data Source=MYPCPRO\\SQLEXPRESS; Initial Catalog=db_LoginApp; Integrated Security=True; TrustServerCertificate=True");

                loginCmd = new SqlCommand();
                loginConn.Open();
                loginCmd.Connection = loginConn;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                loginCmd.CommandText =
                    "SELECT * FROM akun WHERE password='" +
                    tbPass.Text + "'";
                loginCmd.Parameters.AddWithValue("@user", tbUser.Text);
                loginCmd.Parameters.AddWithValue("@pass", tbPass.Text);

                loginDataReader = loginCmd.ExecuteReader();

                if (loginDataReader.Read())
                {
                    string nama = loginDataReader["fullname"].ToString();

                    Form1 f2 = new Form1(nama);
                    f2.NamaLogin = nama;
                    f2.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah");
                    this.Close();
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbPass.UseSystemPasswordChar = true;
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
