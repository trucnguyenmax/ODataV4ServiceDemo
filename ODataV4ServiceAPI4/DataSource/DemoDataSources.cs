using ODataV4ServiceAPI4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataV4ServiceAPI4.DataSource
{
    public class DemoDataSources
    {
        private static DemoDataSources instance = null;
        public static DemoDataSources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DemoDataSources();
                }
                return instance;
            }
        }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        private DemoDataSources()
        {
            Reset();
            Initialize();
        }
        public void Reset()
        {
            this.Customers = new List<Customer>();
            this.Orders = new List<Order>();
        }
        public void Initialize()
        {
            Orders.AddRange(new List<Order>()
            {
                new Order()
                {
                    ID = 1,
                    Name = "Order 0",
                    Price = 1
                },
                new Order()
                {
                    ID = 2,
                    Name = "Order 1",
                    Price = 2
                },
                new Order()
                {
                    ID = 3,
                    Name = "Order 2",
                    Price = 200
                },
                new Order()
                {
                    ID = 4,
                    Name = "Order 3",
                    Price = 900
                }
            });
            Customers.AddRange(new List<Customer>
            {
                new Customer()
                {
                    ID = 1,
                    Name = "Customer 1",
                    Orders = new List<Order>{ Orders[0], Orders[1]}
                },
                new Customer()
                {
                    ID = 2,
                    Name = "Customer 2",
                    Description = "random text",
                    Orders = new List<Order>{ Orders[2], Orders[3]}
                },
                new Customer()
                {
                    ID = 3,
                    Name = "Customer 3",
                    Description = "random text."
                }
            });
        }
    }
}