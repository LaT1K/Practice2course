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

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        DataBase dataBase = new DataBase();
        
        public Form1() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e) {
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
            this.Text = "Авторизація";
        }
        private void button1_Click(object sender, EventArgs e) {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1) {
                //MessageBox.Show("Ви успішно увійшли", "Успішно!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Menu_form menu_Form = new Menu_form();
                menu_Form.ShowDialog();
                this.Hide();
            }
            else {
                MessageBox.Show("Такого акаунту не існує", "Не існує!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Form2 form2 = new Form2();
            form2.Show();
            //this.Hide();
        }
    }
}
