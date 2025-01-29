using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12
{
    public partial class speaker : Form
    {
        public speaker()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


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

            speaker Session = new speaker();
            Session.StartPosition = FormStartPosition.Manual;
            Session.Location = this.Location;
            Session.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 

        }
        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
    