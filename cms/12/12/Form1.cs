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

namespace _12
{
    public partial class Form1 : Form
    {

        private readonly UserService userService = new UserService();

       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;
            string userType = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please fill in all fields and select a user type.");
                return;
            }
            if (userService.ValidateUser(username, password, userType, out string message))
            {
                MessageBox.Show(message);
                OpenFormBasedOnUserType(comboBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show(message);
            }

        }
        private void OpenFormBasedOnUserType(int userTypeIndex)
        {
            Form targetForm;

            switch (userTypeIndex)
            {
                case 0:
                    targetForm = new Form2(); // Admin
                    break;
                case 1:
                    targetForm = new Form4(); // Manager
                    break;
                case 2:
                    targetForm = new Form5(); // Employee
                    break;
                default:
                    targetForm = null;
                    break;
            }

            if (targetForm != null)
            {
                targetForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Unexpected user type index.");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

       


        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
