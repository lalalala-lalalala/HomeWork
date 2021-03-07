using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class M_N
    {
        public bool If_is_Toeplize(int [,] mn)
        {
            int min;
            int num = mn[0,0];
            bool b = true;
            if (mn.GetLength(0) > mn.GetLength(1))
            {
                min = mn.GetLength(1);
            }
            else
            {
                min = mn.GetLength(0);
            }
            for(int i = 0; i < min; i++)
            {
                if (mn[i, i] != num)
                {
                    b = false;
                    break;
                }
            }
            return b;
        }
    }
}
