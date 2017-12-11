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
    public partial class binalar : Form
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
                adap = new NpgsqlDataAdapter("SELECT * FROM bina", con);
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

        public binalar()
        {
            InitializeComponent();
        }

        private void binalar_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void daireGorevlileribtn_Click(object sender, EventArgs e)
        {
            daireler daireler = new daireler();
            daireler.Show();
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
                NpgsqlCommand command = new NpgsqlCommand("insert into bina (binaid,binakod,yapilistarihi,dairesayisi,havuzbilgisi,katsayisi,siteid,asansorsayisi,aciklama) values ('" + textBox1.Text + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "')", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
                MessageBox.Show("bina Eklendi");
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
                NpgsqlCommand command = new NpgsqlCommand("UPDATE bina SET binakod ='" + textBox2.Text.ToString() + "' , yapilistarihi ='" + textBox3.Text.ToString() + "' , dairesayisi='" + textBox4.Text.ToString() + "' , havuzbilgisi='" + textBox5.Text.ToString() + "' , katsayisi ='" + textBox6.Text.ToString() + "' , siteid ='" + textBox7.Text.ToString() + "' , asansorsayisi ='" + textBox8.Text.ToString() + "' , aciklama='" + textBox9.Text.ToString() + "' where binaid='" + textBox1.Text + "'", con);

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
                NpgsqlCommand command = new NpgsqlCommand("Delete from bina where binaid =(" + textBox1.Text.ToString() + ")", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }
    }
}
