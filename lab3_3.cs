using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab33
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static bool isprime(int num)
        {
            for (int i = 2; i <= Math.Pow(num, 0.5); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
                else if ((num == 0) || (num == 1) || (num == 2) || (num == 3))
                {
                    return true;
                }
            }
            return true;
        }

        static bool lineisnotprime(Int32[] nums, Int32 length)
        {
            int res = 0;
            for (int i = 0; i < length; i++)
            {
                if (isprime(nums[i]))
                {
                    res++;
                }
            }
            if (res == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool onlyone(Int32[] nums, int length)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (count == 2)
                {
                    break;
                }
                else if (isprime(nums[i]))
                {
                    count++;
                }
            }
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool onlytwo(Int32[] nums, Int32 length)
        {
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (count == 3)
                {
                    break;
                }
                else if (isprime(nums[i]))
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static Int32[] get_matrix_line(Int32[,] matrix, Int32 line, Int32 len)
        {
            Int32[] result = new Int32[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = matrix[line, i];
            }
            return result;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите размер матрицы");
            }
            else
            {
                dataGridView2.Rows.Clear();
                Int32 size = Convert.ToInt32(textBox1.Text);
                Int32[,] matrix = new Int32[size, size];
                Int32[,] result = new Int32[3, size];
                Random ran = new Random();
                dataGridView1.RowCount = size;
                dataGridView1.ColumnCount = size;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i, j] = ran.Next(0, 100);
                        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                    }
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                dataGridView2.RowCount = 3;
                dataGridView2.ColumnCount = size;
                for (int i = 0; i < size; i++)
                {

                    if (lineisnotprime(get_matrix_line(matrix, i, size), size))
                    {
                        result[0, i] = i + 1;
                        dataGridView2.Rows[0].Cells[i].Value = result[0, i];
                    }
                    else if (onlytwo(get_matrix_line(matrix, i, size), size))
                    {
                        result[2, i] = i;
                        dataGridView2.Rows[2].Cells[i].Value = i + 1;
                    }
                    else if (onlyone(get_matrix_line(matrix, i, size), size))
                    {
                        result[1, i] = i;
                        dataGridView2.Rows[1].Cells[i].Value = i + 1;
                    }
                }
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            }
        }
    }
}
