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
            A.RowCount = 15;
            A.ColumnCount = 15;

            C.RowCount = 15;
            C.ColumnCount = 15;
        }
    }

}
