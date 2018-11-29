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

        //функции для взятия данных в память и вывода
        #region
        private void take_data_from_matrix(string datagrid, int RowCount, int ColumnCount)
        {
            if (datagrid == "A")
            {
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        //заполнение непроставленных пользователем строк нулями
                        if (Convert.ToDouble(A.Rows[i].Cells[j].Value) == 0)
                        //if (string.IsNullOrEmpty(A.Rows[i].Cells[j].Value as string))
                        {
                            A.Rows[i].Cells[j].Value = 0;
                        }
                        string ss = A.Rows[i].Cells[j].Value.ToString();
                        double tmp = Convert.ToDouble(ss);
                        masA[i, j] = tmp;
                    }
                }
            }
            if (datagrid == "B")
            {
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        //заполнение непроставленных пользователем строк нулями
                        if (Convert.ToDouble(B.Rows[i].Cells[j].Value) == 0)
                        //if (string.IsNullOrEmpty(B.Rows[i].Cells[j].Value as string))
                        {
                            B.Rows[i].Cells[j].Value = 0;
                        }

                        string ss = B.Rows[i].Cells[j].Value.ToString();
                        double tmp = Convert.ToDouble(ss);
                        masB[i, j] = tmp;
                    }
                }
            }
            if (datagrid == "C")
            {
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        //заполнение непроставленных пользователем строк нулями
                        if (Convert.ToDouble(C.Rows[i].Cells[j].Value) == 0)
                        //if (string.IsNullOrEmpty(C.Rows[i].Cells[j].Value as string))
                        {
                            C.Rows[i].Cells[j].Value = 0;
                        }

                        string ss = C.Rows[i].Cells[j].Value.ToString();
                        double tmp = Convert.ToDouble(ss);
                        masC[i, j] = tmp;
                    }
                }
            }
        }

        private void output_data(string datagrid, int str, int stlb)
        {//вывод данных из памяти в датагрид и текстбоксы

            if (datagrid == "A")
            {
                //заполнение таблицы значениями из строк
                for (int i = 0; i < A.RowCount; i++)
                {
                    for (int j = 0; j < A.ColumnCount; j++)
                    {
                        A.Rows[i].Cells[j].Value = masA[i, j];
                    }
                }
            }
            if (datagrid == "B")
            {
                //заполнение таблицы значениями из строк
                for (int i = 0; i < B.RowCount; i++)
                {
                    for (int j = 0; j < B.ColumnCount; j++)
                    {
                        B.Rows[i].Cells[j].Value = masB[i, j];
                    }
                }
            }
            if (datagrid == "C")
            {
                //заполнение таблицы значениями из строк
                for (int i = 0; i < C.RowCount; i++)
                {
                    for (int j = 0; j < C.ColumnCount; j++)
                    {
                        C.Rows[i].Cells[j].Value = masC[i, j];
                    }
                }
            }
        }
        #endregion//тут лежат функции взятия и вывода данных


        private void buttonA_Click(object sender, EventArgs e)
        {
            if ((a_stroki.Text != "") && (a_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(a_stroki.Text) > 0) && (Convert.ToInt32(a_stolbci.Text) > 0))
                {
                    if ((Convert.ToInt32(a_stroki.Text) < 11) && (Convert.ToInt32(a_stolbci.Text) < 11))
                    {
                        if (buttonA.Text == "ОК")
                        {
                            button4.Enabled = true;
                            if (checkB.Checked == true && b_stolbci.Text != "" && b_stroki.Text != "")
                                button6.Enabled = true;
                            else
                                button6.Enabled = false;

                            if (checkC.Checked == true && с_stolbci.Text != "" && с_stroki.Text != "")
                                button9.Enabled = true;
                            else
                                button9.Enabled = false;

                            a_stroki.Enabled = false;
                            a_stolbci.Enabled = false;
                            buttonA.Text = "Изменить А / Очистить всё";

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
                            b_stroki.Enabled = false;
                            с_stolbci.Text = stlbA.ToString();
                            с_stolbci.Enabled = false;
                            //работа с активацией матрицы
                            A.RowCount = strA;
                            A.ColumnCount = stlbA;
                            A.ReadOnly = false;
                            A.Enabled = true;

                            //button1.Enabled = true;
                            //checkBox1.Enabled = true;
                            //checkBox2.Enabled = true;
                            //checkBox3.Enabled = true;
                            //checkBox4.Enabled = true;
                        }
                        else
                        {
                            button4.Enabled = false;
                            if (checkB.Checked == true && b_stolbci.Text != "" && b_stroki.Text != "")
                                button6.Enabled = true;
                            else
                                button6.Enabled = false;

                            if (checkC.Checked == true && с_stolbci.Text != "" && с_stroki.Text != "")
                                button9.Enabled = true;
                            else
                                button9.Enabled = false;

                            a_stroki.Enabled = true;
                            a_stolbci.Enabled = true;
                            b_stroki.Enabled = true;
                            с_stolbci.Enabled = true;


                            button1.Enabled = false;
                            checkBox1.Enabled = false;
                            checkBox2.Enabled = false;
                            checkBox3.Enabled = false;
                            checkBox4.Enabled = false;

                            buttonA.Text = "ОК";
                            buttonB.Text = "ОК";
                            buttonC.Text = "ОК";
                            button4.Text = "ОК";
                            button6.Text = "ОК";
                            button9.Text = "ОК";

                            a_stroki.Clear();
                            a_stolbci.Clear();
                            b_stolbci.Clear();
                            b_stroki.Clear();
                            с_stolbci.Clear();
                            с_stroki.Clear();

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
                        MessageBox.Show("Значения числа строк и столбцов должны быть <=10!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
    || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
        || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            b_stroki.Enabled = false;
            с_stroki.Enabled = false;
            с_stolbci.Enabled = false;
            b_stolbci.Enabled = false;

            button4.Enabled = false;
            button6.Enabled = false;
            button9.Enabled = false;
            button1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkB.Checked = true;
            checkC.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "OK")
            {
                //таблица недоступна для пользователя
                A.ReadOnly = true;
                A.Enabled = false;

                take_data_from_matrix("A", A.RowCount, A.ColumnCount);

                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                output_data("A", strA, stlbA);

                button4.Text = "Изменить";
            }
            else
            {
                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                A.ReadOnly = false;
                A.Enabled = true;

                button4.Text = "OK";
            }

            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
                || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
                    || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            if ((b_stroki.Text != "") && (b_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(b_stroki.Text) > 0) && (Convert.ToInt32(b_stroki.Text) > 0) && (Convert.ToInt32(b_stroki.Text) == Convert.ToInt32(a_stroki.Text)))
                {
                    if ((Convert.ToInt32(b_stolbci.Text) < 11))
                    {
                        if (buttonB.Text == "ОК")
                        {
                            button6.Enabled = true;

                            b_stroki.Enabled = false;
                            b_stolbci.Enabled = false;
                            buttonB.Text = "Изменить В";

                            strB = Convert.ToInt32(b_stroki.Text);
                            stlbB = Convert.ToInt32(b_stolbci.Text);

                            masB = new double[strB, stlbB];
                            for (int i = 0; i < strB; i++)//матрица в памяти пока что нулевая
                            {
                                for (int j = 0; j < stlbB; j++)
                                {
                                    masB[i, j] = 0;
                                }
                            }
                            //работа с активацией матрицы
                            B.RowCount = strB;
                            B.ColumnCount = stlbB;
                        }
                        else
                        {
                            button6.Enabled = false;
                            button6.Text = "ОК";

                            buttonB.Text = "ОК";
                            //b_stroki.ReadOnly = false;
                            b_stolbci.Enabled = true;

                            b_stolbci.Clear();
                            //убиваем матрицу
                            B.RowCount = 0;
                            B.ColumnCount = 0;
                        }
                    }
                    else
                    {
                        b_stolbci.Clear();
                        //b_stroki.Clear();
                        MessageBox.Show("Значения числа строк и столбцов должны быть <=10!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
    || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
        || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "OK")
            {
                //таблица недоступна для пользователя
                B.ReadOnly = true;
                B.Enabled = false;

                take_data_from_matrix("B", B.RowCount, B.ColumnCount);

                int strB = 0;
                int stlbB = 0;
                strB = Convert.ToInt32(b_stroki.Text);
                stlbB = Convert.ToInt32(b_stolbci.Text);

                output_data("B", strB, stlbB);

                button6.Text = "Изменить";
            }
            else
            {
                int strB = 0;
                int stlbB = 0;
                strB = Convert.ToInt32(b_stroki.Text);
                stlbB = Convert.ToInt32(b_stolbci.Text);

                B.ReadOnly = false;
                B.Enabled = true;

                button6.Text = "OK";
            }

            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
                || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
                    || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if ((с_stroki.Text != "") && (с_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(с_stroki.Text) > 0) && (Convert.ToInt32(с_stroki.Text) > 0) && (Convert.ToInt32(с_stolbci.Text) == Convert.ToInt32(a_stolbci.Text)))
                {
                    if ((Convert.ToInt32(с_stroki.Text) < 11))
                    {
                        if (buttonC.Text == "ОК")
                        {
                            button9.Enabled = true;

                            с_stroki.Enabled = false;
                            с_stolbci.Enabled = false;
                            buttonC.Text = "Изменить С";

                            strC = Convert.ToInt32(с_stroki.Text);
                            stlbC = Convert.ToInt32(с_stolbci.Text);

                            masC = new double[strC, stlbC];
                            for (int i = 0; i < strC; i++)//матрица в памяти пока что нулевая
                            {
                                for (int j = 0; j < stlbC; j++)
                                {
                                    masC[i, j] = 0;
                                }
                            }
                            //работа с активацией матрицы
                            C.RowCount = strC;
                            C.ColumnCount = stlbC;
                        }
                        else
                        {
                            button9.Enabled = false;
                            button9.Text = "ОК";

                            buttonC.Text = "ОК";
                            с_stroki.Enabled = true;
                            //c_stolbci.ReadOnly = false;

                            с_stroki.Clear();
                            //убиваем матрицу
                            C.RowCount = 0;
                            C.ColumnCount = 0;
                        }
                    }
                    else
                    {
                        //c_stolbci.Clear();
                        с_stroki.Clear();
                        MessageBox.Show("Значения числа строк и столбцов должны быть <=10!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //c_stolbci.Clear();
                    с_stroki.Clear();
                    MessageBox.Show("Значения числа строк и столбцов должны быть положительными!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //c_stolbci.Clear();
                с_stroki.Clear();
                MessageBox.Show("Введите число строк и столбцов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
    || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
        || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "OK")
            {
                //таблица недоступна для пользователя
                C.ReadOnly = true;
                C.Enabled = false;

                take_data_from_matrix("C", C.RowCount, C.ColumnCount);

                int strС = 0;
                int stlbС = 0;
                strС = Convert.ToInt32(с_stroki.Text);
                stlbС = Convert.ToInt32(с_stolbci.Text);

                output_data("C", strС, stlbС);

                button9.Text = "Изменить";
            }
            else
            {
                int strС = 0;
                int stlbС = 0;
                strС = Convert.ToInt32(с_stroki.Text);
                stlbС = Convert.ToInt32(с_stolbci.Text);

                C.ReadOnly = false;
                C.Enabled = true;

                button9.Text = "OK";
            }

            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
                || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
                    || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {//все отмечено галочкой
                //вывод обеих матриц и их рангов
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {//все кроме ранга управл
                //
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {//все кроме ранга набл
                //
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {//ошибка
                //вывод матрицы упр и ранга упр по запросу
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            { //ошибка
                //вывод матрицы набл и ранга набл по запросу
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {//ошибка
                //вывод матрицы упр
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {//ошибка
                //вывод матрицы набл
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                //вывод набл и упр
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {
                //вывод матр упр и ранг упр
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {
                //вывод матр набл и ранг набл
            }
            else if (!(checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                //вывод матр упр
                double[,] U = new double[strA, strA * stlbB];
                U = cl.MatrU(masA, masB, strA, stlbB);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                //вывод матр набл
            }
            else if (!(checkBox1.Checked) && !(checkBox2.Checked) && ((checkBox3.Checked) || (checkBox4.Checked)))
            {
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Хотя бы одна позиция должна быть выбрана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool nonNumberEntered = false;

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')) && !((e.KeyChar == ','))) //&& !((e.KeyChar == '.')) && !((e.KeyChar == ';')) && !((e.KeyChar == '*')) && !((e.KeyChar == '^')) && !((e.KeyChar == '(')) && !((e.KeyChar == ')'))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void C_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void B_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void A_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void a_stolbci_KeyDown(object sender, KeyEventArgs e)
        {
            {
                nonNumberEntered = false;
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                        {
                            nonNumberEntered = true;
                        }
                    }
                }
            }
        }

        private void a_stolbci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void a_stroki_KeyDown(object sender, KeyEventArgs e)
        {
            {
                nonNumberEntered = false;
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                        {
                            nonNumberEntered = true;
                        }
                    }
                }
            }
        }

        private void a_stroki_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void b_stolbci_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void b_stolbci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void b_stroki_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void b_stroki_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void с_stolbci_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void с_stolbci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void с_stroki_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void с_stroki_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
                 || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
           || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            if ((checkB.Checked == true) && (checkC.Checked == true))//+
            {
                label23.Visible = true;
                label22.Visible = true;
                label16.Visible = true;
                label18.Visible = true;

                b_stolbci.Enabled = true;
                b_stroki.Enabled = true;
                buttonB.Enabled = true;
                B.ReadOnly = false;
                B.Enabled = true;
                //button6.Enabled = true;
                с_stolbci.Enabled = true;
                с_stroki.Enabled = true;
                buttonC.Enabled = true;
                C.ReadOnly = false;
                C.Enabled = true;
                //button9.Enabled = true;
            }
            if ((checkB.Checked == true) && (checkC.Checked == false))//+
            {
                label23.Visible = true;
                label22.Visible = false;
                label16.Visible = true;
                label18.Visible = true;

                b_stolbci.Enabled = true;
                b_stroki.Enabled = true;
                buttonB.Enabled = true;
                B.ReadOnly = false;
                B.Enabled = true;
                //button6.Enabled = true;
                с_stolbci.Enabled = false;
                с_stroki.Enabled = false;
                buttonC.Enabled = false;
                C.ReadOnly = true;
                C.Enabled = false;
                //button9.Enabled = false;
            }
            if ((checkB.Checked == false) && (checkC.Checked == true))//+
            {
                label23.Visible = true;
                label22.Visible = true;
                label16.Visible = true;
                label18.Visible = false;

                b_stolbci.Enabled = false;
                b_stroki.Enabled = false;
                buttonB.Enabled = false;
                B.ReadOnly = true;
                B.Enabled = false;
                //button6.Enabled = false;
                с_stolbci.Enabled = true;
                с_stroki.Enabled = true;
                buttonC.Enabled = true;
                C.ReadOnly = false;
                C.Enabled = true;
                //button9.Enabled = true;
            }
            if ((checkB.Checked == false) && (checkC.Checked == false))//+
            {
                //label23.Text = "x = Ax + Bu";
                //label23.Visible = false;
                //label23.Location = new System.Drawing.Point(567, 40);//x

                //label22.Visible = false;
                //label22.Location = new System.Drawing.Point(567, 94);//y

                //label16.Visible = false;
                //label16.Location = new System.Drawing.Point(569, 10);//.

                MessageBox.Show("Следует выбрать либо одну из матриц В или С, либо отметить обе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkB.Checked = true;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить"
                || checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false
                    || checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить")
            {
                button1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            if ((checkB.Checked == true) && (checkC.Checked == true))//+
            {
                label23.Visible = true;
                label22.Visible = true;
                label16.Visible = true;
                label18.Visible = true;

                b_stolbci.Enabled = true;
                b_stroki.Enabled = true;
                buttonB.Enabled = true;
                B.ReadOnly = false;
                B.Enabled = true;
                //button6.Enabled = true;
                с_stolbci.Enabled = true;
                с_stroki.Enabled = true;
                buttonC.Enabled = true;
                C.ReadOnly = false;
                C.Enabled = true;
                //button9.Enabled = true;
            }
            if ((checkB.Checked == false) && (checkC.Checked == true))//+
            {
                label23.Visible = true;
                label22.Visible = true;
                label16.Visible = true;
                label18.Visible = false;

                b_stolbci.Enabled = false;
                b_stroki.Enabled = false;
                buttonB.Enabled = false;
                B.ReadOnly = true;
                B.Enabled = false;
                //button6.Enabled = false;
                с_stolbci.Enabled = true;
                с_stroki.Enabled = true;
                buttonC.Enabled = true;
                C.ReadOnly = false;
                C.Enabled = true;
                //button9.Enabled = true;
            }
            if ((checkB.Checked == true) && (checkC.Checked == false))//+
            {
                label23.Visible = true;
                label22.Visible = false;
                label16.Visible = true;
                label18.Visible = true;

                b_stolbci.Enabled = true;
                b_stroki.Enabled = true;
                buttonB.Enabled = true;
                B.ReadOnly = false;
                B.Enabled = true;
                //button6.Enabled = true;
                с_stolbci.Enabled = false;
                с_stroki.Enabled = false;
                buttonC.Enabled = false;
                C.ReadOnly = true;
                C.Enabled = false;
                //button9.Enabled = false;
            }
            if ((checkB.Checked == false) && (checkC.Checked == false))//+
            {
                //label23.Text = "x = Ax + Bu";
                //label23.Visible = false;
                //label23.Location = new System.Drawing.Point(567, 40);//x

                //label22.Visible = false;
                //label22.Location = new System.Drawing.Point(567, 94);//y

                //label16.Visible = false;
                //label16.Location = new System.Drawing.Point(569, 10);//.

                MessageBox.Show("Следует выбрать либо одну из матриц В или С, либо отметить обе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkC.Checked = true;
            }
        }
    }
}
