using System;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            String str;
            int num;
            str = Console.ReadLine();
            num = int.Parse(str);
            int t = num;
            int i, j = 0;
            for (i = 2; i <= Math.Abs(num); i++)
            {
                int k = (int)Math.Sqrt(i);
                for (j = 2; j <= k; j++)
                {
                    if ((i % j) == 0)
                    {
                        break;
                    }
                }

                if (j > k)
                {
                    if (num % i == 0)
                    {
                        Console.Write(i.ToString() + "   ");
                    }
                }
            }
        }
    }
}
