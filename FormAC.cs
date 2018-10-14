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
    public partial class FormAC : Form
    {
        public FormAC()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FormAC_Load(object sender, EventArgs e)
        {
            //A.RowCount = 15;
            //A.ColumnCount = 15;

            //C.RowCount = 15;
            //C.ColumnCount = 15;

            for (int i = 1; i < 16; i++)
            {
                this.Controls["A" + i.ToString()].Enabled = false;
                this.Controls["C" + i.ToString()].Enabled = false;
            }
            c_stroki.ReadOnly = true;
            c_stolbci.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int strC = 0;
            int stlbC = 0;

            if ((c_stroki.Text != "") && (c_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(c_stroki.Text) > 0) && (Convert.ToInt32(c_stroki.Text) > 0) && (Convert.ToInt32(c_stolbci.Text) == Convert.ToInt32(a_stolbci.Text)))
                {
                    int stlbA = Convert.ToInt32(a_stolbci.Text);

                    if (buttonC.Text == "ОК")
                    {
                        c_stroki.ReadOnly = true;
                        c_stolbci.ReadOnly = true;
                        buttonC.Text = "Изменить";

                        strC = Convert.ToInt32(c_stroki.Text);
                        stlbC = Convert.ToInt32(c_stolbci.Text);
                        //активация нужных строк из текстбоксов, остальное неактивно
                        for (int i = 1; i <= strC; i++)
                        {
                            this.Controls["C" + i.ToString()].Enabled = true;
                        }
                        //работа с активацией матрицы
                        C.RowCount = strC;
                        C.ColumnCount = stlbC;
                    }
                    else
                    {

                        buttonC.Text = "ОК";
                        c_stroki.ReadOnly = false;
                        //c_stolbci.ReadOnly = false;

                        c_stroki.Clear();
                        //очистка текстбоксов и сделаем их неактивными
                        for (int i = 1; i < 16; i++)
                        {
                            this.Controls["C" + i.ToString()].Enabled = false;
                            this.Controls["C" + i.ToString()].Text = "";
                        }
                        //убиваем матрицу
                        C.RowCount = 0;
                        C.ColumnCount = 0;
                    }
                }
                else
                {
                    //c_stolbci.Clear();
                    c_stroki.Clear();
                    MessageBox.Show("Значения числа строк и столбцов должны быть положительными!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //c_stolbci.Clear();
                c_stroki.Clear();
                MessageBox.Show("Введите число строк и столбцов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonA_Click(object sender, EventArgs e)
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

                        c_stolbci.Text = stlbA.ToString();
                        c_stolbci.ReadOnly = true;

                        //активация нужных строк из текстбоксов, остальное неактивно
                        for (int i = 1; i <= strA; i++)
                        {
                            this.Controls["A" + i.ToString()].Enabled = false;
                        }
                        //работа с активацией матрицы
                        A.RowCount = strA;
                        A.ColumnCount = stlbA;

                        c_stroki.ReadOnly = false;
                    }
                    else
                    {
                        buttonA.Text = "ОК";
                        buttonC.Text = "ОК";

                        a_stroki.ReadOnly = false;
                        a_stolbci.ReadOnly = false;

                        a_stroki.Clear();
                        a_stolbci.Clear();
                        c_stolbci.Clear();
                        c_stroki.Clear();

                        //очистка текстбоксов и сделаем их неактивными
                        for (int i = 1; i < 16; i++)
                        {
                            this.Controls["A" + i.ToString()].Enabled = false;
                            this.Controls["C" + i.ToString()].Enabled = false;
                            this.Controls["A" + i.ToString()].Text = "";
                            this.Controls["C" + i.ToString()].Text = "";
                        }
                        //убиваем матрицы - все, так как матрица А главная.
                        A.RowCount = 0;
                        A.ColumnCount = 0;
                        C.RowCount = 0;
                        C.ColumnCount = 0;
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
    }
}
