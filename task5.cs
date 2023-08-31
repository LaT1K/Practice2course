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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1 {
    public partial class task5 : Form {
        public task5() {
            InitializeComponent();
        }
        bool searchByName = false;
        bool editing = false;
        private void записToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "") {
                    MessageBox.Show("Не введені всі дані!");
                    return;
                }

                string name = textBox2.Text;
                string surname = textBox3.Text;
                string phoneNumber = textBox4.Text;

                bool userExists = CheckUserExists(name, surname, phoneNumber);
                if (userExists) {
                    MessageBox.Show("Користувач вже існує!");
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    return;
                }

                dataGridView1.Rows.Add(name, surname, phoneNumber);

                int n = dataGridView1.RowCount;
                Person[] array = new Person[n - 1];

                for (int i = 0; i < n - 1; i++) {
                    array[i] = new Person {
                        name = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
                        surname = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value),
                        phoneNumber = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value),
                    };
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create))) {
                    foreach (Person record in array) {
                        writer.Write(record.name);
                        writer.Write(record.surname);
                        writer.Write(record.phoneNumber);
                    }
                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch (Exception) {
                
            }
        }

        private bool CheckUserExists(string name, string surname, string phoneNumber) {
            int n = dataGridView1.RowCount;
            for (int i = 0; i < n - 1; i++) {
                string existingName = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                string existingSurname = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                string existingPhoneNumber = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);

                if (name == existingName && surname == existingSurname && phoneNumber == existingPhoneNumber) {
                    return true;
                }
            }
            return false;
        }
        private void читанняToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                List<Person> records = new List<Person>();

                using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open))) {
                    while (reader.BaseStream.Position < reader.BaseStream.Length) {
                        Person record = new Person {
                            name = reader.ReadString(),
                            surname = reader.ReadString(),
                            phoneNumber = reader.ReadString(),

                        };

                        records.Add(record);
                    }
                }

                dataGridView1.Rows.Clear();

                foreach (Person record in records) {
                    dataGridView1.Rows.Add(record.name, record.surname, record.phoneNumber);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("This file does not exist!");
            }
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                dataGridView1.Rows.Clear();
            }
            catch (Exception) {

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            try {
                List<Person> records = new List<Person>();

                using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open))) {
                    while (reader.BaseStream.Position < reader.BaseStream.Length) {
                        Person record = new Person {
                            name = reader.ReadString(),
                            surname = reader.ReadString(),
                            phoneNumber = reader.ReadString(),

                        };

                        records.Add(record);
                    }
                }

                dataGridView2.Rows.Clear();

                foreach (Person record in records) {
                    if(textBox1.Text == "") {
                        dataGridView2.Rows.Clear();
                    }
                    else if (record.name.StartsWith(textBox1.Text))
                    dataGridView2.Rows.Add(record.name, record.surname, record.phoneNumber);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("This file does not exist!");
            }
        }

        private void умоваToolStripMenuItem_Click(object sender, EventArgs e) {
            description5 description5 = new description5();
            description5.ShowDialog();
        }

        private void task5_Load(object sender, EventArgs e) {
            this.Text = "Завдання 5";
            label1.Visible = false;
            textBox1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;

        }

        private void пошукПоІменіToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!searchByName) {
                label1.Visible = true;
                textBox1.Visible = true;
                dataGridView2.Visible = true;
                searchByName = true;
            }
            else {
                label1.Visible = false;
                textBox1.Visible = false;
                dataGridView2.Visible = false;
                searchByName = false;
            }
            
        }

        private void видалитиРядокToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (dataGridView1.SelectedCells.Count > 0) {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    // Remove the selected row from the DataGridView
                    dataGridView1.Rows.RemoveAt(rowIndex);

                    // Remove the corresponding data from the binary file
                    List<Person> records = new List<Person>();

                    using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open))) {
                        while (reader.BaseStream.Position < reader.BaseStream.Length) {
                            Person record = new Person {
                                name = reader.ReadString(),
                                surname = reader.ReadString(),
                                phoneNumber = reader.ReadString()
                            };

                            records.Add(record);
                        }
                    }

                    // Validate the rowIndex
                    if (rowIndex >= 0 && rowIndex < records.Count) {
                        // Remove the record at the given index
                        records.RemoveAt(rowIndex);

                        // Save the modified data back to the binary file
                        using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create))) {
                            foreach (Person record in records) {
                                writer.Write(record.name);
                                writer.Write(record.surname);
                                writer.Write(record.phoneNumber);
                            }
                        }
                    }
                    else {
                        MessageBox.Show($"Invalid row index: {rowIndex}\nRecord count: {records.Count}");
                    }
                }
            }
            catch (Exception) {

            }   
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) {
                e.Handled = true;
            }
        }

        private void видалитиВсіДаніToolStripMenuItem_Click(object sender, EventArgs e) {
            using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create))) {
            }
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            // Allow backspace key
            if (e.KeyChar == '\b') {
                return;
            }
            if (textBox.Text.Length == 0 && char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
            // Allow "+" sign at the start
            if (textBox.Text.Length == 0 && e.KeyChar == '+') {
                return;
            }

            // Allow only numeric digits
            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true; // Ignore the input
            }

            // Allow only a maximum of 12 characters
            if (textBox.Text.Length >= 13 && e.KeyChar != '\b') {
                e.Handled = true; // Ignore the input
            }
        }

        private void редагуванняToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!editing) {
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
            }
        }

        private void вToolStripMenuItem_Click(object sender, EventArgs e) {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (textBox5.Text == string.Empty || textBox6.Text == string.Empty || textBox7.Text == string.Empty) {
                    MessageBox.Show("Ви не вибрали студента", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    if (textBox8.Text == string.Empty || textBox9.Text == string.Empty || textBox10.Text == string.Empty) {
                        MessageBox.Show("Заповніть необхідні поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else {
                        string surname1 = textBox5.Text;
                        string name1 = textBox6.Text;
                        string phone1 = textBox7.Text;
                        string surname2 = textBox8.Text;
                        string name2 = textBox9.Text;
                        string phone2 = textBox10.Text;
                        using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
                        using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin" + ".tmp", FileMode.Create))) {
                            while (reader.PeekChar() > -1) {
                                string fileSurname = reader.ReadString();
                                string fileName = reader.ReadString();
                                string filePhone = reader.ReadString();
                                if (surname1 == fileSurname && name1 == fileName && phone1 == filePhone) {
                                    writer.Write(surname2);
                                    writer.Write(name2);
                                    writer.Write(phone2);
                                }
                                else {
                                    writer.Write(fileSurname);
                                    writer.Write(fileName);
                                    writer.Write(filePhone);
                                }
                            }
                        }

                        File.Delete("data.bin");
                        File.Move("data.bin" + ".tmp", "data.bin");

                        dataGridView1.Rows.Clear();
                        dataGridView2.Rows.Clear();
                    }
                }
            }
            catch (Exception) {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
                try {
                    if (e.RowIndex >= 0) {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                        textBox5.Text = row.Cells[0].Value.ToString();
                        textBox6.Text = row.Cells[1].Value.ToString();
                        textBox7.Text = row.Cells[2].Value.ToString();

                        textBox8.Text = row.Cells[0].Value.ToString();
                        textBox9.Text = row.Cells[1].Value.ToString();
                        textBox10.Text = row.Cells[2].Value.ToString();

                    }
                }
                catch {
                    MessageBox.Show("Помилка");
                }
        }
    }
}
