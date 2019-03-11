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
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;//путь в проект - откуда запустились
            //var path = Path.GetDirectoryName(location);
            int k = rnd.Next(1, 14);
            string directory= @"C:\Users\Евгения\Source\Repos\rep\картинки";
            if (k <= 11)
            {
                if (k == 1)
                    path = directory + @"\1.gif";//"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\1.gif";
                if (k == 2)
                    path = directory + @"\2.gif";//"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\2.gif";
                if (k == 3)
                    path = directory + @"\3.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\3.gif";
                if (k == 4)
                    path = directory + @"\4.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\4.gif";
                if (k == 5)
                    path = directory + @"\5.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\5.gif";
                if (k == 6)
                    path = directory + @"\6.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\6.gif";
                if (k == 7)
                    path = directory + @"\7.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\7.gif";
                if (k == 8)
                    path = directory + @"\8.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\8.gif";
                if (k == 9)
                    path = directory + @"\9.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\9.gif";
                if (k == 10)
                    path = directory + @"\10.gif"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\10.gif";
                logoPictureBox.BackgroundImage = Image.FromStream(new WebClient().OpenRead(path));
                ImageAnimator.Animate(logoPictureBox.BackgroundImage, OnFrameChanged);
            }
            else
            {
                if (k == 11)
                    path = directory + @"\11.jpg"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\11.jpg";
                if (k == 12)
                    path = directory + @"\12.jpg"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\12.jpg";
                if (k == 13)
                    path = directory + @"\13.jpg"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\13.jpg";
                if (k == 14)
                    path = directory + @"\14.jpg"; //"C:\\Users\\megad\\Kursproject--Duble2\\картинки\\14.jpg";
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

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
