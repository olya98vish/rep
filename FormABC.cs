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
            //SetReadOnlyInTextBoxA();.
            for (int i = 1; i < 16; i++)
            {
                this.Controls["A" + i.ToString()].Enabled = false;
                this.Controls["B" + i.ToString()].Enabled = false;
                this.Controls["C" + i.ToString()].Enabled = false;
            }
        }
        //private void SetReadOnlyInTextBoxA(Control.ControlCollection control)
        //{
        //    foreach (Control _control in control)
        //    {
        //        if (_control is TextBox & _control.Name.Contains("A"))
        //            ((TextBox)_control).ReadOnly = true;
        //    }
        //}

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
            if ((a_stroki.Text != "") && (a_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(a_stroki.Text) > 0) && (Convert.ToInt32(a_stroki.Text) > 0))
                {
                    if (button2.Text == "ОК")
                    {
                        a_stroki.ReadOnly = true;
                        a_stolbci.ReadOnly = true;
                        button2.Text = "Изменить";

                        strA = Convert.ToInt32(a_stroki.Text);
                        stlbA = Convert.ToInt32(a_stolbci.Text);

                        a_stolbci.ReadOnly = true;
                        a_stroki.ReadOnly = true;

                        b_stroki.Text = strA.ToString();
                        b_stroki.ReadOnly = true;
                        c_stolbci.Text = stlbA.ToString();
                        c_stolbci.ReadOnly = true;

                        //активация нужных строк из текстбоксов, остальное неактивно
                        for (int i = 1; i <= strA; i++)
                        {
                            this.Controls["A" + i.ToString()].Enabled = true;
                        }
                    }
                    else
                    {
                        button2.Text = "ОК";
                        a_stroki.ReadOnly = false;
                        a_stolbci.ReadOnly = false;

                        a_stroki.Clear();
                        a_stolbci.Clear();
                        b_stroki.Clear();
                        c_stolbci.Clear();
                    }
                }
                else
                {
                    a_stolbci.Clear();
                    a_stroki.Clear();
                    MessageBox.Show("Значения числа строк и столбцов должны быть положительными!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                a_stolbci.Clear();
                a_stroki.Clear();
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