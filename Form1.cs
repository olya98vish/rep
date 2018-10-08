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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked) && (checkBox2.Checked))
            {
                Form formABC = new FormABC();
                formABC.Show();
                this.Hide();
            }
            else if (checkBox1.Checked)
            {
                Form formAB = new FormAB();
                formAB.Show();
                this.Hide();
            }
            else if (checkBox2.Checked)
            {
                Form formAC = new FormAC();
                formAC.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Хотя бы одна позиция должна быть выбрана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if((checkBox1.Checked == true) && (checkBox2.Checked == true))//+
            {
                label1.Text = "x = Ax + Bu";
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(273, 26);//x
       
                label2.Visible = true;
                label2.Location = new System.Drawing.Point(273, 94);//y

                label3.Visible = true;
                label3.Location = new System.Drawing.Point(275, -4);//.

                label4.Visible = true;
                label4.Location = new System.Drawing.Point(275, 64);//.
            }
            if ((checkBox1.Checked == true) && (checkBox2.Checked == false))//+
            {
                label1.Text = "x = Ax + Bu";
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(273, 52);//x

                label2.Visible = false;
                label2.Location = new System.Drawing.Point(273, 71);//y

                label3.Visible = true;
                label3.Location = new System.Drawing.Point(275, 22);//.

                label4.Visible = false;
                label4.Location = new System.Drawing.Point(280, 64);//.
            }
            if ((checkBox1.Checked == false) && (checkBox2.Checked == true))
            {
                label1.Text = "x = Ax";
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(273, 26);//x

                label2.Visible = true;
                label2.Location = new System.Drawing.Point(273, 94);//y

                label3.Visible = true;
                label3.Location = new System.Drawing.Point(275, -4);//.

                label4.Visible = true;
                label4.Location = new System.Drawing.Point(275, 64);//.
            }
            if ((checkBox1.Checked == false) && (checkBox2.Checked == false))//+
            {
                label1.Text = "x = Ax + Bu";
                label1.Visible = false;
                label1.Location = new System.Drawing.Point(273, 26);//x

                label2.Visible = false;
                label2.Location = new System.Drawing.Point(273, 94);//y

                label3.Visible = false;
                label3.Location = new System.Drawing.Point(275, -4);//.

                label4.Visible = false;
                label4.Location = new System.Drawing.Point(275, 64);//.
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox1.Checked == true) && (checkBox2.Checked == true))//+
            {
                label1.Text = "x = Ax + Bu";
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(273, 26);//x

                label2.Visible = true;
                label2.Location = new System.Drawing.Point(273, 94);//y

                label3.Visible = true;
                label3.Location = new System.Drawing.Point(275, -4);//.

                label4.Visible = true;
                label4.Location = new System.Drawing.Point(275, 64);//.
            }
            if ((checkBox1.Checked == false) && (checkBox2.Checked == true))
            {
                label1.Text = "x = Ax";
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(273, 26);//x

                label2.Visible = true;
                label2.Location = new System.Drawing.Point(273, 94);//y

                label3.Visible = true;
                label3.Location = new System.Drawing.Point(275, -4);//.

                label4.Visible = true;
                label4.Location = new System.Drawing.Point(275, 64);//.
            }
            if ((checkBox1.Checked == true) && (checkBox2.Checked == false))//+
            {
                label1.Text = "x = Ax + Bu";
                label1.Visible = true;
                label1.Location = new System.Drawing.Point(273, 52);//x

                label2.Visible = false;
                label2.Location = new System.Drawing.Point(273, 71);//y

                label3.Visible = true;
                label3.Location = new System.Drawing.Point(275, 22);//.

                label4.Visible = false;
                label4.Location = new System.Drawing.Point(280, 64);//.
            }
            if ((checkBox1.Checked == false) && (checkBox2.Checked == false))//+
            {
                label1.Text = "x = Ax + Bu";
                label1.Visible = false;
                label1.Location = new System.Drawing.Point(273, 26);//x

                label2.Visible = false;
                label2.Location = new System.Drawing.Point(273, 94);//y

                label3.Visible = false;
                label3.Location = new System.Drawing.Point(275, -4);//.

                label4.Visible = false;
                label4.Location = new System.Drawing.Point(275, 64);//.
            }

        }

    }
}
