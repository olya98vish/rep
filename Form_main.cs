using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace WindowsFormsApplication1
{
    public partial class Form_main : Form
    {
        //public FormABC_view formABC_view;
        double[,] masA;//массив данных из datagrid A
        double[,] masB;//массив данных из datagrid B
        double[,] masC;//массив данных из datagrid C
        double[,] N, U;
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
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = x;
            this.Height = y;
        }

        private void system_view()//визуализация системы в красивом виде
        {
            ////создаем массив строк и ищем в нем макс элемент
            //string[] A_elements = new string[strA * stlbA];
            //string[] B_elements = new string[strB * stlbB];
            //string[] C_elements = new string[strC * stlbC];
            ////заполним массив из матрицы А данными
            //for(int i = 0; i < strA; i++)
            //{
            //    for (int j = 0; j < stlbA; j++)
            //    {
            //        A_elements[i*stlbA + j] = Convert.ToString(masA[i, j]);
            //    }
            //}
            ////заполним массив из матрицы В данными
            //for (int i = 0; i < strB; i++)
            //{
            //    for (int j = 0; j < stlbB; j++)
            //    {
            //        B_elements[i * stlbB + j] = Convert.ToString(masB[i, j]);
            //    }
            //}
            ////заполним массив из матрицы С данными
            //for (int i = 0; i < strC; i++)
            //{
            //    for (int j = 0; j < stlbC; j++)
            //    {
            //        C_elements[i * stlbC + j] = Convert.ToString(masC[i, j]);
            //    }
            //}
            ////поиск самых длинных элементов и запомним эти числа, чтобы создать матрицу соответствующего размера
            //int maxLengthA = 0;
            //int maxLengthB = 0;
            //int maxLengthC = 0;

            //for (int i = 0; i < strA * stlbA; i++)
            //{
            //    if(maxLengthA < A_elements[i].Length)
            //        maxLengthA = A_elements[i].Length;
            //}
            //for (int i = 0; i < strB * stlbB; i++)
            //{
            //    if (maxLengthB < B_elements[i].Length)
            //        maxLengthB = B_elements[i].Length;
            //}
            //for (int i = 0; i < strC * stlbC; i++)
            //{
            //    if (maxLengthC < C_elements[i].Length)
            //        maxLengthC = C_elements[i].Length;
            //}

            if (checkB.Checked == true && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Text == "Изменить") // есть АВС
            {
                //работа с визуализацией матрицы А
                A_view.Visible = true;
                A_view.RowCount = strA;
                A_view.ColumnCount = stlbA;
                for (int i = 0; i < strA; i++)
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.A_view.Rows[i].Cells[j].Value = masA[i, j];
                    }
                }
                int widthA = 0;
                foreach (DataGridViewColumn column in A_view.Columns)
                    widthA += column.Width;
                int widthA_view = widthA;
                int heightA_view = strA * 22;
                A_view.Location = new System.Drawing.Point(506, A.Location.Y + 53);
                A_view.Size = new System.Drawing.Size(widthA_view, heightA_view);
                label19.Visible = true;
                label20.Visible = true;
                label19.Location = new System.Drawing.Point(450, A.Location.Y + 53 + heightA_view / 2 - 36);
                label20.Location = new System.Drawing.Point(448, A.Location.Y + 53 + heightA_view / 2 - 15);

                //работа с визуализацией матрицы В
                B_view.Visible = true;
                B_view.RowCount = strB;
                B_view.ColumnCount = stlbB;
                for (int i = 0; i < B.RowCount; i++)
                {
                    for (int j = 0; j < B.ColumnCount; j++)
                    {
                        this.B_view.Rows[i].Cells[j].Value = masB[i, j];
                    }
                }
                int widthB = 0;
                foreach (DataGridViewColumn column in B_view.Columns)
                    widthB += column.Width;
                int widthB_view = widthB;
                int heightB_view = strB * 22;
                B_view.Location = new System.Drawing.Point(506 + widthA_view + 20 + 35, A.Location.Y + 53);
                B_view.Size = new System.Drawing.Size(widthB_view, heightB_view);
                label24.Location = new System.Drawing.Point(448 + widthA_view + 64, A.Location.Y + 53 + heightA_view / 2 - 15);
                label25.Location = new System.Drawing.Point(448 + widthA_view + 64 + widthB_view + 50, A.Location.Y + 53 + heightA_view / 2 - 15);
                label24.Visible = true;
                label25.Visible = true;

                //работа с визуализацией матрицы С
                C_view.Visible = true;
                C_view.RowCount = strC;
                C_view.ColumnCount = stlbC;
                for (int i = 0; i < C.RowCount; i++)
                {
                    for (int j = 0; j < C.ColumnCount; j++)
                    {
                        this.C_view.Rows[i].Cells[j].Value = masC[i, j];
                    }
                }
                int widthC = 0;
                foreach (DataGridViewColumn column in C_view.Columns)
                    widthC += column.Width;
                int widthC_view = widthC;
                int heightC_view = strC * 22;
                C_view.Location = new System.Drawing.Point(506, A.Location.Y + 53 + heightA_view + 21);
                C_view.Size = new System.Drawing.Size(widthC_view, heightC_view);
                label26.Location = new System.Drawing.Point(448, A.Location.Y + 53 + 5 + heightA_view + heightC_view / 2);
                label27.Location = new System.Drawing.Point(448 + widthC_view + 64, A.Location.Y + 53 + 5 + heightA_view + heightC_view / 2);
                label26.Visible = true;
                label27.Visible = true;
            }
            if(checkB.Checked == true && checkC.Checked == false && a_stolbci.Text != "" && a_stroki.Text != "" && b_stolbci.Text != "" && b_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Text == "Изменить В" && buttonC.Enabled == false && button4.Text == "Изменить" && button6.Text == "Изменить" && button9.Enabled == false) //есть АВ
            {
                //работа с визуализацией матрицы А
                A_view.Visible = true;
                A_view.RowCount = strA;
                A_view.ColumnCount = stlbA;
                for (int i = 0; i < strA; i++)
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.A_view.Rows[i].Cells[j].Value = masA[i, j];
                    }
                }
                int widthA = 0;
                foreach (DataGridViewColumn column in A_view.Columns)
                    widthA += column.Width;
                int widthA_view = widthA;
                int heightA_view = strA * 22;
                A_view.Location = new System.Drawing.Point(506, A.Location.Y + 53);
                A_view.Size = new System.Drawing.Size(widthA_view, heightA_view);
                label19.Visible = true;
                label20.Visible = true;
                label19.Location = new System.Drawing.Point(450, A.Location.Y + 53 + heightA_view / 2 - 36);
                label20.Location = new System.Drawing.Point(448, A.Location.Y + 53 + heightA_view / 2 - 15);

                //работа с визуализацией матрицы В
                B_view.Visible = true;
                B_view.RowCount = strB;
                B_view.ColumnCount = stlbB;
                for (int i = 0; i < B.RowCount; i++)
                {
                    for (int j = 0; j < B.ColumnCount; j++)
                    {
                        this.B_view.Rows[i].Cells[j].Value = masB[i, j];
                    }
                }
                int widthB = 0;
                foreach (DataGridViewColumn column in B_view.Columns)
                    widthB += column.Width;
                int widthB_view = widthB;
                int heightB_view = strB * 22;
                B_view.Location = new System.Drawing.Point(506 + widthA_view + 20 + 35, A.Location.Y + 53);
                B_view.Size = new System.Drawing.Size(widthB_view, heightB_view);
                label24.Location = new System.Drawing.Point(448 + widthA_view + 64, A.Location.Y + 53 + heightA_view / 2 - 15);
                label25.Location = new System.Drawing.Point(448 + widthA_view + 64 + widthB_view + 6, A.Location.Y + 53 + heightA_view / 2 - 15);
                label24.Visible = true;
                label25.Visible = true;

                //    //работа с визуализацией матрицы С
                //    C_view.Visible = true;
                //    C_view.RowCount = strC;
                //    C_view.ColumnCount = stlbC;
                //    for (int i = 0; i < C.RowCount; i++)
                //    {
                //        for (int j = 0; j < C.ColumnCount; j++)
                //        {
                //            this.C_view.Rows[i].Cells[j].Value = masC[i, j];
                //        }
                //    }
                //    int widthC = 0;
                //    foreach (DataGridViewColumn column in C_view.Columns)
                //        widthC += column.Width;
                //    int widthC_view = widthC;
                //    int heightC_view = strC * 22;
                //    C_view.Location = new System.Drawing.Point(506, A.Location.Y + 53 + heightA_view + 21);
                //    C_view.Size = new System.Drawing.Size(widthC_view, heightC_view);
                //    label26.Location = new System.Drawing.Point(448, A.Location.Y + 53 + 5 + heightA_view + heightC_view / 2);
                //    label27.Location = new System.Drawing.Point(448 + widthC_view + 64, A.Location.Y + 53 + 5 + heightA_view + heightC_view / 2);
                //    label26.Visible = true;
                //    label27.Visible = true;
            }
            else if (checkB.Checked == false && checkC.Checked == true && a_stolbci.Text != "" && a_stroki.Text != "" && с_stolbci.Text != "" && с_stroki.Text != "" && buttonA.Text == "Изменить А / Очистить всё" && buttonB.Enabled == false && buttonC.Text == "Изменить С" && button4.Text == "Изменить" && button6.Enabled == false && button9.Text == "Изменить") //есть АС
            { // есть АС
                //работа с визуализацией матрицы А
                A_view.Visible = true;
                A_view.RowCount = strA;
                A_view.ColumnCount = stlbA;
                for (int i = 0; i < strA; i++)
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.A_view.Rows[i].Cells[j].Value = masA[i, j];
                    }
                }
                int widthA = 0;
                foreach (DataGridViewColumn column in A_view.Columns)
                    widthA += column.Width;
                int widthA_view = widthA;
                int heightA_view = strA * 22;
                A_view.Location = new System.Drawing.Point(506, A.Location.Y + 53);
                A_view.Size = new System.Drawing.Size(widthA_view, heightA_view);
                label19.Visible = true;
                label20.Visible = true;
                label19.Location = new System.Drawing.Point(450, A.Location.Y + 53 + heightA_view / 2 - 36);
                label20.Location = new System.Drawing.Point(448, A.Location.Y + 53 + heightA_view / 2 - 15);

                ////работа с визуализацией матрицы В
                //B_view.Visible = true;
                //B_view.RowCount = strB;
                //B_view.ColumnCount = stlbB;
                //for (int i = 0; i < B.RowCount; i++)
                //{
                //    for (int j = 0; j < B.ColumnCount; j++)
                //    {
                //        this.B_view.Rows[i].Cells[j].Value = masB[i, j];
                //    }
                //}
                //int widthB = 0;
                //foreach (DataGridViewColumn column in B_view.Columns)
                //    widthB += column.Width;
                //int widthB_view = widthB;
                //int heightB_view = strB * 22;
                //B_view.Location = new System.Drawing.Point(506 + widthA_view + 20 + 35, A.Location.Y + 53);
                //B_view.Size = new System.Drawing.Size(widthB_view, heightB_view);
                //label24.Location = new System.Drawing.Point(448 + widthA_view + 64, A.Location.Y + 53 + heightA_view / 2 - 15);
                //label25.Location = new System.Drawing.Point(448 + widthA_view + 64 + widthB_view + 6, A.Location.Y + 53 + heightA_view / 2 - 15);
                //label24.Visible = true;
                //label25.Visible = true;

                //работа с визуализацией матрицы С
                C_view.Visible = true;
                C_view.RowCount = strC;
                C_view.ColumnCount = stlbC;
                for (int i = 0; i < C.RowCount; i++)
                {
                    for (int j = 0; j < C.ColumnCount; j++)
                    {
                        this.C_view.Rows[i].Cells[j].Value = masC[i, j];
                    }
                }
                int widthC = 0;
                foreach (DataGridViewColumn column in C_view.Columns)
                    widthC += column.Width;
                int widthC_view = widthC;
                int heightC_view = strC * 22;
                C_view.Location = new System.Drawing.Point(506, A.Location.Y + 53 + heightA_view + 21);
                C_view.Size = new System.Drawing.Size(widthC_view, heightC_view);
                label26.Location = new System.Drawing.Point(448, A.Location.Y + 53 + 5 + heightA_view + heightC_view / 2);
                label27.Location = new System.Drawing.Point(448 + widthC_view + 64, A.Location.Y + 53 + 5 + heightA_view + heightC_view / 2);
                label26.Visible = true;
                label27.Visible = true;
            }
        }

        private void system_unview()//сокрытие визуализации
        {
            //работа с девизуализацией матрицы А
            A_view.Visible = false;
            A_view.RowCount = 0;
            A_view.ColumnCount = 0;
            label19.Visible = false;
            label20.Visible = false;

            //работа с девизуализацией матрицы В
            B_view.Visible = false;
            B_view.RowCount = 0;
            B_view.ColumnCount = 0;
            label24.Visible = false;
            label25.Visible = false;

            //работа с девизуализацией матрицы С
            C_view.Visible = false;
            C_view.RowCount = 0;
            C_view.ColumnCount = 0;
            label26.Visible = false;
            label27.Visible = false;
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
                            b_stolbci.Enabled = true;
                            с_stroki.Enabled = true;
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
                            checkBox1.Checked = false;
                            checkBox2.Checked = false;
                            checkBox3.Checked = false;
                            checkBox4.Checked = false;
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
                            A.ReadOnly = true;
                            A.Enabled = false;

                            if (A_view.Visible == true)
                            {
                                system_unview();
                            }
                            if(matrU.Visible==true)
                            {
                                U = null;
                                matrU.Visible = false;
                                label30.Visible = false;
                                label32.Visible = false;
                                matrU.RowCount = 0;
                                matrU.ColumnCount = 0;
                            }
                            if (matrN.Visible == true)
                            {
                                N = null;
                                matrN.Visible = false;
                                label31.Visible = false;
                                label33.Visible = false;
                                matrN.RowCount = 0;
                                matrN.ColumnCount = 0;
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
                system_view();
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                system_unview();
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
                            B.ReadOnly = false;
                            B.Enabled = true;

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
                            B.ReadOnly = true;
                            B.Enabled = false;

                            button6.Enabled = false;
                            button6.Text = "ОК";

                            buttonB.Text = "ОК";
                            //b_stroki.ReadOnly = false;
                            b_stolbci.Enabled = true;

                            b_stolbci.Clear();
                            //убиваем матрицу
                            B.RowCount = 0;
                            B.ColumnCount = 0;
                            if(A_view.Visible == true)
                            {
                                system_unview();
                            }
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
                system_view();
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                system_unview();
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
                            C.ReadOnly = false;
                            C.Enabled = true;

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
                            C.ReadOnly = true;
                            C.Enabled = false;

                            button9.Enabled = false;
                            button9.Text = "ОК";

                            buttonC.Text = "ОК";
                            с_stroki.Enabled = true;
                            //c_stolbci.ReadOnly = false;

                            с_stroki.Clear();
                            //убиваем матрицу
                            C.RowCount = 0;
                            C.ColumnCount = 0;

                            if (A_view.Visible == true)
                            {
                                system_unview();
                            }
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
                system_view();
            }
            else
            {
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                system_unview();
            }
        }

        private void computing_UN(double[,] U, double[,] N, double[,] A, double[,] b, double[,] c)
        {
            //система для U
            if (masB != null)
            {
                sist.AutoSize = true;
                sist.Text = "U=(B, ";
                for (int i = 1; i < U.GetLength(0); i++)
                {
                    if (i == 1)
                        sist.Text += "AB, ";
                    if ((i != 1) && (i != U.GetLength(0) - 1))
                        sist.Text += "A^" + i + "B, ";
                    if (i == U.GetLength(0) - 1)
                        sist.Text += "A^" + i + "B)";
                }
                sist.Location = new Point(5, 5);
                sist.Visible = true;
            }
            //система для N
            if(masC!=null)
            {
                sist1.AutoSize = true;
                sist1.Text = "N= (C, ";
                for (int i = 1; i < N.GetLength(1); i++)
                {
                    if (i == 1)
                        sist1.Text += "CA, ";
                    if ((i != 1) && (i != N.GetLength(1) - 1))
                        sist1.Text += "CA^"+i+", ";
                    if (i == N.GetLength(1) - 1)
                        sist1.Text += "CA^" + i + ")T";
                }
                if (masB == null)
                    sist1.Location = new Point(5, 5);
                else sist1.Location = new Point(sist.Location.X + sist.Size.Width + 10, sist.Location.Y);
                sist1.Visible = true;
            }
            //выводим А
            vecA.RowCount = A.GetLength(0);
            vecA.ColumnCount = A.GetLength(1);
            vecA.Font = new Font("Segoe UI", 8);
            vecA.Location = new Point(sist.Location.X+leba.Size.Width+5, sist.Location.Y + sist.Height + 5);
            leba.Location = new Point(sist.Location.X, vecA.Size.Height / 2 - leba.Size.Height / 2);
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    vecA.Rows[i].Cells[j].Value = A[i, j];
            int widtha = 0; int heighta = 0;
            foreach (DataGridViewRow row in vecA.Rows)
                heighta += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
            foreach (DataGridViewColumn column in vecA.Columns)
                widtha += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            vecA.Size = new System.Drawing.Size(widtha, heighta);
            vecA.Visible = true;
            leba.Visible = true;
            //выводим В
            if (masB != null)
            {
                vecB.RowCount = b.GetLength(0);
                vecB.ColumnCount = b.GetLength(1);
                vecB.Font = new Font("Segoe UI", 8);
                lebb.Location = new Point(vecA.Location.X+vecA.Size.Width+10,leba.Location.Y);
                vecB.Location = new Point(lebb.Location.X+lebb.Size.Width,vecA.Location.Y );             
                for (int i = 0; i < b.GetLength(0); i++)
                    for (int j = 0; j < b.GetLength(1); j++)
                        vecB.Rows[i].Cells[j].Value = b[i, j];
                int width = 0; int height = 0;
                foreach (DataGridViewRow row in vecB.Rows)
                    height += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                foreach (DataGridViewColumn column in vecB.Columns)
                    width += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                vecB.Size = new System.Drawing.Size(width, height);
                vecB.Visible = true;
                lebb.Visible = true;
            }
            //выводим С
            if(masC!=null)
            {
                vecC.RowCount = c.GetLength(0);
                vecC.ColumnCount = c.GetLength(1);
                vecC.Font = new Font("Segoe UI", 8);
                if (masB != null)
                {
                    lebc.Location = new Point(vecB.Location.X + vecB.Size.Width + 10, lebb.Location.Y);
                    vecC.Location = new Point(lebc.Location.X + lebc.Size.Width, vecC.Size.Height/2-lebc.Size.Height/2);
                }
                else
                {
                    lebc.Location = new Point(vecA.Location.X + vecA.Size.Width + 10, leba.Location.Y);
                    vecC.Location = new Point(lebc.Location.X + lebc.Size.Width, vecC.Size.Height / 2 - lebc.Size.Height / 2);
                }
                for (int i = 0; i < c.GetLength(0); i++)
                    for (int j = 0; j < c.GetLength(1); j++)
                        vecC.Rows[i].Cells[j].Value = c[i, j];
                int widthc = 0; int heightc = 0;
                foreach (DataGridViewRow row in vecC.Rows)
                    heightc += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                foreach (DataGridViewColumn column in vecC.Columns)
                    widthc += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                vecC.Size = new System.Drawing.Size(widthc, heightc);
                vecC.Visible = true;
                lebc.Visible = true;
            }

            if (U != null && masB != null)
            {
                double[,] vrA, res;
                vrA = A;
                for (int n = 1; n < U.GetLength(0); n++)
                {
                    Label lb = new Label();
                    lb.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                    DataGridView dg = new DataGridView();
                    dg.Font = new Font("Segoe UI", 8);
                    dg.Name = "dgu" + n.ToString();
                    lb.Name = "lbu" + n.ToString();

                    tabPage3.Controls.Add(dg);
                    tabPage3.Controls.Add(lb);

                    if (n != 1)
                        tabPage3.Controls["lbu" + n.ToString()].Text = "A^" + n + "B=";
                    else
                        tabPage3.Controls["lbu" + n.ToString()].Text = "AB=";
                    tabPage3.Controls["lbu" + n.ToString()].AutoSize = true;

                    (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).ColumnHeadersVisible = false;
                    (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).RowHeadersVisible = false;
                    (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).ScrollBars = ScrollBars.None;

                    (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).RowCount = b.GetLength(0);
                    (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).ColumnCount = b.GetLength(1);
                    res = filling.Multiplication(vrA, b);
                    for (int k = 0; k < res.GetLength(0); k++)
                        for (int m = 0; m < res.GetLength(1); m++)
                            (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).Rows[k].Cells[m].Value = res[k, m];
                        vrA = filling.Multiplication(vrA, A);

                    int width = 0; int height = 0;
                    foreach (DataGridViewRow row in (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).Rows)
                        height += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true)+2;
                    foreach (DataGridViewColumn column in (tabPage3.Controls["dgu" + n.ToString()] as DataGridView).Columns)
                        width += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    tabPage3.Controls["dgu" + n].Size = new System.Drawing.Size(width, height);

                    if (n == 1)
                        tabPage3.Controls["dgu" + n.ToString()].Location = new Point(tabPage3.Controls["lbu" + n.ToString()].Location.X + tabPage3.Controls["lbu" + n.ToString()].Size.Width + 5, vecA.Location.Y + vecA.Size.Height + 5);
                    else
                        tabPage3.Controls["dgu" + n.ToString()].Location = new Point(tabPage3.Controls["lbu" + n.ToString()].Location.X + tabPage3.Controls["lbu" + n.ToString()].Size.Width + 5, tabPage3.Controls["dgu" + (n - 1).ToString()].Location.Y + tabPage3.Controls["dgu" + (n - 1).ToString()].Size.Height + 5);
                    tabPage3.Controls["lbu" + n.ToString()].Location = new Point(leba.Location.X, tabPage3.Controls["dgu" + n.ToString()].Location.Y + tabPage3.Controls["dgu" + n.ToString()].Size.Height / 2 - tabPage3.Controls["lbu" + n.ToString()].Size.Height / 2);
                }
            }

            if(N!=null&& masC!=null)
            {
                double[,] vrA, res;
                vrA = A;
                for (int n = 1; n < N.GetLength(1); n++)
                {
                    Label lb = new Label();
                    lb.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                    DataGridView dg = new DataGridView();
                    dg.Font = new Font("Segoe UI", 8);
                    dg.Name = "dgn" + n.ToString();
                    lb.Name = "lbn" + n.ToString();

                    tabPage3.Controls.Add(dg);
                    tabPage3.Controls.Add(lb);

                    if (n != 1)
                        tabPage3.Controls["lbn" + n.ToString()].Text = "CA^" + n + "=";
                    else
                        tabPage3.Controls["lbn" + n.ToString()].Text = "CA=";
                    tabPage3.Controls["lbn" + n.ToString()].AutoSize = true;

                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).ColumnHeadersVisible = false;
                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).RowHeadersVisible = false;
                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).ScrollBars = ScrollBars.None;

                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).RowCount = c.GetLength(0);
                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).ColumnCount = c.GetLength(1);
                    res = filling.Multiplication(c, vrA);
                    for (int k = 0; k < res.GetLength(0); k++)
                        for (int m = 0; m < res.GetLength(1); m++)
                            (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).Rows[k].Cells[m].Value = res[k, m];
                    vrA = filling.Multiplication(vrA, A);

                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    int width = 0; int height = 0;
                    foreach (DataGridViewRow row in (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).Rows)
                        height += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in (tabPage3.Controls["dgn" + n.ToString()] as DataGridView).Columns)
                        width += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    tabPage3.Controls["dgn" + n].Size = new System.Drawing.Size(width, height);

                    if (U != null&&masB!=null)
                    {
                        int k = U.GetLength(0) - 1;//номер последнего контрла в U
                        if(n==1)
                            tabPage3.Controls["dgn" + n.ToString()].Location = new Point(tabPage3.Controls["lbn" + n.ToString()].Location.X + tabPage3.Controls["lbn" + n.ToString()].Size.Width + 5, tabPage3.Controls["dgu"+k.ToString()].Location.Y+tabPage3.Controls["dgu"+k.ToString()].Size.Height+5);
                        else
                            tabPage3.Controls["dgn" + n.ToString()].Location = new Point(tabPage3.Controls["lbn" + n.ToString()].Location.X + tabPage3.Controls["lbn" + n.ToString()].Size.Width + 5, tabPage3.Controls["dgn" + (n-1).ToString()].Location.Y + tabPage3.Controls["dgn" + (n-1).ToString()].Size.Height + 5);
                        tabPage3.Controls["lbn" + n.ToString()].Location = new Point(leba.Location.X, tabPage3.Controls["dgn" + n.ToString()].Location.Y + tabPage3.Controls["dgn" + n.ToString()].Size.Height / 2 - tabPage3.Controls["lbn" + n.ToString()].Size.Height / 2);
                    } 
                    else
                    {
                        if (n == 1)
                            tabPage3.Controls["dgn" + n.ToString()].Location = new Point(tabPage3.Controls["lbn" + n.ToString()].Location.X + tabPage3.Controls["lbn" + n.ToString()].Size.Width + 5, vecA.Location.Y + vecA.Size.Height + 5);
                        else
                            tabPage3.Controls["dgn" + n.ToString()].Location = new Point(tabPage3.Controls["lbn" + n.ToString()].Location.X + tabPage3.Controls["lbn" + n.ToString()].Size.Width + 5, tabPage3.Controls["dgn" + (n - 1).ToString()].Location.Y + tabPage3.Controls["dgn" + (n - 1).ToString()].Size.Height + 5);
                        tabPage3.Controls["lbn" + n.ToString()].Location = new Point(leba.Location.X, tabPage3.Controls["dgn" + n.ToString()].Location.Y + tabPage3.Controls["dgn" + n.ToString()].Size.Height / 2 - tabPage3.Controls["lbn" + n.ToString()].Size.Height / 2);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //ввести условие на пустоту массивов!
        { 
            N = new double[stlbA * strC, stlbA];
            U = new double[strA, strA * stlbB];
            int rankU = 0, rankN = 0;
            if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                //вывод обеих матриц и их рангов
                if (masB != null && masC != null)
                {
                    U = cl.MatrU(masA, masB, strA, stlbB);
                    N = cl.MatrN(masA, masC, stlbA, strC);
                    rankU = cl.Rank(U);
                    rankN = cl.Rank(N);

                    matrU.RowCount = strA;
                    matrU.ColumnCount = strA * stlbB;
                    matrU.Font = new Font("Segoe UI", 8);

                    for (int i = 0; i < strA; i++)
                    {
                        for (int j = 0; j < strA * stlbB; j++)
                        {
                            this.matrU.Rows[i].Cells[j].Value = U[i, j];
                        }
                    }
                    int widthU = 0; int heightU = 0;
                    foreach (DataGridViewRow row in matrU.Rows)
                        heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrU.Columns)
                        widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrU.Size = new System.Drawing.Size(widthU, heightU);
                    matrU.Visible = true;
                    label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 5, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                    label30.Visible = true;
                    label32.Location = new System.Drawing.Point(matrU.Location.X + matrU.Size.Width + 15, matrU.Location.Y + (matrU.Size.Height / 2 - label32.Size.Height / 2));
                    label32.Visible = true;
                    label32.Text = "rgU=" + rankU;

                    matrN.RowCount = stlbA * strC;
                    matrN.ColumnCount = stlbA;
                    matrN.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < stlbA * strC; i++)
                    {
                        for (int j = 0; j < stlbA; j++)
                        {
                            this.matrN.Rows[i].Cells[j].Value = N[i, j];
                        }
                    }
                    int widthN = 0; int heightN = 0;
                    foreach (DataGridViewRow row in matrN.Rows)
                        heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrN.Columns)
                        widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    matrN.Location = new System.Drawing.Point(A_view.Location.X, matrU.Location.Y + matrU.Size.Height + 25);
                    matrN.Size = new System.Drawing.Size(widthN, heightN);
                    matrN.Visible = true;
                    label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                    label31.Visible = true;
                    label33.Location = new System.Drawing.Point(matrN.Location.X + matrN.Size.Width + 15, matrN.Location.Y + (matrN.Size.Height / 2 - label32.Size.Height / 2));
                    label33.Text = "rgN=" + rankN;
                    label33.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else
                {
                    if (masB == null && masC == null) MessageBox.Show("Вы не ввели матрицы C и B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {//все кроме ранга набл
                if(masB!=null&&masC!=null)
                { 
                    U = cl.MatrU(masA, masB, strA, stlbB);
                    N = cl.MatrN(masA, masC, stlbA, strC);
                    rankU = cl.Rank(U);
                    matrU.RowCount = strA;
                    matrU.ColumnCount = strA * stlbB;
                    matrU.Font = new Font("Segoe UI", 8);

                    for (int i = 0; i < strA; i++)
                    {
                        for (int j = 0; j < strA * stlbB; j++)
                        {
                            this.matrU.Rows[i].Cells[j].Value = U[i, j];
                        }
                    }
                    int widthU = 0; int heightU = 0;
                    foreach (DataGridViewRow row in matrU.Rows)
                        heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrU.Columns)
                        widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrU.Size = new System.Drawing.Size(widthU, heightU);
                    matrU.Visible = true;
                    label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                    label30.Visible = true;
                    label32.Location = new System.Drawing.Point(matrU.Location.X + matrU.Size.Width + 15, matrU.Location.Y + (matrU.Size.Height / 2 - label32.Size.Height / 2));
                    label32.Visible = true;
                    label32.Text = "rgU=" + rankU;

                    matrN.RowCount = stlbA * strC;
                    matrN.ColumnCount = stlbA;
                    matrN.Font = new Font("Segoe UI", 8);

                    for (int i = 0; i < stlbA * strC; i++)
                    {
                        for (int j = 0; j < stlbA; j++)
                        {
                            this.matrN.Rows[i].Cells[j].Value = N[i, j];
                        }
                    }
                    int widthN = 0; int heightN = 0;
                    foreach (DataGridViewRow row in matrN.Rows)
                        heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrN.Columns)
                        widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    matrN.Location = new System.Drawing.Point(A_view.Location.X, matrU.Location.Y + matrU.Size.Height + 25);
                    matrN.Size = new System.Drawing.Size(widthN, heightN);
                    matrN.Visible = true;
                    label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                    label31.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else
                {
                    if(masB!=null&&masC!=null) MessageBox.Show("Вы не ввели матрицу B и C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {//все кроме ранга упр
                if (masB != null && masC != null)
                {
                    U = cl.MatrU(masA, masB, strA, stlbB);
                    N = cl.MatrN(masA, masC, stlbA, strC);
                    rankN = cl.Rank(N);
                    matrU.RowCount = strA;
                    matrU.ColumnCount = strA * stlbB;
                    matrU.Font = new Font("Segoe UI", 8);

                    for (int i = 0; i < strA; i++)
                    {
                        for (int j = 0; j < strA * stlbB; j++)
                        {
                            this.matrU.Rows[i].Cells[j].Value = U[i, j];
                        }
                    }
                    int widthU = 0; int heightU = 0;
                    foreach (DataGridViewRow row in matrU.Rows)
                        heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrU.Columns)
                        widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrU.Size = new System.Drawing.Size(widthU, heightU);
                    matrU.Visible = true;
                    label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                    label30.Visible = true;

                    matrN.RowCount = stlbA * strC;
                    matrN.ColumnCount = stlbA;
                    matrN.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < stlbA * strC; i++)
                    {
                        for (int j = 0; j < stlbA; j++)
                        {
                            this.matrN.Rows[i].Cells[j].Value = N[i, j];
                        }
                    }
                    int widthN = 0; int heightN = 0;
                    foreach (DataGridViewRow row in matrN.Rows)
                        heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrN.Columns)
                        widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    matrN.Location = new System.Drawing.Point(A_view.Location.X, matrU.Location.Y + matrU.Size.Height + 25);
                    matrN.Size = new System.Drawing.Size(widthN, heightN);
                    matrN.Visible = true;
                    label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                    label31.Visible = true;
                    label33.Location = new System.Drawing.Point(matrN.Location.X + matrN.Size.Width + 15, matrN.Location.Y + (matrN.Size.Height / 2 - label32.Size.Height / 2));
                    label33.Text = "rgN=" + rankN;
                    label33.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else
                {
                    if (masB == null && masC == null) MessageBox.Show("Вы не ввели матрицу B и C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                if (masB != null)
                {
                    DialogResult res = MessageBox.Show("Нельзя вывести ранг матрицы наблюдения, не выведя саму матрицу! Продолжить?", "Ошибка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes)
                    {
                        U = cl.MatrU(masA, masB, strA, stlbB);
                        rankU = cl.Rank(U);
                        matrU.RowCount = strA;
                        matrU.ColumnCount = strA * stlbB;
                        matrU.Font = new Font("Segoe UI", 8);

                        for (int i = 0; i < strA; i++)
                        {
                            for (int j = 0; j < strA * stlbB; j++)
                            {
                                this.matrU.Rows[i].Cells[j].Value = U[i, j];
                            }
                        }
                        int widthU = 0; int heightU = 0;
                        foreach (DataGridViewRow row in matrU.Rows)
                            heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                        foreach (DataGridViewColumn column in matrU.Columns)
                            widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                        if (C_view.Visible == true)
                            matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                        else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                        matrU.Size = new System.Drawing.Size(widthU, heightU);
                        matrU.Visible = true;
                        label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                        label30.Visible = true;
                        label32.Location = new System.Drawing.Point(matrU.Location.X + matrU.Size.Width + 15, matrU.Location.Y + (matrU.Size.Height / 2 - label32.Size.Height / 2));
                        label32.Visible = true;
                        label32.Text = "rgU=" + rankU;

                        computing_UN(U, N, masA, masB, masC);
                    }
                }
                else if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                if (masC != null)
                {
                    DialogResult res = MessageBox.Show("Нельзя вывести ранг матрицы управления, не выведя саму матрицу! Продолжить?", "Ошибка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes)
                    {
                        N = cl.MatrN(masA, masC, stlbA, strC);
                        rankN = cl.Rank(N);

                        matrN.RowCount = stlbA * strC;
                        matrN.ColumnCount = stlbA;
                        matrN.Font = new Font("Segoe UI", 8);
                        for (int i = 0; i < stlbA * strC; i++)
                        {
                            for (int j = 0; j < stlbA; j++)
                            {
                                this.matrN.Rows[i].Cells[j].Value = N[i, j];
                            }
                        }
                        int widthN = 0; int heightN = 0;
                        foreach (DataGridViewRow row in matrN.Rows)
                            heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                        foreach (DataGridViewColumn column in matrN.Columns)
                            widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                        if (C_view.Visible == true)
                            matrN.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                        else matrN.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                        matrN.Size = new System.Drawing.Size(widthN, heightN);
                        matrN.Visible = true;
                        label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                        label31.Visible = true;
                        label33.Location = new System.Drawing.Point(matrN.Location.X + matrN.Size.Width + 15, matrN.Location.Y + (matrN.Size.Height / 2 - label32.Size.Height / 2));
                        label33.Text = "rgN=" + rankN;
                        label33.Visible = true;

                        computing_UN(U, N, masA, masB, masC);
                    }
                }
                else if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                if (masB != null && masC != null)
                {
                    U = cl.MatrU(masA, masB, strA, stlbB);
                    N = cl.MatrN(masA, masC, stlbA, strC);

                    matrU.RowCount = strA;
                    matrU.ColumnCount = strA * stlbB;
                    matrU.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < strA; i++)
                    {
                        for (int j = 0; j < strA * stlbB; j++)
                        {
                            this.matrU.Rows[i].Cells[j].Value = U[i, j];
                        }
                    }
                    int widthU = 0; int heightU = 0;
                    foreach (DataGridViewRow row in matrU.Rows)
                        heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrU.Columns)
                        widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrU.Size = new System.Drawing.Size(widthU, heightU);
                    matrU.Visible = true;
                    label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                    label30.Visible = true;

                    matrN.RowCount = stlbA * strC;
                    matrN.ColumnCount = stlbA;
                    matrN.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < stlbA * strC; i++)
                    {
                        for (int j = 0; j < stlbA; j++)
                        {
                            this.matrN.Rows[i].Cells[j].Value = N[i, j];
                        }
                    }
                    int widthN = 0; int heightN = 0;
                    foreach (DataGridViewRow row in matrN.Rows)
                        heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrN.Columns)
                        widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    matrN.Location = new System.Drawing.Point(A_view.Location.X, matrU.Location.Y + matrU.Size.Height + 25);
                    matrN.Size = new System.Drawing.Size(widthN, heightN);
                    matrN.Visible = true;
                    label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                    label31.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else
                {
                    if (masB == null && masC == null) MessageBox.Show("Вы не ввели матрицу B и С", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {
                if (masB != null)
                {
                    U = cl.MatrU(masA, masB, strA, stlbB);
                    rankU = cl.Rank(U);
                    matrU.RowCount = strA;
                    matrU.ColumnCount = strA * stlbB;
                    matrU.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < strA; i++)
                    {
                        for (int j = 0; j < strA * stlbB; j++)
                        {
                            this.matrU.Rows[i].Cells[j].Value = U[i, j];
                        }
                    }
                    int widthU = 0; int heightU = 0;
                    foreach (DataGridViewRow row in matrU.Rows)
                        heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrU.Columns)
                        widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrU.Size = new System.Drawing.Size(widthU, heightU);
                    matrU.Visible = true;
                    label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                    label30.Visible = true;
                    label32.Location = new System.Drawing.Point(matrU.Location.X + matrU.Size.Width + 15, matrU.Location.Y + (matrU.Size.Height / 2 - label32.Size.Height / 2));
                    label32.Visible = true;
                    label32.Text = "rgU=" + rankU;

                    computing_UN(U, N, masA, masB, masC);
                }
                else if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {
                if (masB != null)
                {
                    DialogResult res = MessageBox.Show("Нельзя вывести ранг матрицы наблюдения, не выведя саму матрицу! Продолжить?", "Ошибка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes)
                    {
                        U = cl.MatrU(masA, masB, strA, stlbB);
                        matrU.RowCount = strA;
                        matrU.ColumnCount = strA * stlbB;
                        matrU.Font = new Font("Segoe UI", 8);
                        for (int i = 0; i < strA; i++)
                        {
                            for (int j = 0; j < strA * stlbB; j++)
                            {
                                this.matrU.Rows[i].Cells[j].Value = U[i, j];
                            }
                        }
                        int widthU = 0; int heightU = 0;
                        foreach (DataGridViewRow row in matrU.Rows)
                            heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                        foreach (DataGridViewColumn column in matrU.Columns)
                            widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                        if (C_view.Visible == true)
                            matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                        else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                        matrU.Size = new System.Drawing.Size(widthU, heightU);
                        matrU.Visible = true;
                        label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                        label30.Visible = true;

                        computing_UN(U, N, masA, masB, masC);
                    }
                }
                else if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {
                if (masC != null)
                {
                    DialogResult res = MessageBox.Show("Нельзя вывести ранг матрицы управления, не выведя саму матрицу! Продолжить?", "Ошибка!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes)
                    {
                        N = cl.MatrN(masA, masC, stlbA, strC);
                        matrN.RowCount = stlbA * strC;
                        matrN.ColumnCount = stlbA;
                        matrN.Font = new Font("Segoe UI", 8);
                        for (int i = 0; i < stlbA * strC; i++)
                        {
                            for (int j = 0; j < stlbA; j++)
                            {
                                this.matrN.Rows[i].Cells[j].Value = N[i, j];
                            }
                        }
                        int widthN = 0; int heightN = 0;
                        foreach (DataGridViewRow row in matrN.Rows)
                            heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                        foreach (DataGridViewColumn column in matrN.Columns)
                            widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                        if (C_view.Visible == true)
                            matrN.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                        else matrN.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                        matrN.Size = new System.Drawing.Size(widthN, heightN);
                        matrN.Visible = true;
                        label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                        label31.Visible = true;

                        computing_UN(U, N, masA, masB, masC);
                    }
                }
                else if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {
                if (masC != null)
                {
                    N = cl.MatrN(masA, masC, stlbA, strC);
                    rankN = cl.Rank(N);
                    matrN.RowCount = stlbA * strC;
                    matrN.ColumnCount = stlbA;
                    matrN.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < stlbA * strC; i++)
                    {
                        for (int j = 0; j < stlbA; j++)
                        {
                            this.matrN.Rows[i].Cells[j].Value = N[i, j];
                        }
                    }
                    int widthN = 0; int heightN = 0;
                    foreach (DataGridViewRow row in matrN.Rows)
                        heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrN.Columns)
                        widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrN.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrN.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrN.Size = new System.Drawing.Size(widthN, heightN);
                    matrN.Visible = true;
                    label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                    label31.Visible = true;
                    label33.Location = new System.Drawing.Point(matrN.Location.X + matrN.Size.Width + 15, matrN.Location.Y + (matrN.Size.Height / 2 - label32.Size.Height / 2));
                    label33.Text = "rgN=" + rankN;
                    label33.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                MessageBox.Show("Нельзя вывести ранги матриц, не выведя сами матрицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                if (masB != null)
                {
                    U = cl.MatrU(masA, masB, strA, stlbB);
                    matrU.RowCount = strA;
                    matrU.ColumnCount = strA * stlbB;
                    matrU.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < strA; i++)
                    {
                        for (int j = 0; j < strA * stlbB; j++)
                        {
                            this.matrU.Rows[i].Cells[j].Value = U[i, j];
                        }
                    }
                    int widthU = 0; int heightU = 0;
                    foreach (DataGridViewRow row in matrU.Rows)
                        heightU += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrU.Columns)
                        widthU += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrU.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrU.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrU.Size = new System.Drawing.Size(widthU, heightU);
                    matrU.Visible = true;
                    label30.Location = new System.Drawing.Point(matrU.Location.X - label30.Size.Width - 10, matrU.Location.Y + (matrU.Size.Height / 2 - label30.Size.Height / 2));
                    label30.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else if (masB == null) MessageBox.Show("Вы не ввели матрицу B", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                if (masC != null)
                {
                    N = cl.MatrN(masA, masC, stlbA, strC);
                    matrN.RowCount = stlbA * strC;
                    matrN.ColumnCount = stlbA;
                    matrN.Font = new Font("Segoe UI", 8);
                    for (int i = 0; i < stlbA * strC; i++)
                    {
                        for (int j = 0; j < stlbA; j++)
                        {
                            this.matrN.Rows[i].Cells[j].Value = N[i, j];
                        }
                    }
                    int widthN = 0; int heightN = 0;
                    foreach (DataGridViewRow row in matrN.Rows)
                        heightN += row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                    foreach (DataGridViewColumn column in matrN.Columns)
                        widthN += column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    if (C_view.Visible == true)
                        matrN.Location = new System.Drawing.Point(A_view.Location.X, C_view.Location.Y + C_view.Size.Height + 25);
                    else matrN.Location = new System.Drawing.Point(A_view.Location.X, A_view.Location.Y + A_view.Size.Height + 25);
                    matrN.Size = new System.Drawing.Size(widthN, heightN);
                    matrN.Visible = true;
                    label31.Location = new System.Drawing.Point(matrN.Location.X - label31.Size.Width - 10, matrN.Location.Y + (matrN.Size.Height / 2 - label31.Size.Height / 2));
                    label31.Visible = true;

                    computing_UN(U, N, masA, masB, masC);
                }
                else if (masC == null) MessageBox.Show("Вы не ввели матрицу C", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {
                MessageBox.Show("Нельзя вывести ранг матрицы управления, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {
                MessageBox.Show("Нельзя вывести ранг матрицы наблюдения, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void окрытьСистемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Text files | *.txt; | All Files (*.*) | *.*";
            string filename;
            if (file.ShowDialog() == DialogResult.OK)
            {
                filename = file.FileName;
                string[] dataString = File.ReadAllLines(filename);//массив для строк из файла
                if (dataString.Length == 6)//ABC
                {
                    string[] stA = dataString[1].Split(';');
                    string[] stB = dataString[3].Split(';');
                    string[] stC = dataString[5].Split(';');
                    masA = new double[stA.Length - 1, stA.Length - 1];
                    for (int i = 0; i < stA.Length - 1; i++)
                    {
                        string[] dan = stA[i].Split(' ');
                        for (int j = 0; j < dan.Length; j++)
                            masA[i, j] = Convert.ToDouble(dan[j]);
                    }
                    int countB = stB[0].Split(' ').Length;
                    masB = new double[countB, stB.Length - 1];
                    for (int k = 0; k < stB.Length - 1; k++)
                    {
                        string[] dan = stB[k].Split(' ');
                        for (int m = 0; m < countB; m++)
                            masB[m, k] = Convert.ToDouble(dan[m]);
                    }
                    int countC = stC[0].Split(' ').Length;
                    masC = new double[stC.Length - 1, countC];
                    for (int x = 0; x < stC.Length - 1; x++)
                    {
                        string[] dan = stC[x].Split(' ');
                        for (int z = 0; z < countC; z++)
                            masC[x, z] = Convert.ToDouble(dan[z]);
                    }
                    checkB.Checked = true;
                    checkC.Checked = true;
                    A.RowCount = masA.GetLength(0);
                    A.ColumnCount = masA.GetLength(1);
                    B.RowCount = masB.GetLength(0);
                    B.ColumnCount = masB.GetLength(1);
                    C.RowCount = masC.GetLength(0);
                    C.ColumnCount = masC.GetLength(1);
                    for (int i = 0; i < masA.GetLength(0); i++)
                        for (int j = 0; j < masA.GetLength(1); j++)
                        {
                            A.Rows[i].Cells[j].Value = masA[i, j];
                        }
                    for (int i = 0; i < masB.GetLength(0); i++)
                        for (int j = 0; j < masB.GetLength(1); j++)
                        {
                            B.Rows[i].Cells[j].Value = masB[i, j];
                        }
                    for (int i = 0; i < masC.GetLength(0); i++)
                        for (int j = 0; j < masC.GetLength(1); j++)
                        {
                            C.Rows[i].Cells[j].Value = masC[i, j];
                        }
                    button9.Enabled = true;
                    a_stroki.Text = masA.GetLength(0).ToString();
                    a_stolbci.Text = masA.GetLength(1).ToString();
                    strA = masA.GetLength(0);
                    stlbA = masA.GetLength(1);
                    buttonA.Text = "Изменить А / Очистить всё";
                    buttonB.Text = "Изменить В";
                    buttonC.Text = "Изменить С";
                    button4.Text = "Изменить";
                    button4.Enabled = true;
                    button6.Text = "Изменить";
                    //button9.Text = "Изменить";
                    button6.Enabled = true;
                    b_stolbci.Text = masB.GetLength(1).ToString();
                    b_stroki.Text = masB.GetLength(0).ToString();
                    strB = masB.GetLength(0);
                    stlbB = masB.GetLength(1);
                    с_stroki.Text = masC.GetLength(0).ToString();
                    с_stolbci.Text = masC.GetLength(1).ToString();
                    strC = masC.GetLength(0);
                    stlbC = masC.GetLength(1);
                }
                if (dataString.Length == 4) //AB or AC
                {
                    if (dataString[0] == "A")
                    {
                        string[] stA = dataString[1].Split(';');
                        masA = new double[stA.Length - 1, stA.Length - 1];
                        for (int i = 0; i < stA.Length - 1; i++)
                        {
                            string[] dan = stA[i].Split(' ');
                            for (int j = 0; j < dan.Length; j++)
                                masA[i, j] = Convert.ToDouble(dan[j]);
                        }
                        A.RowCount = masA.GetLength(0);
                        A.ColumnCount = masA.GetLength(1);
                        for (int i = 0; i < masA.GetLength(0); i++)
                            for (int j = 0; j < masA.GetLength(1); j++)
                            {
                                A.Rows[i].Cells[j].Value = masA[i, j];
                            }
                        a_stroki.Text = masA.GetLength(0).ToString();
                        a_stolbci.Text = masA.GetLength(1).ToString();
                        strA = masA.GetLength(0);
                        stlbA = masA.GetLength(1);
                        buttonA.Text = "Изменить А / Очистить всё";
                        button4.Enabled = true;
                        button4.Text = "Изменить";

                        if (dataString[2] == "B")
                        {
                            checkB.Checked = true;
                            checkC.Checked = false;
                            string[] stB = dataString[3].Split(';');
                            int count = stB[0].Split(' ').Length;
                            masB = new double[count, stB.Length - 1];
                            for (int k = 0; k < stB.Length - 1; k++)
                            {
                                string[] dan = stB[k].Split(' ');
                                for (int m = 0; m < count; m++)
                                    masB[m, k] = Convert.ToDouble(dan[m]);
                            }
                            B.RowCount = masB.GetLength(0);
                            B.ColumnCount = masB.GetLength(1);
                            for (int i = 0; i < masB.GetLength(0); i++)
                                for (int j = 0; j < masB.GetLength(1); j++)
                                {
                                    B.Rows[i].Cells[j].Value = masB[i, j];
                                }
                            b_stolbci.Text = masB.GetLength(1).ToString();
                            b_stroki.Text = masB.GetLength(0).ToString();
                            strB = masB.GetLength(0);
                            stlbB = masB.GetLength(1);
                            buttonB.Text = "Изменить В";
                            button6.Enabled = true;
                            //button6.Text = "Изменить";
                            button9.Enabled = false;
                            buttonC.Enabled = false;
                        }
                        else if (dataString[2] == "C")
                        {
                            checkC.Checked = true;
                            checkB.Checked = false;
                            string[] stC = dataString[3].Split(';');
                            int count = stC[0].Split(' ').Length;
                            masC = new double[stC.Length - 1, count];
                            for (int k = 0; k < stC.Length - 1; k++)
                            {
                                string[] dan = stC[k].Split(' ');
                                for (int m = 0; m < count; m++)
                                    masC[k, m] = Convert.ToDouble(dan[m]);
                            }
                            C.RowCount = masC.GetLength(0);
                            C.ColumnCount = masC.GetLength(1);
                            for (int i = 0; i < masC.GetLength(0); i++)
                                for (int j = 0; j < masC.GetLength(1); j++)
                                {
                                    C.Rows[i].Cells[j].Value = masC[i, j];
                                }
                            с_stroki.Text = masC.GetLength(0).ToString();
                            с_stolbci.Text = masC.GetLength(1).ToString();
                            strC = masC.GetLength(0);
                            stlbC = masC.GetLength(1);
                            buttonC.Text = "Изменить С";
                            button9.Enabled = true;
                            buttonB.Enabled = false;
                            button6.Enabled = false;
                        }
                    }
                    else
                        MessageBox.Show("Вы пытаетесь открыть неверный файл", "Неверный файл", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                if (dataString.Length == 2)
                {
                    if (dataString[0] == "A")
                    {
                        string[] mas1 = dataString[1].Split(';');//массив для строки данных
                        masA = new double[mas1.Length - 1, mas1.Length - 1]; ;
                        for (int i = 0; i < mas1.Length - 1; i++)
                        {
                            string[] dan = mas1[i].Split(',');
                            for (int j = 0; j < dan.Length; j++)
                                masA[i, j] = Convert.ToDouble(dan[j]);
                        }
                        A.RowCount = masA.GetLength(0);
                        A.ColumnCount = masA.GetLength(1);
                        for (int i = 0; i < masA.GetLength(0); i++)
                            for (int j = 0; j < masA.GetLength(1); j++)
                            {
                                A.Rows[i].Cells[j].Value = masA[i, j];
                            }
                        a_stroki.Text = masA.GetLength(0).ToString();
                        a_stolbci.Text = masA.GetLength(1).ToString();
                        strA = masA.GetLength(0);
                        stlbA = masA.GetLength(1);
                        buttonA.Text = "Изменить А / Очистить всё";
                        button4.Text = "Изменить";
                        button4.Enabled = true;
                        //button9.Enabled = true;
                    }
                    else
                        MessageBox.Show("Вы пытаетесь открыть неверный файл", "Неверный файл", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                if (dataString.Length == 0)
                    MessageBox.Show("Файл пустой. Невозможно его открыть. Выбрать другой файл?", "Файл пуст", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void сохранитьСистемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Plex files (*.txt)|*.txt|All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = save.FileName;
                FileStream aFile = new FileStream(filename, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(aFile);
                aFile.Seek(0, SeekOrigin.End);
                sw.WriteLine("A");
                for (int i = 0; i < strA; i++)
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        sw.Write(masA[i, j]);
                        if(j!=stlbA-1)
                            sw.Write(' ');
                    }
                    sw.Write(';');
                }
                if(masB!=null)
                {
                    sw.WriteLine();
                    sw.WriteLine("B");
                    for (int i = 0; i < stlbB; i++)
                    {
                        for (int j = 0; j < strB; j++)
                        {
                            sw.Write(masB[j, i]);
                            if (j != strB - 1)
                                sw.Write(' ');
                        }
                        sw.Write(';');
                    }
                }
                if(masC!=null)
                {
                    sw.WriteLine();
                    sw.WriteLine("C");
                    for (int i = 0; i < strC; i++)
                    {
                        for (int j = 0; j < stlbC; j++)
                        {
                            sw.Write(masC[i, j]);
                            if (j != stlbC - 1)
                                sw.Write(' ');
                        }
                        sw.Write(';');
                    }
                }
                sw.Close();
            }
        }
    }
}
