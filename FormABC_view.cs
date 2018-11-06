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
        int VstrA, VstrB, VstrC, VstlbA, VstlbB, VstlbC, maxA, maxB, maxC;

        double[,] VmasA;
        double[,] VmasB;
        double[,] VmasC;

        public FormABC formABC;

        public FormABC_view(int strA, int stlbA, double[,] masA, int strB, int stlbB, double[,] masB, 
            int strC, int stlbC, double[,] masC, int maxA, int maxB, int maxC)
        {
            this.VstrA = strA;
            this.VstrB = strB;
            this.VstrC = strC;
            this.VstlbA = stlbA;
            this.VstlbB = stlbB;
            this.VstlbC = stlbC;
            this.maxA = maxA;
            this.maxB = maxB;
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
            VmasB = new double[VstrB, VstlbB];
            for (int i = 0; i < VstrB; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < VstlbB; j++)
                {
                    VmasB[i, j] = masB[i, j];
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
            //FormABC formABC = new FormABC();
            //formABC.Show();
            this.Hide();
        }

        private void FormABC_view_Load(object sender, EventArgs e)
        {
            //работа с активацией матрицы
            A.RowCount = VstrA;
            A.ColumnCount = VstlbA;
            int widthA = (maxA + VstlbA) * 9;
            int heightA = VstrA * 23;
            A.Size = new System.Drawing.Size(widthA, heightA);
            label18.Location = new System.Drawing.Point(6, heightA/2);

            //работа с активацией матрицы
            B.RowCount = VstrB;
            B.ColumnCount = VstlbB;
            int widthB = (maxB + VstlbB) * 9;
            int heightB = VstrB * 23;
            B.Size = new System.Drawing.Size(widthB, heightB);
            label20.Location = new System.Drawing.Point(6 + widthA + 10 + 52, heightB / 2);
            B.Location = new System.Drawing.Point(6 + widthA + 10 + 52 + 59, 12);
            label21.Location = new System.Drawing.Point(6 + widthA + 20 + 59 + 52 + widthB, heightB / 2);

            //работа с активацией матрицы
            C.RowCount = VstrC;
            C.ColumnCount = VstlbC;
            int widthC = (maxC + VstlbC) * 9;
            int heightC = VstrC * 23;
            C.Size = new System.Drawing.Size(widthC, heightC);
            C.Location = new System.Drawing.Point(64, 12+heightA + 20);
            label19.Location = new System.Drawing.Point(6, 12 + heightA + 10 + heightC / 2);
            label22.Location = new System.Drawing.Point(64 + widthC + 10, 12 + 10 + heightA + heightC / 2);


            for (int i = 0; i < VstrA; i++)//матрица в памяти пока что нулевая
            {
                for (int j = 0; j < VstlbA; j++)
                {
                    this.A.Rows[i].Cells[j].Value = VmasA[i, j];
                }
            }

            for (int i = 0; i < B.RowCount; i++)
            {
                for (int j = 0; j < B.ColumnCount; j++)
                {
                    this.B.Rows[i].Cells[j].Value = VmasB[i, j];
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
