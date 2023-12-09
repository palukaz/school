using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            Main main = new Main();
            if (password == "admin" && login == "admin")
            {
                MessageBox.Show("Добро пожаловать!");
                this.Hide();
                main.Show();
            }
            else if (login == "student" && password == "student")
            {
                MessageBox.Show("Добро пожаловать!");
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
