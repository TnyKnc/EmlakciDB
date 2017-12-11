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
    public partial class Yoneticiler : Form
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
                adap = new NpgsqlDataAdapter("SELECT * FROM yonetici", con);
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

        public Yoneticiler()
        {
            InitializeComponent();
        }

        private void Yoneticiler_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("insert into yonetici (yoneticiid,yoneticiadi,yoneticisifre,epostaadresi,yoneticisoyadi) values ('" + textBox5.Text + "','" + textBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "')", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
                MessageBox.Show("Yönetici Eklendi");
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
                NpgsqlCommand command = new NpgsqlCommand("Delete from yonetici where yoneticiid =(" + textBox5.Text.ToString() + ")", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("UPDATE yonetici SET yoneticiadi ='" + textBox1.Text.ToString() + "' , yoneticisoyadi ='" + textBox2.Text.ToString() + "' , epostaadresi ='" + textBox3.Text.ToString() + "' , yoneticisifre ='" + textBox4.Text.ToString() + "' where yoneticiid='" + textBox5.Text + "'", con);

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
    }
}
