using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab42
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            Int32 n;
            if (textBox1.Text != "")
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                n = Convert.ToInt32(textBox1.Text);
                dataGridView1.ColumnCount = n;
                dataGridView2.ColumnCount = n;
                int[] arr = new int[n];
                Random rnd = new Random();
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewRow row2 = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row2.CreateCells(dataGridView2);
                for (int i = 0; i < n; i++)
                {
                    arr[i] = rnd.Next(-100, 100);
                    row.Cells[i].Value = arr[i];
                }
                dataGridView1.Rows.Add(row);

                int index_max = Array.IndexOf(arr, arr.Max());
                Array.Sort(arr, index_max + 1, arr.Length - index_max - 1);
                Array.ForEach(arr, x => row2.Cells[Array.IndexOf(arr, x)].Value = x);
                dataGridView2.Rows.Add(row2);
            }
            else
            {
                MessageBox.Show("Введите целое число");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
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
