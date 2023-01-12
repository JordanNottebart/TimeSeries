using System;
using System.Windows.Forms;
using System.IO;

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
            OpenFileDialog explorer = new OpenFileDialog();//Maakt een verkenner window aan
            explorer.Title = "Choose a file";//Maakt titel van het window
            explorer.Filter = "Text Files (*.txt)|*.txt;|CSV Files (*.csv)|*.csv;|Excel Worksheets (*.xls;*.xlsx)|*.xls;*.xlsx";//
            if (explorer.ShowDialog() == DialogResult.OK)//Als er iets is geselecteerd
            {
                pathofthefile.Text = explorer.FileName;//Zet de path naar de label
            }

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
