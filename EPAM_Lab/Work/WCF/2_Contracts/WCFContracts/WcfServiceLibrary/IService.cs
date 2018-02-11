using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<OrderWithStatus> GetOrders();

        [OperationContract]
        FullOrderInfo GetInfo(int orderId);

        [OperationContract]
        void AddOrder(FullOrderInfo orderInfo);
        
        [OperationContract]
        void ChangeOrder(Order newOrder);

        [OperationContract]
        void RemoveOrder(int orderId);

        [OperationContract]
        void StartShipping(int orderId);

        [OperationContract]
        void EndShipping(int orderId);
    }

    [DataContract]
    public class OrderWithStatus
    {
        [DataMember]
        public Order Order { get; set; }

        [DataMember]
        public OrderStatusType OrderStatus { get; set; }
    }

    [DataContract]
    public class FullOrderInfo
    {
        [DataMember]
        public Order Order { get; set; }

        [DataMember]
        public Order_Detail OrderDetails { get; set; }

        [DataMember]
        public List<Product> OrderProducts { get; set; }
    }

    public enum OrderStatusType
    {
        New,
        InProgress,
        Finished
    }
}
