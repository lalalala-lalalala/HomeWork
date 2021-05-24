using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Data.Entity;
using OrderManagement;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    public static class OrderService
    {
        public static List<Order> orders { get; set; }

        //public OrderService() { }

        //public static OrderService(List<Order> ods)
        //{
        //    orders = ods;
        //}

        public static List<Order> GetAllOrders()
        {
            using (var db = new OrderContext())
            {
                return db.Orders.Include(o => o.Items.Select(i => i.Prodc)).Include("Client").ToList();
            }
        }

        public static void AddOrder(Order od)
        {
            //if (!orders.Contains(od))
            //{

                using (var db = new OrderContext())
                {
                    db.Orders.Add(od);
                    db.SaveChanges();
                }
                return;
            //}
            Exception e = new Exception("不能添加重复项！");
            throw e;

        }
        public static void DeleteOrder(string id)
        {
            //if (orders.Contains(od))
            //{
            //orders.Remove(od);
            //return;
            //}
            using (var db = new OrderContext())
            {
                var order = db.Orders.Include("Items").Where(o => o.OrderId == id).FirstOrDefault();
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            Exception e = new Exception("表单中无此项！");
            throw e;
        }


        public static void ChangeOrder(Order od,Client client)
        {
            int index = orders.IndexOf(od);
            od.Client = client;
            orders[index].Client = client;
        }
        public static void ChangeOrder(Order od,string addr)
        {
            int index = orders.IndexOf(od);
            od.Address = addr;
            orders[index].Address = addr;
        }
        public static void ChangeOrder(Order od,List<OrderItem> li)
        {
            int index = orders.IndexOf(od);
            od.Items = li;
            orders[index].Items = li;
        }

        public static IEnumerable<Order> SearchOrder(int opt,string info)
        {
            switch (opt)
            {
                case 1: //订单号查询
                    var query1 = from od1 in orders where od1.OrderId == info
                                 orderby od1.TotalPrice
                                 select od1;
                    return query1;
                case 2: //商品名称查询
                    var query2 = from od2 in orders
                                 from items in od2.Items
                                 where items.Prodc.Name == info
                                 select od2;
                    return query2;
                case 3: //客户查询
                    var query3 = from od3 in orders where od3.Client.ToString() == info
                                 orderby od3.TotalPrice
                                 select od3;
                    return query3;
                default:
                    return null;
            }
        }

        //public override string ToString()
        //{
        //    string s = "";
        //    foreach (Order od in orders)
        //    {
        //        s += od + "\r\n";
        //    }
        //    return s;
        //}

        public static void SortOrder()
        {
            orders.Sort();
        }

        public static void SortOrder(Comparison<Order> comp)
        {
            orders.Sort(comp);
        }


        public static void Export(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                xs.Serialize(fs, orders);
            }
        }

        public static void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    orders = (List<Order>)xs.Deserialize(fs);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }

        }

    }
}
