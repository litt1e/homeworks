using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab32_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int n, m;
            if ((textBox1.Text != "") && (textBox1.Text != ""))
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                n = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox2.Text);
                int[][] matrix = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    matrix[i] = new int[m];
                }
                Random rnd = new Random();
                dataGridView1.ColumnCount = m;
                dataGridView2.ColumnCount = m;
                for (int i = 0; i < n; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewRow row2 = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row2.CreateCells(dataGridView2);
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i][j] = rnd.Next(-10, 10);
                        row.Cells[j].Value = matrix[i][j];
                    }
                    dataGridView1.Rows.Add(row);
                    int index = Array.IndexOf(matrix[i], matrix[i].Max());
                    Array.Sort(matrix[i], index+1, matrix[i].Length-index-1);
                    for (int j = 0; j < m; j++)
                    {
                        row2.Cells[j].Value = matrix[i][j];
                    }
                    dataGridView2.Rows.Add(row2);
                }
            }


        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
