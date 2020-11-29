using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
Даны действительные числа х1...х101, у1...у101. Преобразовать эти числа по 
правилам: если они оба отрицательны, то кжадое из них увеличить на 0,5; 
Если отрицательно только одно чило, то отрицательное число заменить 
его квадратом; если оба чилса неотрицательны, то каждое из них 
заменить на среднее арифметическое исходных значений.
*/


namespace lab41
{
    public partial class Form1 : Form
    {
        public static double[] x = new double[100];
        public static double[] y = new double[100];
        public static double[][] xy = new double[100][];
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                xy[i] = new double[2];
                dataGridView2.Rows.Add();
                dataGridView3.Rows.Add();
                dataGridView4.Rows.Add();
            }

            for (int i = 0; i < 100; i++)
            {
                dataGridView1.Rows.Add();
                xy[i][0] = rnd.Next(-10000, 10000) / 100.0;
                xy[i][1] = rnd.Next(-10000, 10000) / 100.0;
            }
            for (int i = 0; i < 100; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = xy[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = xy[i][1].ToString();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double[][] both_lower_than_zero = Array.FindAll(xy, x => x[0] < 0 && x[1] < 0);
            double[][] one_lower_than_zero = Array.FindAll(xy, x => x[0] > 0 ^ x[1] > 0);
            double[][] both_more_than_zero = Array.FindAll(xy, x => x[0] > 0 && x[1] > 0);

            Array.ForEach(both_lower_than_zero, x => Array.ForEach(x, y => y += 0.5));

            Array.ForEach(one_lower_than_zero, x => Math.Pow(x[Array.FindIndex(x, y=>y < 0)], 2.0));
            Array.ForEach(both_more_than_zero, x => Array.ForEach(x, y => y = (x[0]+x[1])/2.0));

            Array.ForEach(both_lower_than_zero, x => Array.ForEach(x, y => dataGridView2.Rows[Array.IndexOf(both_lower_than_zero, x)].Cells[Array.IndexOf(x, y)].Value = y+0.5));
            Array.ForEach(one_lower_than_zero, x => Array.ForEach(x, y => dataGridView3.Rows[Array.IndexOf(one_lower_than_zero, x)].Cells[Array.IndexOf(x, y)].Value = y > 0? y : y*y));
            Array.ForEach(both_more_than_zero, x => Array.ForEach(x, y => dataGridView4.Rows[Array.IndexOf(both_more_than_zero, x)].Cells[Array.IndexOf(x, y)].Value = x.Average()));
            double[][] result = new double[both_lower_than_zero.Length + one_lower_than_zero.Length + both_more_than_zero.Length][];

            both_lower_than_zero.CopyTo(result, 0);
            one_lower_than_zero.CopyTo(result, both_lower_than_zero.Length);
            both_more_than_zero.CopyTo(result, both_lower_than_zero.Length + one_lower_than_zero.Length);

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
