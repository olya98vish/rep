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

            this.Text = String.Format("О программе {0}", AssemblyTitle);
            this.labelProductName.Text = "Matricula";
            this.labelVersion.Text = String.Format("Версия {0}", AssemblyVersion);
            int k= rnd.Next(1, 14);
            if (k <= 11)
            {
                if (k == 1)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\1.gif";
                if (k == 2)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\2.gif";
                if (k == 3)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\3.gif";
                if (k == 4)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\4.gif";
                if (k == 5)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\5.gif";
                if (k == 6)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\6.gif";
                if (k == 7)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\7.gif";
                if (k == 8)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\8.gif";
                if (k == 9)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\9.gif";
                if (k == 10)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\10.gif";
                logoPictureBox.BackgroundImage = Image.FromStream(new WebClient().OpenRead(path));
                ImageAnimator.Animate(logoPictureBox.BackgroundImage, OnFrameChanged);
            }
            else
            {
                if (k == 11)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\11.jpg";
                if (k == 12)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\12.jpg";
                if (k == 13)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\13.jpg";
                if (k == 14)
                    path = "C:\\Users\\megad\\Kursproject--Duble2\\картинки\\14.jpg";
                logoPictureBox.BackgroundImage = Image.FromStream(new WebClient().OpenRead(path));
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
    }
}
