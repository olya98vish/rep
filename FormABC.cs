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
        //иницилизация глобальных переменных
        double[,] masA;//массив данных из datagrid A
        double[,] masB;//массив данных из datagrid B
        double[,] masC;//массив данных из datagrid C


        public FormABC()
        {
            InitializeComponent();

            button1.Enabled = false;
            button1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            a_view.Visible = false;
            b_view.Visible = false;
            c_view.Visible = false;

            //SetReadOnlyInTextBoxA();
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
            for (int i = 1; i < 16; i++)
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
                        if (Convert.ToInt32(A.Rows[i].Cells[j].Value) == 0)
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
                        if (Convert.ToInt32(B.Rows[i].Cells[j].Value) == 0)
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
                        if (Convert.ToInt32(C.Rows[i].Cells[j].Value) == 0)
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

        private void take_data_from_textbox(string datagrid, int str, int stlb)
        {//взятие данных из строк в массив памяти
            if (datagrid == "A")
            {
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlb; j++)
                    {
                        if (this.Controls["A" + (i + 1).ToString()].Text != "")
                        {
                            string[] ss = this.Controls["A" + (i + 1).ToString()].Text.Split(';');
                            masA[i, j] = double.Parse(ss[j]);
                        }
                        else
                            masA[i, j] = 0;
                    }
                }
            }
            if (datagrid == "B")
            {
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlb; j++)
                    {
                        if (this.Controls["B" + (i + 1).ToString()].Text != "")
                        {
                            string[] ss = this.Controls["B" + (i + 1).ToString()].Text.Split(';');
                            masB[i, j] = double.Parse(ss[j]);
                        }
                        else
                            masB[i, j] = 0;
                    }
                }
            }
            if (datagrid == "C")
            {
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlb; j++)
                    {
                        if (this.Controls["C" + (i + 1).ToString()].Text != "")
                        {
                            string[] ss = this.Controls["C" + (i + 1).ToString()].Text.Split(';');
                            masC[i, j] = double.Parse(ss[j]);
                        }
                        else
                            masC[i, j] = 0;
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

                //проставление в нужные текстбоксы значений из таблицы
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid A
                {
                    this.Controls["A" + (i + 1).ToString()].Text = "";
                }
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlb; j++)
                    {
                        if (j != stlb - 1)
                        {
                            this.Controls["A" + (i + 1).ToString()].Text += masA[i, j].ToString() + ";";
                        }
                        else
                            this.Controls["A" + (i + 1).ToString()].Text += masA[i, j].ToString();
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

                //проставление в нужные текстбоксы значений из таблицы
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid 
                {
                    this.Controls["B" + (i + 1).ToString()].Text = "";
                }     
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid
                {
                    for (int j = 0; j < stlb; j++)
                    {
                        if (j != stlb - 1)
                        {
                            this.Controls["B" + (i + 1).ToString()].Text += masB[i, j].ToString() + ";";
                        }
                        else
                            this.Controls["B" + (i + 1).ToString()].Text += masB[i, j].ToString();
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

                //проставление в нужные текстбоксы значений из таблицы
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid 
                {
                    this.Controls["C" + (i + 1).ToString()].Text = "";
                }
                for (int i = 0; i < str; i++)//strA == RowsCount of datagrid 
                {
                    for (int j = 0; j < stlb; j++)
                    {
                        if (j != stlb - 1)
                        {
                            this.Controls["C" + (i + 1).ToString()].Text += masC[i, j].ToString() + ";";
                        }
                        else
                            this.Controls["C" + (i + 1).ToString()].Text += masC[i, j].ToString();
                    }
                }
            }
        }
#endregion//тут лежат функции взятия и вывода данных

        private void button2_Click(object sender, EventArgs e)
        {
            int strA = 0;
            int stlbA = 0;
            if ((a_stroki.Text != "") && (a_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(a_stroki.Text) > 0) && (Convert.ToInt32(a_stroki.Text) > 0))
                {
                    if ((Convert.ToInt32(a_stroki.Text) < 16) && (Convert.ToInt32(a_stroki.Text) < 16))
                    {
                        if (buttonA.Text == "ОК")
                        {
                            button4.Enabled = true;
                            button5.Enabled = true;

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

                            buttonA.Text = "ОК";
                            buttonB.Text = "ОК";
                            buttonC.Text = "ОК";
                            button5.Text = "ОК";
                            button4.Text = "ОК";

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

        private void Back_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int strB = 0;
            int stlbB = 0;
            
            if ((b_stroki.Text != "") && (b_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(b_stroki.Text) > 0) && (Convert.ToInt32(b_stroki.Text) > 0)&&(Convert.ToInt32(b_stroki.Text) == Convert.ToInt32(a_stroki.Text)))
                {
                    if ((Convert.ToInt32(b_stroki.Text) < 16) && (Convert.ToInt32(b_stroki.Text) < 16))
                    {
                        if (buttonB.Text == "ОК")
                        {
                            button6.Enabled = true;
                            button7.Enabled = true;

                            b_stroki.ReadOnly = true;
                            b_stolbci.ReadOnly = true;
                            buttonB.Text = "Изменить";

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
                            button6.Enabled = false;
                            button7.Enabled = false;
                            button6.Text = "ОК";
                            button7.Text = "ОК";

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

        private void button1_Click(object sender, EventArgs e)
        {
            int strC = 0;
            int stlbC = 0;

            if ((с_stroki.Text != "") && (с_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(с_stroki.Text) > 0) && (Convert.ToInt32(с_stroki.Text) > 0) && (Convert.ToInt32(с_stolbci.Text) == Convert.ToInt32(a_stolbci.Text)))
                {
                    if ((Convert.ToInt32(с_stroki.Text) < 16) && (Convert.ToInt32(с_stroki.Text) < 16))
                    {
                        if (buttonC.Text == "ОК")
                        {
                            button10.Enabled = true;
                            button9.Enabled = true;

                            с_stroki.ReadOnly = true;
                            с_stolbci.ReadOnly = true;
                            buttonC.Text = "Изменить";

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
                            button10.Enabled = false;
                            button9.Enabled = false;
                            button10.Text = "ОК";
                            button9.Text = "ОК";

                            buttonC.Text = "ОК";
                            с_stroki.ReadOnly = false;
                            //c_stolbci.ReadOnly = false;

                            с_stroki.Clear();
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
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')) && !((e.KeyChar == '*')) && !((e.KeyChar == '^')) && !((e.KeyChar == ';')) && !((e.KeyChar == '(')) && !((e.KeyChar == ')')) && !((e.KeyChar == ','))) //&& !((e.KeyChar == '.'))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        //штука, которая ограничивает ввод данных в датагриды
        private void A_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void B_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void C_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "OK")
            {
                button5.Enabled = true;

                //таблица недоступна для пользователя
                A.ReadOnly = true;
                A.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["A" + i.ToString()].Enabled = false;
                }

                take_data_from_matrix("A", A.RowCount, A.ColumnCount);

                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                output_data("A", strA, stlbA);

                button4.Text = "Изменить";
                button5.Text = "Изменить";
            }
            else
            {
                button5.Enabled = false;
                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                A.ReadOnly = false;
                A.Enabled = true;

                for (int i = 0; i < strA; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.Controls["A" + (i + 1).ToString()].Text = "";
                    }
                }

                button4.Text = "OK";
                button5.Text = "OK";
            }

            if (buttonA.Text == "Изменить" && buttonB.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" && button9.Text == "Изменить" && button10.Text == "Изменить")
            {
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                a_view.Visible = true;
                b_view.Visible = true;
                c_view.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                a_view.Visible = false;
                b_view.Visible = false;
                c_view.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "OK")
            {
                button4.Enabled = true;

                //таблица недоступна для пользователя
                A.ReadOnly = true;
                A.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["A" + i.ToString()].Enabled = false;
                }

                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                take_data_from_textbox("A", strA, stlbA);//взяли данные из текстбокса

                output_data("A", strA, stlbA);//выведем из памяти в датагрид и текстбоксы

                button4.Text = "Изменить";
                button5.Text = "Изменить";
            }
            else
            {
                button4.Enabled = false;

                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                A.ReadOnly = true;
                A.Enabled = false;

                //сделаем пустой таблицу
                for (int i = 0; i < A.RowCount; i++)
                {
                    for (int j = 0; j < A.ColumnCount; j++)
                    {
                        A.Rows[i].Cells[j].Value = 0;
                    }
                }

                for (int i = 0; i < strA; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.Controls["A" + (i + 1).ToString()].Enabled = true;
                    }
                }

                button4.Text = "OK";
                button5.Text = "OK";
            }

            if (buttonA.Text == "Изменить" && buttonB.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" && button9.Text == "Изменить" && button10.Text == "Изменить")
            {
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                a_view.Visible = true;
                b_view.Visible = true;
                c_view.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                a_view.Visible = false;
                b_view.Visible = false;
                c_view.Visible = false;
            }
        }

        //-----//ограничение на ввод в текстбокс
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        // Handle the KeyDown event to determine the type of character entered into the control.
        private void A1_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A2_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A3_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A4_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A5_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A6_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A7_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A8_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A9_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A10_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A11_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A12_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A13_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A14_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void A15_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void A15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "OK")
            {
                button7.Enabled = true;

                //таблица недоступна для пользователя
                B.ReadOnly = true;
                B.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["B" + i.ToString()].Enabled = false;
                }

                take_data_from_matrix("B", B.RowCount, B.ColumnCount);

                int strB = 0;
                int stlbB = 0;
                strB = Convert.ToInt32(b_stroki.Text);
                stlbB = Convert.ToInt32(b_stolbci.Text);

                output_data("B", strB, stlbB);

                button6.Text = "Изменить";
                button7.Text = "Изменить";
            }
            else
            {
                button7.Enabled = false;
                int strB = 0;
                int stlbB = 0;
                strB = Convert.ToInt32(b_stroki.Text);
                stlbB = Convert.ToInt32(b_stolbci.Text);

                B.ReadOnly = false;
                B.Enabled = true;

                for (int i = 0; i < strB; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbB; j++)
                    {
                        this.Controls["B" + (i + 1).ToString()].Text = "";
                    }
                }

                button6.Text = "OK";
                button7.Text = "OK";
            }

            if (buttonA.Text == "Изменить" && buttonB.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" && button9.Text == "Изменить" && button10.Text == "Изменить")
            {
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                a_view.Visible = true;
                b_view.Visible = true;
                c_view.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                a_view.Visible = false;
                b_view.Visible = false;
                c_view.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "OK")
            {
                button6.Enabled = true;

                //таблица недоступна для пользователя
                B.ReadOnly = true;
                B.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["B" + i.ToString()].Enabled = false;
                }

                int strB = 0;
                int stlbB = 0;
                strB = Convert.ToInt32(b_stroki.Text);
                stlbB = Convert.ToInt32(b_stolbci.Text);

                take_data_from_textbox("B", strB, stlbB);//взяли данные из текстбокса

                output_data("B", strB, stlbB);//выведем из памяти в датагрид и текстбоксы

                button6.Text = "Изменить";
                button7.Text = "Изменить";
            }
            else
            {
                button6.Enabled = false;

                int strB = 0;
                int stlbB = 0;
                strB = Convert.ToInt32(b_stroki.Text);
                stlbB = Convert.ToInt32(b_stolbci.Text);

                B.ReadOnly = true;
                B.Enabled = false;

                //сделаем пустой таблицу
                for (int i = 0; i < B.RowCount; i++)
                {
                    for (int j = 0; j < B.ColumnCount; j++)
                    {
                        B.Rows[i].Cells[j].Value = 0;
                    }
                }

                for (int i = 0; i < strB; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbB; j++)
                    {
                        this.Controls["B" + (i + 1).ToString()].Enabled = true;
                    }
                }

                button6.Text = "OK";
                button7.Text = "OK";
            }
            if (buttonA.Text == "Изменить" && buttonB.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" && button9.Text == "Изменить" && button10.Text == "Изменить")
            {
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                a_view.Visible = true;
                b_view.Visible = true;
                c_view.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                a_view.Visible = false;
                b_view.Visible = false;
                c_view.Visible = false;
            }
        }
        #region
        private void B1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B2_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B3_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B4_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B5_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B6_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B7_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B8_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B9_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B10_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B11_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B12_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B13_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B14_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void B15_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void B15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }
        #endregion//
        //-----//ограничение на ввод в текстбокс

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "OK")
            {
                button10.Enabled = true;

                //таблица недоступна для пользователя
                C.ReadOnly = true;
                C.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["C" + i.ToString()].Enabled = false;
                }

                take_data_from_matrix("C", C.RowCount, C.ColumnCount);

                int strС = 0;
                int stlbС = 0;
                strС = Convert.ToInt32(с_stroki.Text);
                stlbС = Convert.ToInt32(с_stolbci.Text);

                output_data("C", strС, stlbС);

                button9.Text = "Изменить";
                button10.Text = "Изменить";
            }
            else
            {
                button10.Enabled = false;
                int strС = 0;
                int stlbС = 0;
                strС = Convert.ToInt32(с_stroki.Text);
                stlbС = Convert.ToInt32(с_stolbci.Text);

                C.ReadOnly = false;
                C.Enabled = true;

                for (int i = 0; i < strС; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbС; j++)
                    {
                        this.Controls["C" + (i + 1).ToString()].Text = "";
                    }
                }

                button9.Text = "OK";
                button10.Text = "OK";
            }
            if (buttonA.Text == "Изменить" && buttonB.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" && button9.Text == "Изменить" && button10.Text == "Изменить")
            {
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                a_view.Visible = true;
                b_view.Visible = true;
                c_view.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                a_view.Visible = false;
                b_view.Visible = false;
                c_view.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "OK")
            {
                button9.Enabled = true;

                //таблица недоступна для пользователя
                C.ReadOnly = true;
                C.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["C" + i.ToString()].Enabled = false;
                }

                int strС = 0;
                int stlbС = 0;
                strС = Convert.ToInt32(с_stroki.Text);
                stlbС = Convert.ToInt32(с_stolbci.Text);

                take_data_from_textbox("C", strС, stlbС);//взяли данные из текстбокса

                output_data("C", strС, stlbС);//выведем из памяти в датагрид и текстбоксы

                button9.Text = "Изменить";
                button10.Text = "Изменить";
            }
            else
            {
                button9.Enabled = false;

                int strС = 0;
                int stlbС = 0;
                strС = Convert.ToInt32(с_stroki.Text);
                stlbС = Convert.ToInt32(с_stolbci.Text);

                C.ReadOnly = true;
                C.Enabled = false;

                //сделаем пустой таблицу
                for (int i = 0; i < C.RowCount; i++)
                {
                    for (int j = 0; j < C.ColumnCount; j++)
                    {
                        C.Rows[i].Cells[j].Value = 0;
                    }
                }

                for (int i = 0; i < strС; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbС; j++)
                    {
                        this.Controls["C" + (i + 1).ToString()].Enabled = true;
                    }
                }

                button9.Text = "OK";
                button10.Text = "OK";
            }
            if (buttonA.Text == "Изменить" && buttonB.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" && button9.Text == "Изменить" && button10.Text == "Изменить")
            {
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                a_view.Visible = true;
                b_view.Visible = true;
                c_view.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                a_view.Visible = false;
                b_view.Visible = false;
                c_view.Visible = false;
            }
        }
        #region
        private void C1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C2_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C3_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C4_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C5_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C6_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C7_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C8_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C9_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C10_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C11_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C12_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C13_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C14_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }

        private void C15_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemSemicolon && e.KeyCode != Keys.Oemcomma)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }

        private void C15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
                e.Handled = true;
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)//ПРОДУМАТЬ ВСЕ ВАРИАНТЫ!!!
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
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((checkBox1.Checked) && !(checkBox2.Checked) && (checkBox3.Checked) && !(checkBox4.Checked))
            {//ошибка
                MessageBox.Show("Нельзя вывести ранг матрицы, не выведя саму матрицу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && !(checkBox3.Checked) && (checkBox4.Checked))
            {
                //
            }
            else if (!(checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                //
            }
            else if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked) && (checkBox4.Checked))
            {
                //
            }

            else
            {
                MessageBox.Show("Хотя бы одна позиция должна быть выбрана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

