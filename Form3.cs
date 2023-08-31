using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form3 : Form
    {
        private string generatedPassword;
        string loginUser = "";
        string passUser = "";
        private void SendEmail(string recipient, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sashalatkivskiy@gmail.com");
                mail.To.Add(recipient);
                mail.Subject = "Ваш пароль";
                mail.Body = $"Ваш пароль для підтвердження: {password}";

                smtpServer.Port = 587;       
                smtpServer.Credentials = new NetworkCredential("sashalatkivskiy@gmail.com", "emuvqvdggrhshtbg");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка надсилання електронного листа: " + ex.Message.ToString());

            }
        }
        private string GeneratePassword()
        {
            Random random = new Random();
            int password = random.Next(10000000, 99999999); // Генерувати випадкове 8-значне число
            return password.ToString();
        }
        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form_autofication_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button2.Enabled = false;
        }


        static bool IsLoginValid(string login) {
            string expectedEnding = "@gmail.com";
            return login.EndsWith(expectedEnding, StringComparison.OrdinalIgnoreCase);
        }

        private void button1_Click_1(object sender, EventArgs e) {
            textBox1.Enabled = true;
            button2.Enabled = true;

            generatedPassword = GeneratePassword();
            if (!IsLoginValid(textBox1.Text)) {
                MessageBox.Show("Некоректні дані!", "Error");
                return;
            }
            MessageBox.Show("Пароль надіслано на вашу електронну адресу.");
            SendEmail(textBox1.Text, generatedPassword);
            textBox2.Enabled = true;
        }

            private void button2_Click_1(object sender, EventArgs e) {
            DataBase dataBase = new DataBase();
            if (textBox2.Text == generatedPassword) {
                string queryString = $"insert into register(login_user, password_user) values('{loginUser}', '{passUser}')";
                SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
                dataBase.openConnection();

                this.Hide();
                Form1 form = new Form1();
                form.Show();

                if (command.ExecuteNonQuery() == 1) {
                    MessageBox.Show("Акаунт успішно створений", "Успіх!");
                }
                else {
                    MessageBox.Show("Акаунт не створений!");
                }
                dataBase.closeConnection();
            }
            else {
                // Пароль не співпадає, показуємо повідомлення про помилку
                MessageBox.Show("Неправильний пароль. Вхід заборонено.");
            }
        }
        public Form3(string login, string password) {
            InitializeComponent();
            this.loginUser = login;
            this.passUser = password;
            textBox2.Enabled = false;
            button2.Enabled = false;
        }
        private void Form3_Load(object sender, EventArgs e) {
            this.Text = "Аутентифікація";
        }
    }
    }
