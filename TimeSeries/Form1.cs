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
            AllowDrop = true;
            DragDrop += new DragEventHandler(pathofthefile_DragDrop);
            DragEnter += new DragEventHandler(pathofthefile_DragEnter);
        }

        void pathofthefile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pathofthefile_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;
            if (data.ContainsFileDropList())
            {
                string[] rawFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (rawFiles != null)
                {
                    foreach (string path in rawFiles)
                    {
                        string pathExtension = Path.GetExtension(path);

                        if (pathExtension == ".txt" || pathExtension == ".csv" || pathExtension == ".xls" || pathExtension == ".xlsx")
                        {
                            pathofthefile.Text = path;
                        }
                        else
                        {
                            MessageBox.Show("Not a Text File or CSV File!");
                        }
                    }
                }
            }
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

        private void btn_ExecuteRead_Click(object sender, EventArgs e)
        {
            // If the filepath is not empty
            if (pathofthefile.Text != "")
            {
                FileInfo theFile = new FileInfo(pathofthefile.Text);

                // If the file exists
                if (theFile.Exists)
                {
                    TS_IFile tS_IFile;

                    // If the file has a .txt or .csv extension
                    if (theFile.Extension == ".txt" || theFile.Extension == ".csv")
                    {
                        tS_IFile = new TXT_CSVfile(theFile);
                    }
                    else
                    {
                        tS_IFile = new XLS_XLSXfile(theFile);
                    }

                    // Read the file
                    tS_IFile.ReadFile();
                }
                // If the file does not exist
                else
                {
                    output.Items.Add("Error 404 file not found");
                }
            }
            // If the filepath is empty
            else
            {
                MessageBox.Show("No file selected.");
            }
            
        }

        private void btn_CheckTimeSeries_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to see the data is incorrect path", "Check File", MessageBoxButtons.YesNo);


            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("The structure and data of this timeseries is incorrect");
                MessageBox.Show("The startdate comes after the enddate" + " on bucket 3");
            }
            else
            {
                MessageBox.Show("The structure and data of this timeseries is correct");
            }

        }
    }
}
