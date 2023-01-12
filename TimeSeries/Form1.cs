using System;
using System.Windows.Forms;

namespace TimeSeries
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFile_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

            Program.application.ReadInputTXT("C:\\Users\\miar0\\Downloads\\", "examenvragen.txt");
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Program.application.ReadInputCSV("C:\\Users\\miar0\\Downloads\\", "output-onlinerandomtools.txt");
        }
    }
}
