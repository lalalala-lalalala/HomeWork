using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int max;
            int[] t = new int[101];
            for (int i = 0; i <= 100; i++)
            {
                t[i] = i;
            }
            max = 100;
            for (int i = 2; i*i < 100; i++)
            {
                for (int j = 100; j > i; j--)
                {
                    /*if (i * i > max)
                    {
                        break;
                    }*/
                    if (t[j] % i==0)
                    {
                        t[j] = 0;
                        max = t[j - 1];
                    }
                }
            }
            for (int i = 2; i <= 100; i++)
            {
                if (t[i] != 0)
                {
                    Console.WriteLine(t[i]);
                }
            }
        }
    }
}
