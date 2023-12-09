using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school
{
    public partial class Main : Form
    {
        Form1 form1 = new Form1();
        string SelectedTable;
        private void DataGridViewUpdate()
        {
            SqlCommand comUpdate = new SqlCommand($"select * from {SelectedTable}", con) { CommandType = CommandType.Text };
            DataTable RefreshedTable = new DataTable();
            con.Open();
            RefreshedTable.Load(comUpdate.ExecuteReader());
            con.Close();
            dataGridView1.DataSource = RefreshedTable.DefaultView;
        }

        private void DataGridViewFill(string table)
        {
            SqlCommand comm = new SqlCommand($"select * from {table}", con) { CommandType = CommandType.Text };
            DataTable RefreshedTable = new DataTable();
            con.Open();
            RefreshedTable.Load(comm.ExecuteReader());
            con.Close();
            dataGridView1.DataSource = RefreshedTable.DefaultView;
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox8.Text = "";
        }

        public Main()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ип120ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "ip1";
            DataGridViewFill(SelectedTable);
            ClearTextBoxes();

        }

        private void ип320ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "ip3";
            DataGridViewFill(SelectedTable);
            ClearTextBoxes();

        }

        private void ир120ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "ir1";
            DataGridViewFill(SelectedTable);
            ClearTextBoxes();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand comInsert = new SqlCommand($"", con) { CommandType = CommandType.Text };
            comInsert.CommandText = $"insert into {SelectedTable} values({textBox8.Text},'{textBox1.Text}','{textBox2.Text}',{textBox3.Text},{textBox4.Text},{textBox5.Text},GetDate())";
            con.Open();
            comInsert.ExecuteNonQuery();
            con.Close();
            DataGridViewUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
            SqlCommand comDelete = new SqlCommand($"delete from {SelectedTable} where id = {id}", con) { CommandType = CommandType.Text };
            con.Open();
            comDelete.ExecuteNonQuery();
            con.Close();
            DataGridViewUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox7.Text;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querry_string = "";

            querry_string = $"select * from {SelectedTable} where Surname + Name + cast(Math as varchar(30)) + cast(RPM as varchar(30)) + cast(English as varchar(30)) like '%{str}%'";
            SqlCommand command = new SqlCommand(querry_string, con);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);

            dataGridView1.DataSource = table;
        }


    }
}
