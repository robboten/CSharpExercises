using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovning1
{
    public partial class Form1 : Form
    {
        Payroll employees;
        internal Form1(Payroll employees)
        {
            this.employees = employees;
            InitializeComponent();
        }

        
        public void AddStuff(Array inp)
        {
            //lblHelloWorld.Text = inp;
            listBox1.DataSource = inp;
            dataGridView1.DataSource = inp;
            dataGridView1.AutoResizeColumns();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblHelloWorld.Text = "Hello World!";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            employees.AddItem();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
