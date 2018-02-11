using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ContractService
{
    public class Service : IService
    {
        public List<OrderWithStatus> GetOrders()
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var orders = db.Orders.ToList();

            var result = new List<OrderWithStatus>();
            foreach (var order in orders)
            {
                result.Add(new OrderWithStatus
                {
                    Order = order,
                    OrderStatus = GetOrderStatus(order)
                });
            }

            return result;
        }

        public FullOrderInfo GetInfo(int orderId)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var order = db.Orders.FirstOrDefault(ord => ord.OrderID == orderId);
            if (order == null)
                throw new ArgumentException();

            return new FullOrderInfo
            {
                Order = order,
                OrderDetails = order.Order_Details.First(),
                OrderProducts = order.Order_Details.Select(details => details.Product).ToList()
            };
        }

        public void AddOrder(FullOrderInfo orderInfo)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            db.Orders.InsertOnSubmit(orderInfo.Order);
            db.Order_Details.InsertOnSubmit(orderInfo.OrderDetails);
            db.Products.InsertAllOnSubmit(orderInfo.OrderProducts);
            db.SubmitChanges();
        }

        public void ChangeOrder(Order newOrder)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var order = db.Orders.First(ord => ord.OrderID == newOrder.OrderID);
            if (order == null)
                throw new ArgumentException();

            var status = GetOrderStatus(order);
            if (status == OrderStatusType.InProgress || status == OrderStatusType.Finished)
                return;

            var orderDate = order.OrderDate;
            var shippedDate = order.ShippedDate;

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, Order>();
            });
            AutoMapper.IMapper mapper = config.CreateMapper();
            AutoMapper.Mapper.Map<Order, Order>(newOrder, order);

            order.OrderDate = orderDate;
            order.ShippedDate = shippedDate;
            db.SubmitChanges();
        }

        public void RemoveOrder(int orderId)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var order = db.Orders.First(ord => ord.OrderID == orderId);
            var status = GetOrderStatus(order);
            if (status == OrderStatusType.Finished)
                return;

            db.Orders.DeleteOnSubmit(order);
            db.SubmitChanges();
        }

        public void StartShipping(int orderId)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var order = db.Orders.First(ord => ord.OrderID == orderId);
            var status = GetOrderStatus(order);

            if (status == OrderStatusType.New)
                order.OrderDate = DateTime.Now;

            db.SubmitChanges();
        }

        public void EndShipping(int orderId)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var order = db.Orders.First(ord => ord.OrderID == orderId);
            var status = GetOrderStatus(order);

            if (status == OrderStatusType.InProgress)
                order.ShippedDate = DateTime.Now;

            db.SubmitChanges();
        }

        private OrderStatusType GetOrderStatus(Order order)
        {
            OrderStatusType status = 0;
            if (order.OrderDate == null) status = OrderStatusType.New;
            if (order.ShippedDate == null) status = OrderStatusType.InProgress;
            if (order.ShippedDate != null) status = OrderStatusType.Finished;
            return status;
        }
    }
}
