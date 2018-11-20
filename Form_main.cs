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
    public partial class Form_main : Form
    {
        public FormABC_view formABC_view;
        double[,] masA;//массив данных из datagrid A
        double[,] masB;//массив данных из datagrid B
        double[,] masC;//массив данных из datagrid C
        int strA = 0;
        int strB = 0;
        int strC = 0;
        int stlbA = 0;
        int stlbB = 0;
        int stlbC = 0;
        filling cl = new filling();


        public Form_main()
        {
            InitializeComponent();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            if ((a_stroki.Text != "") && (a_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(a_stroki.Text) > 0) && (Convert.ToInt32(a_stolbci.Text) > 0))
                {
                    if ((Convert.ToInt32(a_stroki.Text) < 16) && (Convert.ToInt32(a_stolbci.Text) < 16))
                    {
                        if (buttonA.Text == "ОК")
                        {
                            button4.Enabled = true;
                            button5.Enabled = true;
                            button6.Enabled = true;
                            button7.Enabled = true;
                            button9.Enabled = true;
                            button10.Enabled = true;

                            a_stroki.ReadOnly = true;
                            a_stolbci.ReadOnly = true;
                            buttonA.Text = "Изменить";

                            strA = Convert.ToInt32(a_stroki.Text);
                            stlbA = Convert.ToInt32(a_stolbci.Text);

                            masA = new double[strA, stlbA];

                            for (int i = 0; i < strA; i++)//матрица в памяти пока что нулевая
                            {
                                for (int j = 0; j < stlbA; j++)
                                {
                                    masA[i, j] = 0;
                                }
                            }

                            b_stroki.Text = strA.ToString();
                            b_stroki.ReadOnly = true;
                            с_stolbci.Text = stlbA.ToString();
                            с_stolbci.ReadOnly = true;
                            //активация нужных строк из текстбоксов, остальное неактивно
                            for (int i = 1; i <= strA; i++)
                            {
                                //TextBox[] a = new TextBox[strA];
                                this.Controls["A" + i.ToString()].Enabled = true;
                                //a[i].Name = "A" + i.ToString();
                                //a[i].ReadOnly = false;
                            }
                            //работа с активацией матрицы
                            A.RowCount = strA;
                            A.ColumnCount = stlbA;
                            A.ReadOnly = false;
                            A.Enabled = true;

                            с_stroki.ReadOnly = false;
                            b_stolbci.ReadOnly = false;
                        }
                        else
                        {
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button6.Enabled = false;
                            button7.Enabled = false;
                            button9.Enabled = false;
                            button10.Enabled = false;

                            buttonA.Text = "ОК";
                            buttonB.Text = "ОК";
                            buttonC.Text = "ОК";
                            button5.Text = "ОК";
                            button4.Text = "ОК";
                            button6.Text = "ОК";
                            button7.Text = "ОК";
                            button9.Text = "ОК";
                            button10.Text = "ОК";

                            a_stroki.ReadOnly = false;
                            a_stolbci.ReadOnly = false;

                            a_stroki.Clear();
                            a_stolbci.Clear();
                            b_stolbci.Clear();
                            b_stroki.Clear();
                            с_stolbci.Clear();
                            с_stroki.Clear();

                            //очистка текстбоксов и сделаем их неактивными
                            for (int i = 1; i < 16; i++)
                            {
                                this.Controls["A" + i.ToString()].Enabled = false;
                                this.Controls["B" + i.ToString()].Enabled = false;
                                this.Controls["C" + i.ToString()].Enabled = false;
                                this.Controls["A" + i.ToString()].Text = "";
                                this.Controls["B" + i.ToString()].Text = "";
                                this.Controls["C" + i.ToString()].Text = "";
                            }
                            //убиваем матрицы - все, так как матрица А главная.
                            A.RowCount = 0;
                            A.ColumnCount = 0;
                            B.RowCount = 0;
                            B.ColumnCount = 0;
                            C.RowCount = 0;
                            C.ColumnCount = 0;
                        }
                    }
                    else
                    {
                        a_stolbci.Clear();
                        a_stroki.Clear();
                        MessageBox.Show("Значения числа строк и столбцов должны быть меньше 15!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Form_main_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 11; i++)
            {
                this.Controls["A" + i.ToString()].Enabled = false;
                this.Controls["B" + i.ToString()].Enabled = false;
                this.Controls["C" + i.ToString()].Enabled = false;
            }
            b_stroki.ReadOnly = true;
            с_stroki.ReadOnly = true;
            с_stolbci.ReadOnly = true;
            b_stolbci.ReadOnly = true;

            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button10.Enabled = false;
            button9.Enabled = false;
            button1.Enabled = false;
            button1.Location = new System.Drawing.Point(1243, 9);
            button1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
        }
    }
}
