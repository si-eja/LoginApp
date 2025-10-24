using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        public string NamaLogin { get; set; }
        public Form1(string nama)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Selamat datang, " + (NamaLogin ?? "Pengguna");
        }

    }
}
