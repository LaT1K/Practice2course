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

namespace WindowsFormsApp1 {
    public partial class Form2 : Form {
        DataBase dataBase = new DataBase();
        public Form2() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e) {
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            this.Text = "Реєстрація";
        }
        string loginUser = "";
        string passUser = "";
        private void button1_Click(object sender, EventArgs e) {
            loginUser = textBox1.Text;
            passUser = textBox2.Text;
            var repeatedPassword = textBox3.Text;

            if (checkUser()) {
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") {
                return;
            }
            if (passUser != repeatedPassword) {
                MessageBox.Show("Паролі не співпадають");
                return;
            }
            Form3 form = new Form3(loginUser, passUser);
            form.Show();
            //this.Hide();
        }
        private Boolean checkUser() {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0) {
                MessageBox.Show("Такий користувач вже існує!", "Error");
                return true;
            }
            else {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

    }
}
