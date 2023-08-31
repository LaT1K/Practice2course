using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class task2 : Form {
        public task2() {
            InitializeComponent();
        }
        string filePath = "result.txt";
        int i = 2;
        double sum = 0;
        private double function(int i) {
            return Math.Round((Math.Sqrt(i) - 1) / (Math.Pow(i, 2) - 2 * i + 5), 4);
        }


        private void Form3_Load(object sender, EventArgs e) {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            label1.Text = "i =";
            label4.Text = "";
            this.Text = "Завдання 2";
        }

        private void вивестиДаніЗФайлуНаЕкранToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                listBox1.Items.Clear();
                var MyReader = new System.IO.StreamReader(filePath, System.Text.Encoding.GetEncoding("UTF-8"));
                string line;
                listBox1.Items.Add("Дані з файлу");

                while ((line = MyReader.ReadLine()) != null) {
                    listBox1.Items.Add(line);
                }

                MyReader.Close();
                label4.Text = Math.Round(sum, 4).ToString();
            }
            catch (Exception) {

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '-' && ((TextBox)sender).SelectionStart == 0) {
                e.Handled = false;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1)) {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            try {
                i = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception) {
                i = 2;
            }

        }

        private void обрахуватиToolStripMenuItem_Click(object sender, EventArgs e) {

            double y = function(i); ;
            if (checkBox1.Checked) {
                sum = 0;
                listBox1.Items.Clear();
                if (y > 0.0001) {
                    listBox1.Items.Add("i \t y");
                    while (y > 0.0001) {
                        listBox1.Items.Add($"{i++} \t {y} \r\n");
                        y = function(i);
                        sum += y;
                    }
                    listBox1.Items.Add($"Сума ряду = {Math.Round(sum, 4)} \r\n");
                    label4.Text = Math.Round(sum, 4).ToString();
                }
                else {
                    listBox1.Items.Add("Неможливо протабулювати функцію");
                }

            }
            try {
                i = Convert.ToInt32(textBox1.Text);
            }
            catch {
                i = 2;
            }
            y = function(i);
            if (checkBox2.Checked) {
                sum = 0;
                if (y > 0.0001) {
                    using (StreamWriter writer = new StreamWriter(filePath)) {
                        writer.Write("i" + "\t" + "y" + "\r\n");
                    }
                    while (y > 0.0001) {
                        y = function(i);
                        if (y > 0.0001) {
                            using (StreamWriter writer = new StreamWriter(filePath, true)) {
                                writer.Write($"{i++} \t {y} \r\n");
                            }
                            sum += y;
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(filePath, true)) {
                        writer.Write($"Сума ряду = {Math.Round(sum, 4)} \r\n");
                    }
                    MessageBox.Show("Дані були записані у файл");
                }
            }
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e) {
            description2 description2 = new description2();
            description2.ShowDialog();
        }
    }
}
