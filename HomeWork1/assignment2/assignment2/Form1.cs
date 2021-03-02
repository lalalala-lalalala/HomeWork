using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float a, b, c;
            a = float.Parse(textBox1.Text);
            b = float.Parse(textBox3.Text);
            char t;
            t = char.Parse(textBox2.Text);
            switch (t)
            {
                default:
                    Console.WriteLine("请输入正确的运算符");
                    break;
                case '+':
                    c = a + b;
                    string s = c.ToString("0.00");
                    textBox4.Text = s;
                    break;
                case '-':
                    c = a - b;
                    s = c.ToString("0.00");
                    textBox4.Text = s;
                    break;
                case '*':
                    c = a * b;
                    s = c.ToString("0.00");
                    textBox4.Text = s;
                    break;
                case '/':
                    if (b == 0)
                    {
                        textBox4.Text = "分母为0计算错误";
                        break;
                    }
                    c = a / b;
                    s = c.ToString("0.00");
                    textBox4.Text = s;
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
