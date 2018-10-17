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
        int[,] masA;//массив данных из datagrid A
        int[,] masB;//массив данных из datagrid B
        int[,] masC;//массив данных из datagrid C


        public FormABC()
        {
            InitializeComponent();
            //SetReadOnlyInTextBoxA();.
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
            //A.RowCount = 15;
            //A.ColumnCount = 15;

            //B.RowCount = 15;
            //B.ColumnCount = 15;

            //C.RowCount = 15;
            //C.ColumnCount = 15;

            //отрисовка границ на форме
            //Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
            //e.Graphics.DrawRectangle(blackPen, 10, 10, 100, 50);

            //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //e.Graphics.DrawLine(pen, 20, 10, 300, 100);

            for (int i = 1; i < 16; i++)
            {
                this.Controls["A" + i.ToString()].Enabled = false;
                this.Controls["B" + i.ToString()].Enabled = false;
                this.Controls["C" + i.ToString()].Enabled = false;
            }
            b_stroki.ReadOnly = true;
            c_stroki.ReadOnly = true;
            c_stolbci.ReadOnly = true;
            b_stolbci.ReadOnly = true;

            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button10.Enabled = false;
            button9.Enabled = false;
        }

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

                            masA = new int[strA, stlbA];

                            b_stroki.Text = strA.ToString();
                            b_stroki.ReadOnly = true;
                            c_stolbci.Text = stlbA.ToString();
                            c_stolbci.ReadOnly = true;

                            //активация нужных строк из текстбоксов, остальное неактивно
                            for (int i = 1; i <= strA; i++)
                            {
                                this.Controls["A" + i.ToString()].Enabled = true;
                            }
                            //работа с активацией матрицы
                            A.RowCount = strA;
                            A.ColumnCount = stlbA;

                            c_stroki.ReadOnly = false;
                            b_stolbci.ReadOnly = false;
                        }
                        else
                        {
                            button4.Enabled = false;
                            button5.Enabled = false;

                            buttonA.Text = "ОК";
                            buttonB.Text = "ОК";
                            buttonC.Text = "ОК";

                            a_stroki.ReadOnly = false;
                            a_stolbci.ReadOnly = false;

                            a_stroki.Clear();
                            a_stolbci.Clear();
                            b_stolbci.Clear();
                            b_stroki.Clear();
                            c_stolbci.Clear();
                            c_stroki.Clear();

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
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
                        int strA = Convert.ToInt32(a_stroki.Text);

                        if (buttonB.Text == "ОК")
                        {
                            button6.Enabled = true;
                            button7.Enabled = true;

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
                            button6.Enabled = false;
                            button7.Enabled = false;

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

            if ((c_stroki.Text != "") && (c_stolbci.Text != ""))
            {
                if ((Convert.ToInt32(c_stroki.Text) > 0) && (Convert.ToInt32(c_stroki.Text) > 0) && (Convert.ToInt32(c_stolbci.Text) == Convert.ToInt32(a_stolbci.Text)))
                {
                    if ((Convert.ToInt32(c_stroki.Text) < 16) && (Convert.ToInt32(c_stroki.Text) < 16))
                    {
                        int stlbA = Convert.ToInt32(a_stolbci.Text);

                        if (buttonC.Text == "ОК")
                        {
                            button10.Enabled = true;
                            button9.Enabled = true;

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
                            button10.Enabled = false;
                            button9.Enabled = false;

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

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')) && !((e.KeyChar == ',')) && !((e.KeyChar == '.')) && !((e.KeyChar == '*')) && !((e.KeyChar == '^')) && !((e.KeyChar == ';')))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

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
                //таблица недоступна для пользователя
                A.ReadOnly = true;
                A.Enabled = false;

                //текстбоксы недоступны для пользователя
                for (int i = 1; i < 16; i++)
                {
                    this.Controls["A" + i.ToString()].Enabled = false;
                }

                for (int i = 0; i < A.RowCount; i++)
                {
                    for (int j = 0; j < A.ColumnCount; j++)
                    {
                        //заполнение непроставленных пользователем строк нулями
                        //if (Convert.ToInt32(A.Rows[i].Cells[j].Value) == 0)
                        if (string.IsNullOrEmpty(A.Rows[i].Cells[j].Value as string))
                        {
                            A.Rows[i].Cells[j].Value = 0;
                        }

                        masA[i, j] = Convert.ToInt32(A.Rows[i].Cells[j].Value.ToString());
                    }
                }

                int strA = 0;
                int stlbA = 0;
                strA = Convert.ToInt32(a_stroki.Text);
                stlbA = Convert.ToInt32(a_stolbci.Text);

                //проставление в нужные текстбоксы значений из таблицы
                for (int i = 0; i < strA; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.Controls["A" + (i + 1).ToString()].Text += masA[i, j].ToString() + ";";
                    }
                }

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

                for (int i = 0; i < strA; i++)//strA == RowsCount of datagrid A
                {
                    for (int j = 0; j < stlbA; j++)
                    {
                        this.Controls["A" + (i + 1).ToString()].Text = "";
                    }
                }

                button4.Text = "OK";
            }
        }
    }
}