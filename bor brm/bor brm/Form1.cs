using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bor_brm
{
    public partial class Form1 : Form
    {
        Database connect = new Database();
        MySqlCommand command;
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        public Form1()
        {
            InitializeComponent();
            connect.Connect();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Open();
                command = new MySqlCommand("SELECT * FROM bor" ,connect.cn);
                command.ExecuteNonQuery();
                datatable = new DataTable();
                dataadapter = new MySqlDataAdapter(command);
                dataadapter.Fill(datatable);
                dataGridView1.DataSource = datatable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void LoadData()
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand(" SELECT* FROM bor ", connect.cn);
                command.ExecuteNonQuery();
                datatable = new DataTable();
                dataadapter = new MySqlDataAdapter(command);
                dataadapter.Fill(datatable);
                dataGridView1.DataSource = datatable.DefaultView;
                connect.cn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand("DELETE FROM bor WHERE Id = '" + textBox1.Text + "'", connect.cn);
                command.ExecuteNonQuery();
                connect.cn.Close();
                LoadData();
                MessageBox.Show("Data successfully deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand(" UPDATE bor SET Login = '" +textBox2.Text + "'WHERE id = '" + textBox1.Text + "'", connect.cn);
                command.ExecuteNonQuery();
                connect.cn.Close();
                LoadData();
                MessageBox.Show("Data successfully updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}



