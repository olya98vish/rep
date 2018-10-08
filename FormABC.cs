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
            if ((strokiA.Text != "") && (stolbciA.Text != ""))
            {
                if ((Convert.ToInt32(strokiA.Text) > 0) && (Convert.ToInt32(strokiA.Text) > 0))
                {
                    stolbciA.ReadOnly = true;
                    strokiA.ReadOnly = true;

                    if (button2.Text == "ОК")
                    {
                        strokiA.ReadOnly = true;
                        stolbciA.ReadOnly = true;
                        button2.Text = "Изменить";


                        //DataGridViewTextBoxColumn clmnA = new DataGridViewTextBoxColumn();
                        //int rows = 0;
                        //string str = strokiA.Text;
                        //rows = Convert.ToInt32(str);
                        //int clmn = 0;
                        //string str1 = strokiA.Text;
                        //clmn = Convert.ToInt32(str1);

                        //clmnA.Width = 100;
                        ////datagrA.Rows.Add(rows);
                        //A.Columns.Add(clmnA);

                        //int k = 0;
                        //string str = strokiA.Text;
                        //k = Convert.ToInt32(str);
                        //for (int i = 1; i <= k; i++)
                        //{
                        //    TextBox textBox = new TextBox();
                        //    textBox.Visible = true;
                        //    textBox.Location = new System.Drawing.Point(100, 100 + 20 * i);
                        //    textBox.Size = new System.Drawing.Size(303, 20);
                        //    Controls.Add(textBox);
                        //    textBox.Name = "textBox" + i;
                    }
                    else
                    {
                        button2.Text = "ОК";
                        strokiA.ReadOnly = false;
                        stolbciA.ReadOnly = false;
                        strokiA.Clear();
                        stolbciA.Clear();
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
                MessageBox.Show("Введите числа строк и столбцов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }

    }
}