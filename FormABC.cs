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
    public partial class FormABC : Form
    {
        public FormABC()
        {
            InitializeComponent();
        }

        private void FormABC_Load(object sender, EventArgs e)
        {
            A.RowCount = 15;
            A.ColumnCount = 15;

            B.RowCount = 15;
            B.ColumnCount = 15;

            C.RowCount = 15;
            C.ColumnCount = 15;

            //отрисовка границ на форме
            //Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
            //e.Graphics.DrawRectangle(blackPen, 10, 10, 100, 50);

            //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //e.Graphics.DrawLine(pen, 20, 10, 300, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int strA = 0;
            int stlbA = 0;
            if ((strokiA.Text != "") && (stolbciA.Text != ""))
            {
                if ((Convert.ToInt32(strokiA.Text) > 0) && (Convert.ToInt32(strokiA.Text) > 0))
                {
                    if (button2.Text == "ОК")
                    {
                        strokiA.ReadOnly = true;
                        stolbciA.ReadOnly = true;
                        button2.Text = "Изменить";

                        strA = Convert.ToInt32(strokiA.Text);
                        stlbA = Convert.ToInt32(stolbciA.Text);

                        stolbciA.ReadOnly = true;
                        strokiA.ReadOnly = true;

                        strokiB.Text = strA.ToString();
                        strokiB.ReadOnly = true;
                        stolbciC.Text = stlbA.ToString();
                        stolbciC.ReadOnly = true;

                    }
                    else
                    {
                        button2.Text = "ОК";
                        strokiA.ReadOnly = false;
                        stolbciA.ReadOnly = false;

                        strokiA.Clear();
                        stolbciA.Clear();
                        strokiB.Clear();
                        stolbciC.Clear();
                    }
                }
                else
                {
                    stolbciA.Clear();
                    strokiA.Clear();
                    MessageBox.Show("Значения числа строк и столбцов должны быть положительными!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                stolbciA.Clear();
                strokiA.Clear();
                MessageBox.Show("Введите число строк и столбцов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}