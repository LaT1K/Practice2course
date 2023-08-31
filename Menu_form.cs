using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Menu_form : Form {
        public Menu_form() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            task1 task1 = new task1();
            task1.ShowDialog();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            task2 task2 = new task2();
            task2.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            task3 task3 = new task3();
            task3.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            task4 task4 = new task4();
            task4.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) {
            task5 task5 = new task5();
            task5.ShowDialog();
        }

        private void Menu_form_Load(object sender, EventArgs e) {
            this.Text = "Меню";
        }

        private void допомогаToolStripMenuItem_Click(object sender, EventArgs e) {
            help help = new help();
            help.ShowDialog();
        }

        private void проПроектToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Проект підготував Латківський Олександр");
        }

    }
}
