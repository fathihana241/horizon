using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Data.SqlClient;

namespace _12
{
    public partial class Se : Form
    {
        private dbHelper DatabaseHelper;
        public Se()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form1 = new Form2();
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = this.Location;
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Se Session = new Se();
            Session.StartPosition = FormStartPosition.Manual;
            Session.Location = this.Location;
            Session.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (check == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           if(dataGridViewSessions.SelectedRows.Count > 0)
    {
                string SessionTitle = dataGridViewSessions.SelectedRows[0].Cells["SessionTitle"].Value.ToString();

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the session '{SessionTitle}'?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbHelper dbHelper = new dbHelper();
                    bool isDeleted = dbHelper.DeleteSession(SessionTitle);

                    if (isDeleted)
                    {
                        MessageBox.Show($"Session '{SessionTitle}' deleted successfully!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Refresh the DataGridView
                        RefreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete session. Please try again.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
    else
            {
                MessageBox.Show("Please select a session to delete.",
                                "No Selection",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Get data from the form
                Sessio session = new Sessio
                {
                    SessionTitle = textBox1.Text,
                    Venue = textBox2.Text,
                    Duration = comboBox1.SelectedItem.ToString(),
                    SessionType = comboBox2.SelectedItem.ToString(),
                    Date = dtpDate.Value,
                    SpeakerName = textBox6.Text,
                    SpeakerRole = comboBox4.SelectedItem.ToString(),
                    ParticipantsCapacity = int.Parse(textBox3.Text),
                    SessionStatus = comboBox5.SelectedItem.ToString()
                };

                // Insert into the database
                dbHelper dbHelper = new dbHelper();
                bool isAdded = dbHelper.AddSession(session);

                if (isAdded)
                {
                    MessageBox.Show("Session added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the DataGridView
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Failed to add session. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataGridView()
        {
            dbHelper dbHelper = new dbHelper();
            dataGridViewSessions.DataSource = dbHelper.GetSessions();
        }


        private void Se_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            speaker Session = new speaker();
            Session.StartPosition = FormStartPosition.Manual;
            Session.Location = this.Location;
            Session.Show();
            this.Hide();
        }
    }

}
    

