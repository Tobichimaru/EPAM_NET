using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IStatisticsRepository
    {
        IEnumerable<OrderHistory> GetOrderHistory(string customerId);

        IEnumerable<OrderDetailHistory> GetOrderDetailsHistory(int orderId);
    }
}