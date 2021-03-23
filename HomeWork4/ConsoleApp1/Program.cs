using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for(int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            Action<int> action = delegate (int item)
            {
                Console.WriteLine(item);
            };

            intlist.ForEach(action);
            int max = 0;
            intlist.ForEach(m=> {
                if (m > max)
                {
                    max = m;
                }
            });
            Console.WriteLine($"max={max}");
            int min = int.MaxValue;
            intlist.ForEach(m => {
                if (m < min)
                {
                    min = m;
                }
            });
            Console.WriteLine($"min={min}");
            int sum = 0;
            intlist.ForEach(m => sum += m);
            Console.WriteLine($"sum={sum}");
        }
    }

    public class Node<T>
    {
        public Node<T> Next
        {
            get;
            set;
        }
        public T Data
        {
            get;
            set;
        }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> x = head;
            do
            {
                action(x.Data);
                x = x.Next;
            } while (x != null);
        }
    }
}
