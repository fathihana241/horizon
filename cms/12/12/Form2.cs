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
using System.Data.SqlTypes;

namespace _12
{
    public partial class Form2 : Form
    {
        private databasehelper dbhelper;

      
        public Form2()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-ARKJQQOS\\SQLEXPRESS01;Initial Catalog=us_pw;Integrated Security=True;";
            dbhelper = new databasehelper(connectionString);
            LoadDataGridView();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?","Confirmation Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);


            if (check == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form1 = new Form2();
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location=this.Location;
            form1.Show();
            this.Hide();
        }

        private void session_Click(object sender, EventArgs e)
        {
            Se Session = new Se();
            Session.StartPosition = FormStartPosition.Manual;
            Session.Location=this.Location;
            Session.Show();
            this.Hide();

        }

        private void speaker_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string conferenceName = textBox1.Text;
            string venue = textBox2.Text;
            string status = comboBox1.SelectedItem.ToString();
            DateTime date = dtpDate.Value;


            Conference conference = new Conference(conferenceName, venue, status, date);

            // Insert into database
            dbhelper.InsertConference(conference.ConferenceName, conference.Venue, conference.Status, conference.Date);

            // Refresh DataGridView
            LoadDataGridView();

            // Clear input fields
            ClearFields();

        }
        private void LoadDataGridView()
        {
            DataTable conferencesTable = dbhelper.GetAllConferences();
            dataGridViewConferences.DataSource = conferencesTable;
        }

        private void ClearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewConferences.SelectedRows.Count > 0)
            {
                // Get the ConferenceName of the selected row
                string selectedName = dataGridViewConferences.SelectedRows[0].Cells["ConferenceName"].Value.ToString();

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the conference: {selectedName}?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Delete the conference from the database
                    bool isDeleted = dbhelper.DeleteConference(selectedName);

                    if (isDeleted)
                    {
                        // Reload the DataGridView to reflect changes
                        LoadDataGridView();

                        MessageBox.Show("Conference deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the conference. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a conference to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speaker Session = new speaker();
            Session.StartPosition = FormStartPosition.Manual;
            Session.Location = this.Location;
            Session.Show();
            this.Hide();

        }
    }
}
