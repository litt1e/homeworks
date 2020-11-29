using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab43
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Random rnd = new Random();

        private void Button1_Click(object sender, EventArgs e)
        { 
           //  Дан массив. Создать новый массив, элементами которого являются: количество 
          //  простых чисел, номера этих чисел, количество составных чисел и их номера.
            Int32 n;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите размер матрицы");
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                n = Convert.ToInt32(textBox1.Text);
                dataGridView1.ColumnCount = n+2;
                dataGridView2.ColumnCount = n+2;
                int[] arr = new int[n];
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewRow row2 = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row2.CreateCells(dataGridView2);
                for (int i = 0; i < n; i++)
                {
                    arr[i] = rnd.Next(0, 100);
                    row.Cells[i].Value = arr[i];
                }
                dataGridView1.Rows.Add(row);
                int[] primes = Array.FindAll(arr, x => isprime(x));
                int[] not_primes = Array.FindAll(arr, x => !isprime(x));
                int[] result = new int[2 + primes.Length + not_primes.Length];
                result[0] = primes.Length;
                Array.Copy(primes, 0, result, 1, primes.Length);
                result[primes.Length+1] = not_primes.Length;
                Array.Copy(not_primes, 0, result, primes.Length + 2, not_primes.Length);
                Array.ForEach(result, x => row2.Cells[Array.IndexOf(result, x)].Value = x);
                dataGridView2.Rows.Add(row2);
            }
        }
        static bool isprime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
                else if ((num >= -3) && (num <= 3))
                {
                    return true;
                }
            }
            return true;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
