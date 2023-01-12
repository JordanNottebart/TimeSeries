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

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btn_ExecuteRead_Click(object sender, EventArgs e)
        {
            FileInfo theFile = new FileInfo(pathofthefile.Text);

            if (theFile.Exists)
            {
                if (theFile.Extension == ".txt" || theFile.Extension == ".csv")
                {
                    Program.application.ReadInputTXT_CSV(theFile.FullName);
                }
                else
                {
                    Program.application.ReadInputXLS_XLSX(theFile.FullName);
                } 
            }
            else
            {
                output.Items.Add("Error 404 file not found");
            }
        }
    }
}
