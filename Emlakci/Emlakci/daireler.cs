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
    public partial class daireler : Form
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
                adap = new NpgsqlDataAdapter("SELECT * FROM daire", con);
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
        public daireler()
        {
            InitializeComponent();
        }

        private void daireGorevlileribtn_Click(object sender, EventArgs e)
        {
            DaireGorevlileri dairegorevlileri = new DaireGorevlileri();
            dairegorevlileri.Show();
        }

        private void daireler_Load(object sender, EventArgs e)
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
                NpgsqlCommand command = new NpgsqlCommand("insert into daire (daireid,daireno,odasayisi,bulundugukat,buyuklugu,fiyat,aciklama,tuvaletsayisi,aidatucreti,cephe,isiyalitimi,gorevliid,binaid) values ('" + textBox1.Text + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + textBox11.Text.ToString() + "','" + textBox12.Text + "','" + textBox13.Text + "')", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
                MessageBox.Show("daire Eklendi");
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
                NpgsqlCommand command = new NpgsqlCommand("UPDATE daire SET daireno ='" + textBox2.Text.ToString() + "' , odasayisi ='" + textBox3.Text.ToString() + "' , bulundugukat='" + textBox4.Text.ToString() + "' , buyuklugu='" + textBox5.Text.ToString() + "' , fiyat ='" + textBox6.Text.ToString() + "' , aciklama ='" + textBox7.Text.ToString() + "' , tuvaletsayisi ='" + textBox8.Text.ToString() + "' , aidatucreti='" + textBox9.Text.ToString() + "' , cephe='" + textBox10.Text.ToString() + "' , isiyalitimi='" + textBox11.Text.ToString() + "' , gorevliid='" + textBox12.Text.ToString() + "' , binaid='" + textBox13.Text.ToString() + "' where daireid='" + textBox1.Text + "'", con);

                command.ExecuteNonQuery();
                verilerigoster();
                con.Close();
                MessageBox.Show("Düzenlendi!");
            }
            catch (Exception hata)
            {
                con.Close();
                MessageBox.Show(hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("Delete from daire where daireid =(" + textBox1.Text.ToString() + ")", con);

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
