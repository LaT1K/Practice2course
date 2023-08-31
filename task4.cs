using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1 {
    public partial class task4 : Form {
        Random random = new Random();
        int[,] arr;
        int rows = 0, cols = 0, lowerBorder = 0, upperBorder = 0;
        bool negativeElement = false;
        public task4() {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
        private void fillArray(int[,] arr, int rows, int cols) {
            negativeElement = false;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    arr[i, j] = random.Next(lowerBorder, upperBorder + 1);
                    if (arr[i, j] < 0) {
                        negativeElement = true;
                    }
                }
            }
        }
        private int findProductNegativeElements(int[,] arr, int rows, int cols) {
            int product = 1;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (arr[i, j] < 0) {
                        product *= arr[i, j];
                    }
                }
            }
            return product;
        }
        private string findIndexMaxElement(int[,] arr, int rows, int cols) {
            string indexes = "";
            int maxElement = arr[0, 0];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (maxElement < arr[i, j]) {
                        maxElement = arr[i, j];
                    }
                }
            }
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (maxElement == arr[i, j]) {
                        indexes += ($"[{i + 1};{j + 1}]\t");
                    }
                }
            }
            return indexes;
        }
        private void обрахуватиToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                rows = Convert.ToInt32(textBox1.Text);
                cols = Convert.ToInt32(textBox2.Text);
                if (rows == 0 || cols == 0) {
                    MessageBox.Show("Некоректні дані", "Error");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    return;
                }
                arr = new int[rows, cols];
                lowerBorder = Convert.ToInt32(textBox4.Text);
                upperBorder = Convert.ToInt32(textBox3.Text);
                if (lowerBorder > upperBorder) {
                    MessageBox.Show("Некоректні дані", "Error");
                    textBox3.Text = "";
                    textBox4.Text = "";
                    return;
                }
                fillArray(arr, rows, cols);
                MessageBox.Show("Масив заповнений", "Error");
            }
            catch (Exception) {

            }

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '-' && ((System.Windows.Forms.TextBox)sender).SelectionStart == 0) {
                e.Handled = false;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '-' && ((System.Windows.Forms.TextBox)sender).SelectionStart == 0) {
                e.Handled = false;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e) {
            description4 description4 = new description4();
            description4.ShowDialog();
        }

        private void вивестиДаніНаЕкранToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                listBox1.Items.Clear();
                for (int i = 0; i < rows; i++) {
                    string rowString = string.Empty;
                    for (int j = 0; j < cols; j++) {
                        rowString += arr[i, j] + "\t";
                    }
                    listBox1.Items.Add(rowString);
                }
                if (negativeElement) {
                    label9.Text = findProductNegativeElements(arr, rows, cols).ToString();
                }
                else if (!negativeElement && arr != null) {
                    label9.Text = "Немає від'ємних елементів";
                }

                label10.Text = findIndexMaxElement(arr, rows, cols);
            }
            catch (Exception) {

            }

        }

        private void Form6_Load(object sender, EventArgs e) {
            label9.Text = "";
            label10.Text = "";
            this.Text = "Завдання 4";
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            listBox1.Items.Clear();
            label9.Text = "";
            label10.Text = "";
        }
    }
}
