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
namespace formkiemtra
{
    public partial class Form1 : Form
    {

        public SqlConnection connect;
        string a = "Data Source = A209PC41;Initial Catalog = QLHN;Integrated Security = true";
        public Form1()
        {

            InitializeComponent();
            comboBox1.Items.Add("PHONG_HN");
            comboBox1.Items.Add("PHONG_HOP");
        }
        public void Them(string S, string T, string SN)
        {
            try
            {
                connect = new SqlConnection(a);
                connect.Open();
                string InsertString = "insert into HoiNghi Values('" + S + "' ,' " + T + "','" + SN + "')";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Xoa(string S, string Ta)
        {
            try
            {

                connect = new SqlConnection(a);
                connect.Open();
                string DeleteString = "delete HoiNghi where MaSo = '" + S + "'";
                SqlCommand cmd = new SqlCommand(DeleteString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Xoa(textBox1.Text, textBox3.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Them(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from HoiNghi";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            try
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
            }
            catch
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xoa(textBox1.Text, textBox3.Text);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Them(textBox1.Text, textBox2.Text, textBox3.Text);
        }
    }
}