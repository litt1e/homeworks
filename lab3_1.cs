using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab31_cs
{
    public partial class Form1 : Form
    {
        public static double[] x = new double[100];
        public static double[] y = new double[100];
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            
            for (int i = 0; i < 100; i++)
            {
                x[i] = rnd.Next(-10000, 10000)/100.0;
                y[i] = rnd.Next(-10000, 10000)/100.0;
                dataGridView1.Rows.Add();
            }
            for(int i = 0; i<100; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = x[i].ToString();
                dataGridView1.Rows[i].Cells[1].Value = y[i].ToString();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if ((x[i] > 0) && (y[i] < 0))
                {
                    y[i] *= y[i];
                }
                else if ((x[i] < 0) && (y[i] > 0))
                {
                    x[i] *= x[i];
                }
                else if ((x[i] < 0) && (y[i] < 0))
                {
                    x[i] += 0.5;
                    y[i] += 0.5;
                }
                else
                {
                    double avg = (x[i] + y[i]) / 2;
                    x[i] = avg;
                    y[i] = avg;
                }
                dataGridView1.Rows[i].Cells[2].Value = x[i].ToString();
                dataGridView1.Rows[i].Cells[3].Value = y[i].ToString();
            }
        }
    }
}
