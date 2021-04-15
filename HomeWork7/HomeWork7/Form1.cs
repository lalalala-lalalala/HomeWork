using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        int num1;
        double num2;
        double num3;
        double num4;
        double num5;
        double num6;
        private Graphics graphics;
        Pen pen = Pens.Orange;

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();

            num1 = (int)numericUpDown1.Value;
            num2 = (double)numericUpDown2.Value;
            num3 = (double)numericUpDown3.Value;
            num4 = (double)numericUpDown4.Value;
            num5 = (double)numericUpDown5.Value;
            num6 = (double)numericUpDown6.Value;

            switch (textBox1.Text)
            {
                case "蓝色": pen = Pens.Blue; break;
                case "绿色": pen = Pens.Green; break;
                case "红色": pen = Pens.Red; break;
                case "黄色": pen = Pens.Yellow; break;
                case "紫色": pen = Pens.Purple; break;
                default: pen = Pens.Blue; break;
            }

            drawCayleyTree(num1, 200, 310, num2, -Math.PI / 2);
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, num3 * leng, th + num5 * Math.PI / 180);
            drawCayleyTree(n - 1, x1, y1, num4 * leng, th - num6 * Math.PI / 180);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        //private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        //{
        //    num1 = (int)numericUpDown1.Value;
        //}

        //private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        //{
        //    num2 = (double)numericUpDown2.Value;
        //}

        //private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        //{
        //    num3 = (double)numericUpDown3.Value;
        //}

        //private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        //{
        //    num4 = (double)numericUpDown4.Value;
        //}

        //private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        //{
        //    num5 = (double)numericUpDown5.Value;
        //}

        //private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        //{
        //    num6 = (double)numericUpDown6.Value;
        //}
    }
}
