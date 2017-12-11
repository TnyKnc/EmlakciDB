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
    public partial class Site : Form
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
                adap = new NpgsqlDataAdapter("SELECT siteid, siteadi, bloksayisi, dairesayisi, hakkinda, guvenlikgorevlisisayisi, il, ilce, mahalle, sokak FROM site", con);
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

        public Site()
        {
            InitializeComponent();
        }

        private void Site_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void binalarbtn_Click(object sender, EventArgs e)
        {
            binalar binalar = new binalar();
            binalar.Show();
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
                NpgsqlCommand command = new NpgsqlCommand("insert into site (siteid,siteadi,bloksayisi,dairesayisi,guvenlikgorevlisisayisi,il,ilce,mahalle,sokak,hakkinda) values ('" + textBox1.Text + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox10.Text.ToString() + "')", con);

                command.ExecuteNonQuery();
                verilerigoster();

                con.Close();
                MessageBox.Show("Site Eklendi");
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("UPDATE site SET siteadi ='" + textBox2.Text.ToString() + "' , bloksayisi ='" + textBox3.Text.ToString() + "' , dairesayisi='" + textBox4.Text.ToString() + "' , il='" + textBox6.Text.ToString() + "' , ilce ='" + textBox7.Text.ToString() + "' , mahalle ='" + textBox8.Text.ToString() + "' , sokak ='" + textBox9.Text.ToString() + "' , hakkinda='" + textBox10.Text.ToString() + "' where siteid='" + textBox1.Text + "'", con);

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
                NpgsqlCommand command = new NpgsqlCommand("Delete from site where siteid =(" + textBox1.Text.ToString() + ")", con);

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
