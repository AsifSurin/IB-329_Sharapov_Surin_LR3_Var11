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


namespace IB_329_Sharapov_Surin_LR3_Var11
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double overal_area = 0;
            for(int i = 0; i < chart1.Series[1].Points.Count - 1; i++)
            {
                double x0 = Convert.ToDouble(chart1.Series[1].Points[i].XValue);
                double y0 = Convert.ToDouble(chart1.Series[1].Points[i].YValues[0]);
                double x1 = Convert.ToDouble(chart1.Series[1].Points[i + 1].XValue);
                double y1 = Convert.ToDouble(chart1.Series[1].Points[i + 1].YValues[0]);

                double dx = x1 - x0;
                double mid_line = (y0 + y1) / 2.0;
                double area = dx * mid_line;
                overal_area += area;
            }
            textBox3.Text = overal_area.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            StreamReader sr = new StreamReader("C:\\Users\\shara\\OneDrive\\Рабочий стол\\points.txt");
            sr.ReadLine();
            int current_line = 0;
            while (!sr.EndOfStream)
            {
                string v = sr.ReadLine();
                string[] lines = v.Split('\t');
                Convert.ToDouble(lines[0]);
                dataGridView1.Rows.Add(lines[0], lines[1]);
                current_line++;
            }

            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            double left_border = -0.5;
            double right_border = 5;

            try
            {
                left_border = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение левого предела!", "Ошибка");
                left_border = -0.5;
                textBox1.Text = "-0,5";
            }

            try
            {
                right_border = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение правого предела!", "Ошибка");
                right_border = 5;
                textBox2.Text = "5";
            }
            if (left_border < -0.5 | left_border > 5)
            {
                MessageBox.Show("Левый предел не должен быть больше 5 или меньше -0.5!", "Ошибка");
                left_border = -0.5;
                textBox1.Text = Convert.ToString(left_border);
            }

            if (right_border > 5 | right_border < -0.5)
            {
                MessageBox.Show("Правый предел не должен быть больше 5 или меньше -0.5!", "Ошибка");
                right_border = 5;
                textBox2.Text = Convert.ToString(right_border);
            }
            if (left_border > right_border)
            {
                MessageBox.Show("Левый предел должен быть не больше правого!", "Ошибка");
                double buffer_var = left_border;
                left_border = right_border;
                right_border = buffer_var;
                textBox1.Text = Convert.ToString(left_border);
                textBox2.Text = Convert.ToString(right_border);
            }


            double[] x = new double[dataGridView1.Rows.Count- 1];

            double[] y = new double[dataGridView1.Rows.Count - 1];
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                x[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
                y[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                if (left_border < x[i] & x[i] < right_border)
                {
                    chart1.Series[1].Points.AddXY(x[i], y[i]);
                }

            }
            chart1.Series[0].Points.DataBindXY(x, y);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
