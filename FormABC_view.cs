﻿using System;
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
        int VstrA, VstrB, VstrC, VstlbA, VstlbB, VstlbC;
        double[,] VmasA, VmasB, VmasC;
        public FormABC formABC;

        public FormABC_view(int strA, int stlbA, double[,] masA, int strB, int stlbB, double[,] masB, int strC, int stlbC, double[,] masC)
        {
            this.VstrA = strA;
            this.VstrB = strB;
            this.VstrC = strC;
            this.VstlbA = stlbA;
            this.VstlbB = stlbB;
            this.VstlbC = stlbC;

            VmasA = new double[strA, stlbA];
            for (int i = 0; i < strA; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < stlbA; j++)
                {
                    VmasA[i, j] = masA[i, j];
                    //this.A.Rows[i].Cells[j].Value = masA[i, j];
                }
            }
            //работа с активацией матрицы
            A.RowCount = strA;
            A.ColumnCount = stlbA;

            for (int i = 0; i < strA; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < stlbA; j++)
                {
                    this.A.Rows[i].Cells[j].Value = masA[i, j];
                }
            }

            ////работа с активацией матрицы
            //B.RowCount = strB;
            //B.ColumnCount = stlbB;

            ////заполнение таблицы значениями из строк
            //for (int i = 0; i<B.RowCount; i++)
            //{
            //    for (int j = 0; j<B.ColumnCount; j++)
            //    {
            //        this.B.Rows[i].Cells[j].Value = MasB[i, j];
            //    }
            //}

            ////заполнение таблицы значениями из строк
            //for (int i = 0; i<C.RowCount; i++)
            //{
            //    for (int j = 0; j<C.ColumnCount; j++)
            //    {
            //        this.C.Rows[i].Cells[j].Value = MasC[i, j];
            //    }
            //}


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
            A.RowCount = 0;
            A.ColumnCount = 0;

        }
    }
}
