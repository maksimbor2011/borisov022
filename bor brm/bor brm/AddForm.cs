using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bor_brm
{
    public partial class AddForm : Form
    {
        Database connect = new Database();
        MySqlCommand command;
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        public AddForm()
        {
            InitializeComponent();
            connect.Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.cn.Close();
                connect.cn.Open();
                command = new MySqlCommand("INSERT INTO bor (Id, Login) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "')", connect.cn);
                command.ExecuteNonQuery();

                connect.cn.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT* FROM positions" ;
            using (MySqlCommand cmd = new MySqlCommand(sql, connect.cn))
            {
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new
                MySqlDataAdapter(cmd);
                adapter.Fill(table);
                comboBox1.ValueMember = " position_id " ;
                comboBox1.DisplayMember = "id ";
                comboBox1.DataSource = table;
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
