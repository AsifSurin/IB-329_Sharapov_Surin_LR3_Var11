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
using System.Windows.Forms.DataVisualization.Charting;

namespace IB_329_Sharapov_Surin_LR3_Var11
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = -0.599;
            double b = 5;

            listBox1.Items.Clear();
            int am;

            try
            {
                am = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение!", "Ошибка");
                am = 6;
                textBox1.Text = "6";
            }

            if (am <= 5) am = 6;

            double step = Math.Round((b - a) / (1.000 * am - 1.0), 4);

            double[] x = new double[am];


            double[] y = new double[am];
            for (int i = 0; i < am; i++)
            {
                x[i] = a + step * i;

                double v1 = 0.6 * Math.Pow(Math.Abs(x[i]), 1.0/3.0);
                double v2 = Math.Pow(Math.Cos(0.6), 3);
                double v3 = Math.Abs(x[i] - 0.6);
                double v4 = (1.0 + Math.Pow(Math.Sin(x[i]), 2)) / Math.Sqrt(x[i] + 0.6);
                double v5 = Math.Pow(Math.E, Math.Abs(x[i] - 0.6)) + (x[i] / 2.0);
                y[i] = 0.0 + v1 + v2*v3*v4/v5;
               
                listBox1.Items.Add(Math.Round(x[i], 3) + "\t" + Math.Round(y[i], 3));

            }
            chart1.Series[0].Points.DataBindXY(x, y);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\shara\\OneDrive\\Рабочий стол\\points.txt");
            sw.WriteLine("Координаты:");
            foreach (var item in listBox1.Items)
                sw.WriteLine(item.ToString());
            sw.Close();
        }

    }
}
