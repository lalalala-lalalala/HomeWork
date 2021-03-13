using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public interface Shape
    {
        double Area();
    }


    class Rectangle : Shape
    {
        private int l;
        private int w;
        public Rectangle(int l, int w)
        {
            this.l = l;
            this.w = w;
        }
        public double Area()
        {
            if (l > 0 && w > 0)
            {
                return l * w;
            }
            else
            {
                Console.WriteLine("输入错误，无法构成长方形。");
                return 0;
            }
        }
    }

    class Square : Shape
    {
        private int side;
        public Square(int side)
        {
            this.side = side;
        }
        public double Area()
        {
            if (side > 0)
            {
                return side * side;
            }
            else
            {
                Console.WriteLine("输入错误，无法构成正方形。");
                return 0;
            }
        }
    }

    class Trigon : Shape
    {
        private int a;
        private int b;
        private int c;
        public Trigon(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double Area()
        {
            if (a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0)
            {
                float p = (a + b + c) / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                return s;
            }
            else
            {
                Console.WriteLine("输入错误，无法构成三角形。");
                return 0;
            }
        }
    }

    class ShapeFactory
    {
        public static Shape GetShape(string type,int length,int width,int height)
        {
            if ("长方形".Equals(type))
            {
                return new Rectangle(length, width);
            }
            else
            {
                if ("正方形".Equals(type))
                {
                    return new Square(length);
                }
                else
                {
                    if ("三角形".Equals(type)){
                        return new Trigon(length, width, height);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}