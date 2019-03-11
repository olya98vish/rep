using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApplication1
{
    partial class AboutBox1 : Form
    {
        string path;
        Random rnd = new Random();
        Form_main form = new Form_main();
        public AboutBox1()
        {
            InitializeComponent();

            this.Text = "Matricula";
            this.labelProductName.Text = String.Format("{0}", AssemblyTitle);
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            int k = rnd.Next(1, 14);
            switch (k)
            {
                case 1:
                    animate(Matricula.Properties.Resources.g1);
                    break;
                case 2:
                    animate(Matricula.Properties.Resources.g2);
                    break;
                case 3:
                    animate(Matricula.Properties.Resources.g3);
                    break;
                case 4:
                    animate(Matricula.Properties.Resources.g4);
                    break;
                case 5:
                    animate(Matricula.Properties.Resources.g5);
                    break;
                case 6:
                    animate(Matricula.Properties.Resources.g6);
                    break;
                case 7:
                    animate(Matricula.Properties.Resources.g7);
                    break;
                case 8:
                    animate(Matricula.Properties.Resources.g8);
                    break;
                case 9:
                    animate(Matricula.Properties.Resources.g9);
                    break;
                case 10:
                    animate(Matricula.Properties.Resources.g10);
                    break;
                case 11:
                    logoPictureBox.BackgroundImage = Matricula.Properties.Resources.im11;
                    break;
                case 12:
                    logoPictureBox.BackgroundImage = Matricula.Properties.Resources.im12;
                    break;
                case 13:
                    logoPictureBox.BackgroundImage = Matricula.Properties.Resources.im13;
                    break;
                case 14:
                    logoPictureBox.BackgroundImage = Matricula.Properties.Resources.im14;
                    break;
            }
            timer1.Start();
            timer1.Interval = 5000;           
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        public void animate(Bitmap pic)
        {
            logoPictureBox.BackgroundImage = pic;
            ImageAnimator.Animate(logoPictureBox.BackgroundImage, OnFrameChanged);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
