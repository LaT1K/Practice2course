using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class task3 : Form {
        Random random = new Random();
        public task3() {
            InitializeComponent();
        }
        const int numberOfPeople = 15;
        int[] arr = new int[numberOfPeople];
        int counter = 0;
        string filePath = "task3.txt";
        bool allInputed = true;
        private int findNumberOfChildren(int[] arr) {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < 18) {
                    counter++;
                }
            }
            return counter;
        }
        private int findNumberOfAdultOlder50(int[] arr) {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] > 50) {
                    counter++;
                }
            }
            return counter;
        }
        private string findSerialNumberSmallestPerson(int[] arr) {
            int minAge = arr[0];
            List<int> indices = new List<int>();

            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < minAge) {
                    minAge = arr[i];
                    indices.Clear();
                }

                if (arr[i] == minAge) {
                    indices.Add(i + 1);
                }
            }

            return string.Join(", ", indices);
        }

        private void Form4_Load(object sender, EventArgs e) {
            label2.Text = "Кількість неповнолітніх = ";
            label4.Text = "Кількість старших 50 = ";
            label3.Text = "";
            label5.Text = "";
            label7.Text = "";
            using (StreamWriter writer = new StreamWriter(filePath)) {
                writer.Write("");
            }
            this.Text = "Завдання 3";
            arr[0] = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ввестиToolStripMenuItem_Click(sender, e);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
        private void вивестиДаніЗФайлуToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                listBox1.Items.Clear();
                var MyReader = new System.IO.StreamReader(filePath, System.Text.Encoding.GetEncoding("UTF-8"));
                string line;
                listBox1.Items.Add("Дані з файлу");

                while ((line = MyReader.ReadLine()) != null) {
                    listBox1.Items.Add(line);
                }

                MyReader.Close();
            }
            catch (Exception) {

            }
        }

        private void ввестиToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (allInputed) {
                    if (Convert.ToInt32(textBox1.Text) < 1 || Convert.ToInt32(textBox1.Text) > 99) {
                        MessageBox.Show("Введіть справжні дані!", "Error");
                        textBox1.Text = "";
                        return;
                    }
                    arr[counter] = Convert.ToInt32(textBox1.Text);
                    using (StreamWriter writer = new StreamWriter(filePath, true)) {
                        writer.Write(arr[counter] + " ");
                    }
                    switch (counter) {
                        case 0:
                            label8.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 1:
                            label9.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 2:
                            label10.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 3:
                            label11.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 4:
                            label12.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 5:
                            label13.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 6:
                            label14.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 7:
                            label15.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 8:
                            label16.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 9:
                            label17.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 10:
                            label18.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 11:
                            label19.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 12:
                            label20.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 13:
                            label21.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            counter++;
                            break;
                        case 14:
                            label22.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            allInputed = false;
                            textBox1.Enabled = false;
                            break;
                        default:
                            MessageBox.Show("Error", "Error");
                            break;
                    }
                }
                if (!allInputed) {
                    label3.Text = findNumberOfChildren(arr).ToString();
                    label5.Text = findNumberOfAdultOlder50(arr).ToString();
                    label7.Text = findSerialNumberSmallestPerson(arr);
                }
            }
            catch (Exception) {

                MessageBox.Show("Спочатку введіть вік", "Error");
            }
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e) {
            label8.Text = "1 =";
            label9.Text = "2 =";
            label10.Text = "3 =";
            label11.Text = "4 =";
            label12.Text = "5 =";
            label13.Text = "6 =";
            label14.Text = "7 =";
            label15.Text = "8 =";
            label16.Text = "9 =";
            label17.Text = "10 =";
            label18.Text = "11 =";
            label19.Text = "12 =";
            label20.Text = "13 =";
            label21.Text = "14 =";
            label22.Text = "15 =";
            listBox1.Items.Clear();
            textBox1.Enabled = true;
            counter = 0;
            using (StreamWriter writer = new StreamWriter(filePath)) {
                writer.Write("");
            }
            allInputed = true;
            label3.Text = "";
            label5.Text = "";
            label7.Text = "";
            arr[0] = 0;
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e) {
            description3 description3 = new description3();
            description3.ShowDialog();
        }

        private void ввестиДаніРандомноToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (arr[0] != 0) {
                    return;
                }
                arr = new int[numberOfPeople];
                for (int counter = 0; counter < 15; counter++) {           
                    arr[counter] = random.Next(1, 100);
                    using (StreamWriter writer = new StreamWriter(filePath, true)) {
                        writer.Write(arr[counter] + "\n");
                    }
                    switch (counter) {
                        case 0:
                            label8.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 1:
                            label9.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 2:
                            label10.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 3:
                            label11.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 4:
                            label12.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 5:
                            label13.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 6:
                            label14.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 7:
                            label15.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 8:
                            label16.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 9:
                            label17.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 10:
                            label18.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 11:
                            label19.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 12:
                            label20.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 13:
                            label21.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            break;
                        case 14:
                            label22.Text += ($" {arr[counter]}");
                            textBox1.Text = "";
                            allInputed = false;
                            textBox1.Enabled = false;
                            break;
                        default:
                            MessageBox.Show("Error", "Error");
                            break;
                    }
                    if (!allInputed) {
                        label3.Text = findNumberOfChildren(arr).ToString();
                        label5.Text = findNumberOfAdultOlder50(arr).ToString();
                        label7.Text = findSerialNumberSmallestPerson(arr);
                    }
                }
                }
            catch (Exception) {

                throw;
            }
        }
    }
}
