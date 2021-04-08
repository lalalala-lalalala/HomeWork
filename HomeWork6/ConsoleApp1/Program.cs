using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            Console.WriteLine("请输入用户姓名：");
            string name = Console.ReadLine();

            Client client = new Client(name);

            bool again = true;
            while (again)
            {
                Console.WriteLine("选择所用功能");
                Console.WriteLine("1.添加订单");
                Console.WriteLine("2.删除订单");
                Console.WriteLine("3.修改订单");
                Console.WriteLine("4.查询订单");
                Console.WriteLine("5.退出");

                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.WriteLine("请输入订单id：");
                        string id1 = Console.ReadLine();

                        Order order = new Order(id1,client);

                        order.AddOrderDetail();

                        orderService.AddOrder(order);
                        break;

                    case "2":
                        Console.WriteLine("请输入订单id：");
                        string id2 = Console.ReadLine();

                        orderService.DeleteOrder(id2);
                        break;

                    case "3":
                        Console.WriteLine("请输入订单id：");
                        string id3 = Console.ReadLine();

                        orderService.ChangeOrder(id3);
                        break;

                    case "4":
                        Console.WriteLine("请输入订单id：");
                        string id4 = Console.ReadLine();

                        orderService.SeletOrder(id4);
                        break;
                    case "5":
                        again = false;
                        break;

                    default:
                        Console.WriteLine("无效的输入. 请选择1-5的数字");
                        break;
                }
            }
        }
    }

    [Serializable]
    public class Order
    {
        string id;
        int price = 0;
        Client C;
        List<OrderDetails> O = new List<OrderDetails>();
        public Order(string id,Client C)
        {
            this.id = id;
            this.C = C;
        }
        public string GetID()
        {
            return id;
        }
        public int GetPrice()
        {
            return price;
        }
        public Client GetClient()
        {
            return C;
        }
        public void AddOrderDetail()
        {
            Item item0 = new Item("错误", "000000", 0);
            Item item1 = new Item("钢笔", "010101", 10);
            Item item2 = new Item("笔记本", "010102", 8);
            Item item3 = new Item("签字笔", "010103", 5);
            Item item4 = new Item("笔芯", "010104", 2);

            Console.WriteLine("请输入订单id：");
            string id = Console.ReadLine();

            Console.WriteLine("选择物品种类");
            Console.WriteLine(item1);
            Console.WriteLine(item2);
            Console.WriteLine(item3);
            Console.WriteLine(item4);

            Console.WriteLine("请选择数量：");
            string number = Console.ReadLine();
            int num = int.Parse(number);

            OrderDetails orderDetails;

            string a = Console.ReadLine();
            switch (a)
            {
                case "1":
                    orderDetails = new OrderDetails(id, item1, num);
                    break;

                case "2":
                    orderDetails = new OrderDetails(id, item2, num);
                    break;

                case "3":
                    orderDetails = new OrderDetails(id, item3, num);
                    break;

                case "4":
                    orderDetails = new OrderDetails(id, item4, num);
                    break;

                default:
                    orderDetails = new OrderDetails(id, item0, num);
                    Console.WriteLine("无效的输入. 请选择1-4的数字");
                    break;
            }

            bool b = true;
            foreach (OrderDetails orderDetails1 in this.O)
            {
                if (orderDetails1.Equals(orderDetails))
                {
                    b = false;
                }
            }
            if (b)
            {
                this.O.Add(orderDetails);
                this.price = this.price + orderDetails.GetPrice();
            }
        }
        public void DeleteOrderDetail()
        {
            Console.WriteLine("请输入订单id：");
            string id = Console.ReadLine();

            foreach (OrderDetails orders in this.O)
            {
                if (orders.GetID() == id)
                {
                    if (!O.Remove(orders))
                    {
                        //抛出异常
                    }
                }
            }
        }
        public override string ToString()
        {
            string str = "订单号：" + id + "客户信息：" + this.C + "订单总金额：" + price + "订单详情：";
            foreach(OrderDetails O in this.O)
            {
                str = str + O.ToString();
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            Order a = obj as Order;
            return this.id == a.id;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(id);
        }
    }

    [Serializable]
    public class OrderDetails
    {
        string id;
        Item Item;
        int number;
        int price;

        public OrderDetails(string id,Item Item,int number)
        {
            this.id = id;
            this.Item = Item;
            this.number = number;
            this.price = Item.GetIIPrice() * this.number;
        }
        public int GetPrice()
        {
            return price;
        }
        public string GetID()
        {
            return id;
        }
        public int GetNumber()
        {
            return number;
        }
        public string GetItem()
        {
            return Item.ToString();
        }
        public override string ToString()
        {
            return "订单详情的单号：" + id + "货物信息：" + Item.ToString() + "物品数量：" + number + "订单价格：" + price;
        }
        public override bool Equals(object obj)
        {
            OrderDetails a = obj as OrderDetails;
            return this.id == a.id;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(id);
        }
    }

    [Serializable]
    public class Client
    {
        string cName;

        public Client(string cName)
        {
            this.cName = cName;
        }
        public string GetCName()
        {
            return cName;
        }
        public override string ToString()
        {
            return "客户：" + cName;
        }
    }

    [Serializable]
    public class Item
    {
        private string iName;
        string iId;
        int iPrice;

        public Item(string iName,string iId,int iPrice)
        {
            this.iName = iName;
            this.iId = iId;
            this.iPrice = iPrice;
        }
        public string GetIName()
        {
            return iName;
        }
        public string GetIId()
        {
            return iId;
        }
        public int GetIIPrice()
        {
            return iPrice;
        }
        public override string ToString()
        {
            return "名字：" + iName + "货号：" + iId + "价格：" + iPrice;
        }
    }


    public class OrderService
    {
        List<Order> Order = new List<Order>();

        public void DeleteOrder(string s)
        {
            foreach(Order orders in this.Order)
            {
                if (orders.GetID() == s)
                {
                    if (!Order.Remove(orders))
                    {
                        //抛出异常
                    }
                }
            }
        }

        public void DeleteOrder(Client client)
        {
            foreach (Order orders in this.Order)
            {
                if (orders.GetClient().Equals(client))
                {
                    if (!Order.Remove(orders))
                    {
                        //抛出异常
                    }
                }
            }
        }

        public void AddOrder(Order Order)
        {
            bool b = true;
            foreach (Order order1 in this.Order)
            {
                if (order1.Equals(Order))
                {
                    b = false;
                }
            }
            if (b)
            {
                this.Order.Add(Order);
            }
        }

        public void ChangeOrder(string s)
        {
            var order1 = from n in Order
                         where n.GetID() == s
                         select n;


                if (order1 != null)
                {
                    foreach (Order orders in order1)
                    {
                        Console.WriteLine("选择所用功能");
                        Console.WriteLine("1.添加订单");
                        Console.WriteLine("2.删除订单");

                        string a = Console.ReadLine();
                        switch (a)
                        {
                            case "1":
                                orders.AddOrderDetail();
                                break;

                            case "2":
                                orders.DeleteOrderDetail();
                                break;
                            default:
                                Console.WriteLine("无效的输入. 请选择1-4的数字");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("不存在该订单");
                }

        }

        public void SeletOrder(string s)
        {
            var order1 = from n in Order
                          where n.GetID() == s
                          select n;

            if (order1 != null)
            {
                foreach (var x in order1)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine("不存在该订单");
            }
        }

        public void SeletOrder(Client client)
        {
            var order1 = from n in Order
                         where n.GetClient().GetCName() == client.GetCName()
                         select n;

            if (order1 != null)
            {
                foreach (var x in order1)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine("不存在该订单");
            }
        }

        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));

            using(FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, this.Order);
            }
        }

        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order[]));

            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                Order[] order = (Order[])xmlSerializer.Deserialize(fs);

                Array.ForEach(order, o => Console.WriteLine(o));
            }
        }
    }
}
