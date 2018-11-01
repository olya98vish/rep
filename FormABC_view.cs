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
    public partial class FormABC_view : Form
    {
        public FormABC formABC;
        int StrA = 0;
        int StrB = 0;
        int StrC = 0;
        int StlbA = 0;
        int StlbB = 0;
        int StlbC = 0;
        double[,] MasA;
        double[,] MasB;
        double[,] MasC;

        public FormABC_view(int strA, int stlbA, double[,] masA, int strB, int stlbB, double[,] masB, int strC, int stlbC, double[,] masC)
        {

            StrA = strA;
            StrB = strB;
            StrC = strC;
            StlbA = strA;
            StlbB = stlbB;
            StlbC = stlbC;
            MasA = new double[StrA, StlbA];
            for (int i = 0; i < StrA; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < StlbA; j++)
                {
                    MasA[i, j] = masA[i, j];
                }
            }



            InitializeComponent();
        }


        private void Back_Click(object sender, EventArgs e)
        {
            //FormABC formABC = new FormABC();
            //formABC.Show();
            this.Hide();
        }

        private void FormABC_view_Load(object sender, EventArgs e)
        {
            //заполнение таблицы значениями из строк
            for (int i = 0; i < A.RowCount; i++)
            {
                for (int j = 0; j < A.ColumnCount; j++)
                {
                    this.A.Rows[i].Cells[j].Value = MasA[i, j];
                }
            }

            //заполнение таблицы значениями из строк
            for (int i = 0; i<B.RowCount; i++)
            {
                for (int j = 0; j<B.ColumnCount; j++)
                {
                    this.B.Rows[i].Cells[j].Value = MasB[i, j];
                }
            }

            //заполнение таблицы значениями из строк
            for (int i = 0; i<C.RowCount; i++)
            {
                for (int j = 0; j<C.ColumnCount; j++)
                {
                    this.C.Rows[i].Cells[j].Value = MasC[i, j];
                }
            }


        }
    }
}
