using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            string b;
            b = Console.ReadLine();
            char[] a = b.ToCharArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] >= 48 && a[i] <= 57)
                {
                    continue;
                }
                int first = 0;
                int second = 0;
                for (int j = 0; j < i; j++)
                {
                    first = 10 * first + (a[j] - 48);
                }
                for (int j = i + 1; j < b.Length; j++)
                {
                    second = 10 * second + (a[j] - 48);
                }
                int t;
                int c = a[i];
                switch (c)
                {
                    default:
                        Console.WriteLine("请输入正确的运算符");
                        break;
                    case '+':
                        t = first + second;
                        Console.WriteLine($"{ t}");
                        break;
                    case '-':
                        t = first - second;
                        Console.WriteLine($"{ t}");
                        break;
                    case '*':
                        t = first * second;
                        Console.WriteLine($"{ t}");
                        break;
                    case '/':
                        if (second == 0)
                        {
                            Console.WriteLine("分母为0无结果");
                            break;
                        }
                        t = first / second;
                        Console.WriteLine($"{ t}");
                        break;
                }
            }
        }
    }
}
