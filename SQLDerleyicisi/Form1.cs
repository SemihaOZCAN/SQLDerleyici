using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLDerleyicisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-KIMUOA0\SQLEXPRESS;Initial Catalog=DbOtelRezervasyon;Integrated Security=True");

        private void buttonEXECUTE_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;
            
            try
            {
                SqlDataAdapter dr = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("sorgunuzu tekrar kontrol edin ", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

           

        }

        private void buttonSQLHAKKINDA_Click(object sender, EventArgs e)
        {
            //sql kaynak onerme
            System.Diagnostics.Process.Start("https://www.w3schools.com/sql/");
        }

        private void buttoneklesılguncelle_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;
            try
            {
                
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter("select * from TblDepartman", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {

                MessageBox.Show("sorgunuzu tekrar kontrol edin ", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
           
        }
    }
}
