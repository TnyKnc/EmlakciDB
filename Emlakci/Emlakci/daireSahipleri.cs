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
    public partial class daireSahipleri : Form
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter adap;
        DataSet ds;

        private void verilerigoster()
        {
            try
            {
                con = new NpgsqlConnection();
                con.ConnectionString = @"Server = localhost; Port = 5432; User Id = postgres; Password = 1234; Database = EmlakciDB;";
                con.Open();
                adap = new NpgsqlDataAdapter("SELECT * FROM dairesahibi", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "Site");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata! " + hata.Message);
            }
        }

        public daireSahipleri()
        {
            InitializeComponent();
        }

        private void daireSahipleri_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("insert into dairesahibi (sahipid,adi,soyadi,telefonno,adresi) values ('" + textBox5.Text + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
                MessageBox.Show("Daire Sahibi Eklendi");
            }
            catch (Exception hata)
            {
                con.Close();
                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("UPDATE dairesahibi SET adi ='" + textBox1.Text.ToString() + "' , soyadi ='" + textBox2.Text.ToString() + "' , telefonno ='" + textBox3.Text.ToString() + "' , adresi ='" + textBox4.Text.ToString() + "' where sahipid='" + textBox5.Text + "'", con);

                command.ExecuteNonQuery();
                verilerigoster();
                con.Close();
                MessageBox.Show("Düzenlendi!");
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("Delete from dairesahibi where sahipid =(" + textBox5.Text.ToString() + ")", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
            }
            catch (Exception hata)
            {
                con.Close();
                MessageBox.Show(hata.Message);
            }
        }
    }
}
