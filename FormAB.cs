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
    public partial class FormAB : Form
    {
        public FormAB()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FormAB_Load(object sender, EventArgs e)
        {
            //A.RowCount = 15;
            //A.ColumnCount = 15;

            //B.RowCount = 15;
            //B.ColumnCount = 15;

            for (int i = 1; i < 16; i++)
            {
                this.Controls["A" + i.ToString()].Enabled = false;
                this.Controls["B" + i.ToString()].Enabled = false;
            }
            b_stroki.ReadOnly = true;
            b_stolbci.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int strA = 0;
            int stlbA = 0;
            if ((a_stroki.Text != "") && (a_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(a_stroki.Text) > 0) && (Convert.ToInt32(a_stroki.Text) > 0))
                {
                    if (buttonA.Text == "ОК")
                    {
                        a_stroki.ReadOnly = true;
                        a_stolbci.ReadOnly = true;
                        buttonA.Text = "Изменить";

                        strA = Convert.ToInt32(a_stroki.Text);
                        stlbA = Convert.ToInt32(a_stolbci.Text);

                        a_stolbci.ReadOnly = true;
                        a_stroki.ReadOnly = true;

                        b_stroki.Text = strA.ToString();
                        b_stroki.ReadOnly = true;

                        //активация нужных строк из текстбоксов, остальное неактивно
                        for (int i = 1; i <= strA; i++)
                        {
                            this.Controls["A" + i.ToString()].Enabled = false;
                        }
                        //работа с активацией матрицы
                        A.RowCount = strA;
                        A.ColumnCount = stlbA;

                        b_stolbci.ReadOnly = false;
                    }
                    else
                    {
                        buttonA.Text = "ОК";
                        buttonB.Text = "ОК";

                        a_stroki.ReadOnly = false;
                        a_stolbci.ReadOnly = false;

                        a_stroki.Clear();
                        a_stolbci.Clear();
                        b_stolbci.Clear();
                        b_stroki.Clear();

                        //очистка текстбоксов и сделаем их неактивными
                        for (int i = 1; i < 16; i++)
                        {
                            this.Controls["A" + i.ToString()].Enabled = false;
                            this.Controls["B" + i.ToString()].Enabled = false;
                            this.Controls["A" + i.ToString()].Text = "";
                            this.Controls["B" + i.ToString()].Text = "";
                        }
                        //убиваем матрицы - все, так как матрица А главная.
                        A.RowCount = 0;
                        A.ColumnCount = 0;
                        B.RowCount = 0;
                        B.ColumnCount = 0;
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

        private void buttonB_Click(object sender, EventArgs e)
        {
            int strB = 0;
            int stlbB = 0;

            if ((b_stroki.Text != "") && (b_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(b_stroki.Text) > 0) && (Convert.ToInt32(b_stroki.Text) > 0) && (Convert.ToInt32(b_stroki.Text) == Convert.ToInt32(a_stroki.Text)))
                {
                    int strA = Convert.ToInt32(a_stroki.Text);

                    if (buttonB.Text == "ОК")
                    {
                        b_stroki.ReadOnly = true;
                        b_stolbci.ReadOnly = true;
                        buttonB.Text = "Изменить";

                        strB = Convert.ToInt32(b_stroki.Text);
                        stlbB = Convert.ToInt32(b_stolbci.Text);
                        //активация нужных строк из текстбоксов, остальное неактивно
                        for (int i = 1; i <= strB; i++)
                        {
                            this.Controls["B" + i.ToString()].Enabled = true;
                        }
                        //работа с активацией матрицы
                        B.RowCount = strB;
                        B.ColumnCount = stlbB;
                    }
                    else
                    {

                        buttonB.Text = "ОК";
                        //b_stroki.ReadOnly = false;
                        b_stolbci.ReadOnly = false;

                        b_stolbci.Clear();
                        //очистка текстбоксов и сделаем их неактивными
                        for (int i = 1; i < 16; i++)
                        {
                            this.Controls["B" + i.ToString()].Enabled = false;
                            this.Controls["B" + i.ToString()].Text = "";
                        }
                        //убиваем матрицу
                        B.RowCount = 0;
                        B.ColumnCount = 0;
                    }
                }
                else
                {
                    b_stolbci.Clear();
                    //b_stroki.Clear();
                    MessageBox.Show("Значения числа строк и столбцов должны быть положительными!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                b_stolbci.Clear();
                //b_stroki.Clear();
                MessageBox.Show("Введите число строк и столбцов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

