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

namespace form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlConnection connect;
        public string connectString = "Data Source=A209PC42;Initial Catalog=button;Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {
            
            connect = new SqlConnection(connectString);
            connect.Open();
            string ShowString = "Select * From sinhvien";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
           
        }
       

        private void xoa(string S,string TA)
        {
            try
            {
                connect = new SqlConnection(connectString);
                connect.Open();
                string deleteString = "delete " + TA +" where Maso = '" + S + "'";
                SqlCommand cmd = new SqlCommand(deleteString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành công");
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            xoa(textBox1.Text, textBox3.Text);
        }
        private void them(string S, string T, string TA)
        {
            try
            {

                connect = new SqlConnection(connectString);
                connect.Open();
                string InsertString = "insert into "+ TA +" values('" + S+ "','" + T + "')";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
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
            them(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            try
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            }
            catch
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            }
        }
    }
}
