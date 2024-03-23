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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            StreamReader sr = new StreamReader("C:\\Users\\Асиф\\Desktop\\Учебный архив\\Информационные технологии\\Л. Р\\Л. Р. №3\\Координаты.txt");
            sr.ReadLine();
            int current_line = 0;
            while (!sr.EndOfStream)
            {
                string v = sr.ReadLine();
                string[] lines = v.Split('\t');
                dataGridView1.Rows[current_line].Cells[0].Value = lines[0];
                dataGridView1.Rows[current_line].Cells[1].Value = lines[1];
                current_line++;
                if (dataGridView1.Rows.Count - 1 < current_line) dataGridView1.Rows.Add();
            }

            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //double[] x = new double[];

            //double[] y = new double[];
            //chart1.Series[0].Points.DataBindXY(x, y);

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
