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
    public partial class FormAC_view : Form
    {
        int VstrA, VstrC, VstlbA, VstlbC, maxA, maxC;

        double[,] VmasA;
        double[,] VmasC;

        public FormAC formAC;


        public FormAC_view(int strA, int stlbA, double[,] masA, int strC, int stlbC, double[,] masC, int maxA, int maxC)
        {
            this.VstrA = strA;
            this.VstrC = strC;
            this.VstlbA = stlbA;
            this.VstlbC = stlbC;
            this.maxA = maxA;
            this.maxC = maxC;

            VmasA = new double[VstrA, VstlbA];
            for (int i = 0; i < VstrA; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < VstlbA; j++)
                {
                    VmasA[i, j] = masA[i, j];
                    //this.A.Rows[i].Cells[j].Value = masA[i, j];
                }
            }
            VmasC = new double[VstrC, VstlbC];
            for (int i = 0; i < VstrC; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < VstlbC; j++)
                {
                    VmasC[i, j] = masC[i, j];
                    //this.A.Rows[i].Cells[j].Value = masA[i, j];
                }
            }


            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormAC_view_Load(object sender, EventArgs e)
        {
            if (VstlbA > 4)
            {
                //работа с активацией матрицы
                A.RowCount = VstrA;
                A.ColumnCount = VstlbA;
                int widthA = (maxA + VstlbA) * 9;
                int heightA = VstrA * 23;
                A.Size = new System.Drawing.Size(widthA, heightA);
                label18.Location = new System.Drawing.Point(6, heightA / 2);
                label3.Location = new System.Drawing.Point(8, heightA / 2 - 21);
                label20.Location = new System.Drawing.Point(6 + widthA + 10 + 52, heightA / 2);

                //работа с активацией матрицы
                C.RowCount = VstrC;
                C.ColumnCount = VstlbC;
                int widthC = (maxC + VstlbC) * 9;
                int heightC = VstrC * 23;
                C.Size = new System.Drawing.Size(widthC, heightC);
                C.Location = new System.Drawing.Point(64, 12 + heightA + 20);
                label19.Location = new System.Drawing.Point(6, 12 + heightA + 10 + heightC / 2);
                label22.Location = new System.Drawing.Point(64 + widthC + 10, 12 + 10 + heightA + heightC / 2);

                for (int i = 0; i < VstrA; i++)//матрица в памяти пока что нулевая
                {
                    for (int j = 0; j < VstlbA; j++)
                    {
                        this.A.Rows[i].Cells[j].Value = VmasA[i, j];
                    }
                }

                for (int i = 0; i < C.RowCount; i++)
                {
                    for (int j = 0; j < C.ColumnCount; j++)
                    {
                        this.C.Rows[i].Cells[j].Value = VmasC[i, j];
                    }
                }
            }
            else
            {
                //работа с активацией матрицы
                A.RowCount = VstrA;
                A.ColumnCount = VstlbA;
                int widthA = (maxA + VstlbA) * 9;
                int heightA = VstrA * 23;
                A.Size = new System.Drawing.Size(widthA, heightA);
                A.Location = new System.Drawing.Point(97, 12);
                label18.Location = new System.Drawing.Point(6 + 33, heightA / 2);
                label3.Location = new System.Drawing.Point(8 + 33, heightA / 2 - 21);
                label20.Location = new System.Drawing.Point(6 + 33 + widthA + 10 + 58, heightA / 2);

                //работа с активацией матрицы
                C.RowCount = VstrC;
                C.ColumnCount = VstlbC;
                int widthC = (maxC + VstlbC) * 9;
                int heightC = VstrC * 23;
                C.Size = new System.Drawing.Size(widthC, heightC);
                C.Location = new System.Drawing.Point(64 + 33, 12 + heightA + 20);
                label19.Location = new System.Drawing.Point(6 + 33, 12 + heightA + 10 + heightC / 2);
                label22.Location = new System.Drawing.Point(64 + 33 + widthC + 10, 12 + 10 + heightA + heightC / 2);

                for (int i = 0; i < VstrA; i++)//матрица в памяти пока что нулевая
                {
                    for (int j = 0; j < VstlbA; j++)
                    {
                        this.A.Rows[i].Cells[j].Value = VmasA[i, j];
                    }
                }

                for (int i = 0; i < C.RowCount; i++)
                {
                    for (int j = 0; j < C.ColumnCount; j++)
                    {
                        this.C.Rows[i].Cells[j].Value = VmasC[i, j];
                    }
                }
            }
        }
    }
}
