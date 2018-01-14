using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Impl;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace nhibertest
{
    //====================================================================================

    public class Customer
    {
        public string Name { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
    }

    public class Order
    {
        public int Quantity { get; set; }
    }

    //====================================================================================

    public class CustomerDao : EntityBase<CustomerDao>
    {
        public virtual string Name { get; set; }
        public virtual IList<OrderDao> Orders { get; set; } = new List<OrderDao>();
    }

    public class OrderDao : EntityBase<OrderDao>
    {
        public virtual CustomerDao Customer { get; set; }
        public virtual int Quantity { get; set; }
    }

    //====================================================================================

    public class CustomerDaoMapping : ClassMapping<CustomerDao>
    {
        public CustomerDaoMapping()
        {
            Schema("dbo");
            Table("ta_customers");
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.Name, map => map.Length(255));
            Bag(x => x.Orders,
                colmap =>
                {
                    colmap.Key(x => x.Column("customer_id"));
                    colmap.Inverse(true);
                    colmap.Cascade(Cascade.All.Include(Cascade.DeleteOrphans));
                },
                map => { map.OneToMany(); });
        }
    }

    public class OrderDaoMapping : ClassMapping<OrderDao>
    {
        public OrderDaoMapping()
        {
            Schema("dbo");
            Table("ta_orders");
            Id(x => x.Id, map => map.Generator(Generators.Identity));
            Property(x => x.Quantity, map => map.Precision(10));
            ManyToOne(x => x.Customer,
                      map =>
                      {
                          map.Column("customer_id");
                          map.NotNullable(true);
                      });
        }
    }

    //====================================================================================

    public class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new MsSqlConfiguration(@"Server=virgo\SQLEXPRESS;Database=testDB;Trusted_Connection=True;");
            cfg = cfg.CurrentSessionContext<ThreadStaticSessionContext>();

            var mapper = new EntityMappings(cfg);
            mapper.AddMappings(typeof(CustomerDaoMapping));
            mapper.AddMappings(typeof(OrderDaoMapping));
            mapper.CompileMappings();

            ISessionFactory sfact = cfg.BuildSessionFactory();

            //CurrentSessionContextBinder currentSessionCtxBinder = new CurrentSessionContextBinder();
            //ISession boundSession = currentSessionCtxBinder.Bind(sfact);

            var se = new SchemaExporter(cfg);
            se.ToConsole();

            using (ISession session = sfact.OpenSession())
            using (UnitOfWork uow = new UnitOfWork(session))
            {
                CustomerDao cust = new CustomerDao();
                cust.Name = "toto";

                var order = new OrderDao();
                order.Quantity = 100;
                order.Customer = cust;

                cust.Orders.Add(order);

                session.SaveOrUpdate(cust);
                //session.Save(order);
                uow.Commit();
            }

            //currentSessionCtxBinder.Unbind(sfact);
            //session = currentSessionCtxBinder.Bind(sfact);

            using (ISession session = sfact.OpenSession())
            using (UnitOfWork uow = new UnitOfWork(session))
            {
                CustomerDao cust = session.Get<CustomerDao>(14L);
                cust.Name = "zorro";

                var order = new OrderDao();
                order.Quantity = 250;
                order.Customer = cust;

                cust.Orders.Add(order);
                //cust.Orders.Clear();

                session.SaveOrUpdate(cust);
                uow.Commit();
            }

            Console.WriteLine();
            Console.Write("Hit ENTER to exit:");
            Console.ReadLine();
        }
    }
}
