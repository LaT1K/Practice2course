using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class task1 : Form {
        int[] m_p = new int[6];
        double medianA;
        double medianB;
        double medianC;
        double areaOfTriangle;
        public task1() {
            InitializeComponent();
        }

        private bool isTriangleExist(double x1, double y1, double x2, double y2, double x3, double y3) {
            double AB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double BC = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double AC = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));

            if (AB + BC > AC && AB + AC > BC && BC + AC > AB) {
                return true;
            }
            return false;
        }
        private double findDistanceBetweenPoints(int x1, int y1, int x2, int y2) {
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        private double findMedian(double a, double b, double c) {

            return Math.Sqrt(2 * Math.Pow(a, 2) + 2 * Math.Pow(b, 2) - Math.Pow(c, 2)) / 2;
        }
        private double findAreaOFTriangle(double mA, double mB, double mC) {
            return (double)(1.0 / 3) * Math.Sqrt((mA + mC - mB) * (mB + mC - mA) * (mA + mB - mC)) * Math.Sqrt(mA + mC + mB);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            switch (comboBox1.SelectedIndex) {
                case 0:
                    label1.Text = string.Format("= {0:F4}", medianA);
                    break;
                case 1:
                    label1.Text = string.Format("= {0:F4}", medianB);
                    break;
                case 2:
                    label1.Text = string.Format("= {0:F4}", medianC);
                    break;
                default:
                    break;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) {
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

        private void Form2_Load(object sender, EventArgs e) {
            label1.Text = "";
            label2.Text = "";
            comboBox1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void обрахуватиToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                m_p[0] = Convert.ToInt32(textBox1.Text);//x1
                m_p[1] = Convert.ToInt32(textBox2.Text);//y1
                m_p[2] = Convert.ToInt32(textBox3.Text);//x2
                m_p[3] = Convert.ToInt32(textBox4.Text);//y2
                m_p[4] = Convert.ToInt32(textBox5.Text);//x3
                m_p[5] = Convert.ToInt32(textBox6.Text);//y3
                if (!isTriangleExist(m_p[0], m_p[1], m_p[2], m_p[3], m_p[4], m_p[5])) {
                    MessageBox.Show("Трикутника з такими координатами не існує", "Error");
                    return;
                }
                double a = findDistanceBetweenPoints(m_p[0], m_p[1], m_p[2], m_p[3]);
                double b = findDistanceBetweenPoints(m_p[0], m_p[1], m_p[4], m_p[5]);
                double c = findDistanceBetweenPoints(m_p[2], m_p[3], m_p[4], m_p[5]);
                medianA = findMedian(b, c, a);
                medianB = findMedian(a, c, b);
                medianC = findMedian(a, b, c);
                areaOfTriangle = findAreaOFTriangle(medianA, medianB, medianC);
                label9.Visible = true;
                comboBox1.Visible = true;
                label2.Visible = true;
                label2.Text = string.Format("Площа трикутника = {0:F4}", areaOfTriangle);
                comboBox1.Visible = true;
                pictureBox1.Visible = true;
                label1.Text = "";
            }
            catch (Exception) {
                MessageBox.Show("Спочатку введіть координати трикутника", "Error");
            }
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e) {
            description1 description1 = new description1();
            description1.ShowDialog();
        }

        private void task1_Load(object sender, EventArgs e) {
            this.Text = "Завдання 1";
            label9.Visible = false;
            comboBox1.Visible = false;
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            pictureBox1.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            comboBox1.Visible = false;
            label2.Visible = false;
        }
    }
}
