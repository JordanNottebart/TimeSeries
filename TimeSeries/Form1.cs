using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            OpenFileDialog explorer = new OpenFileDialog();
            explorer.Title = "Choose a file";
            explorer.Filter = "Text Files (*.txt)|*.txt;|CSV Files (*.csv)|*.csv;|Excel Worksheets (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (explorer.ShowDialog() == DialogResult.OK)
            {
                pathofthefile.Text = explorer.FileName;
            }

        }
    }
}
