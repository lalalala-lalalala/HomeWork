using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] t = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            max_min_ave_sum(t);
        }
        public static void max_min_ave_sum(int [] t)
        {
            int max = t[0];
            int min = t[0];
            double ave;
            int sum = 0;
            for(int i = 0; i < t.Length; i++)
            {
                if (t[i] > max)
                {
                    max = t[i];
                }
                if (t[i] < min)
                {
                    min = t[i];
                }
                sum = sum + t[i];
            }
            ave = sum / t.Length;
            Console.WriteLine("最大值为："+max);
            Console.WriteLine("最小值为："+min);
            Console.WriteLine("平均值为："+ave);
            Console.WriteLine("和为："+sum);
        }
    }
}
