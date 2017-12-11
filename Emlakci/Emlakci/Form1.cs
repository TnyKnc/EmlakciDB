using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;

namespace Emlakci
{
    public partial class Form1 : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter adap;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Site site = new Site();
            site.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void yoneticibtn_Click(object sender, EventArgs e)
        {
            Yoneticiler yoneticiler = new Yoneticiler();
            yoneticiler.Show();
        }

        private void DaireSahibibtn_Click(object sender, EventArgs e)
        {
            daireSahipleri dairesahipleri = new daireSahipleri();
            dairesahipleri.Show();
        }
    }
}
