using System;
using System.Data;
using System.Windows.Forms;

namespace Aniya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_file_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            BindData(textBox1.Text);
        }

        private void BindData(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                //first line to create header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerLabel in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerLabel));
                }
                // data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerLabel in headerLabels)
                    {
                        dr[headerLabel] = data[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }

        }
    }
}
