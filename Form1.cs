using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            strokiA.ReadOnly = true;
            stolbciA.ReadOnly = true;

            int k = 0;
            string str = strokiA.Text;
            k = Convert.ToInt32(str);
            for (int i = 1; i <= k; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Visible = true;
                textBox.Location = new System.Drawing.Point(26, 305 + 20*i);
                textBox.Size = new System.Drawing.Size(303, 20);
                Controls.Add(textBox);
                textBox.Name = "textBox" + i;
     
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}