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
        public FormABC_view()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            FormABC formABC = new FormABC();
            formABC.Show();
            this.Hide();
        }
    }
}
