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
        //иницилизация глобальных переменных
        public FormAC_view formAC_view;
        double[,] masA;//массив данных из datagrid A
        double[,] masC;//массив данных из datagrid C
        int strA = 0;
        int strC = 0;
        int stlbA = 0;
        int stlbC = 0;


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
            button1.Enabled = false;
            button1.Visible = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            for (int i = 1; i < 16; i++)
            {
                this.Controls["A" + i.ToString()].Enabled = false;
                this.Controls["C" + i.ToString()].Enabled = false;
            }
            с_stroki.ReadOnly = true;
            с_stolbci.ReadOnly = true;

            button2.Enabled = false;
            button1.Location = new System.Drawing.Point(1243, 9);
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;

        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            if ((с_stroki.Text != "") && (с_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(с_stroki.Text) > 0) && (Convert.ToInt32(с_stroki.Text) > 0) && (Convert.ToInt32(с_stolbci.Text) == Convert.ToInt32(a_stolbci.Text)))
                {
                    if ((Convert.ToInt32(с_stroki.Text) < 16))
                    {
                        if (buttonC.Text == "ОК")
                        {
                            button6.Enabled = true;
                            button7.Enabled = true;

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
                            button6.Enabled = false;
                            button7.Enabled = false;
                            button6.Text = "ОК";
                            button7.Text = "ОК";

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
                    else
                    {
                        //c_stolbci.Clear();
                        с_stroki.Clear();
                        MessageBox.Show("Значения числа строк и столбцов должны быть меньше 15!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        }
                        else
                        {
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button6.Enabled = false;
                            button7.Enabled = false;

                            buttonA.Text = "ОК";
                            buttonC.Text = "ОК";
                            button5.Text = "ОК";
                            button4.Text = "ОК";
                            button6.Text = "ОК";
                            button7.Text = "ОК";


                            a_stroki.ReadOnly = false;
                            a_stolbci.ReadOnly = false;

                            a_stroki.Clear();
                            a_stolbci.Clear();
                            с_stolbci.Clear();
                            с_stroki.Clear();

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
            if (buttonA.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить" )
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
            }
            else
            {
                button2.Enabled = false;
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "OK")
            {
                button7.Enabled = true;

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

                button6.Text = "Изменить";
                button7.Text = "Изменить";
            }
            else
            {
                button7.Enabled = false;
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

                button6.Text = "OK";
                button7.Text = "OK";
            }
            if (buttonA.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить")
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
            }
            else
            {
                button2.Enabled = false;
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
            }

        }

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

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "OK")
            {
                button6.Enabled = true;

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

                button6.Text = "Изменить";
                button7.Text = "Изменить";
            }
            else
            {
                button6.Enabled = false;

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

                button6.Text = "OK";
                button7.Text = "OK";
            }
            if (buttonA.Text == "Изменить" && buttonC.Text == "Изменить" && button4.Text == "Изменить" && button5.Text == "Изменить" &&
button6.Text == "Изменить" && button7.Text == "Изменить")
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
            }
            else
            {
                button2.Enabled = false;
                button1.Enabled = false;
                button1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
            }

        }

        private void A_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void C_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
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
            {
                e.Handled = true;
            }
        }

        private void a_stolbci_KeyDown(object sender, KeyEventArgs e)
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

        private void a_stolbci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void a_stroki_KeyDown(object sender, KeyEventArgs e)
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

        private void a_stroki_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            int maxA = 0;
            int maxC = 0;

            for (int i = 0; i < strA; i++)
            {
                //поиск максимальной длины в матрице А
                if (this.Controls["A" + (i + 1).ToString()].Text.Length > maxA)
                    maxA = this.Controls["A" + (i + 1).ToString()].Text.Length;
            }
            for (int i = 0; i < strC; i++)
            {
                //поиск максимальной длины в матрице С
                if (this.Controls["C" + (i + 1).ToString()].Text.Length > maxC)
                    maxC = this.Controls["C" + (i + 1).ToString()].Text.Length;
            }

            FormAC_view formAC_view = new FormAC_view(strA, stlbA, masA, strC, stlbC, masC, maxA, maxC);
            formAC_view.Show();
            formAC_view.Tag = this;
            //this.Hide();

        }
    }
}
