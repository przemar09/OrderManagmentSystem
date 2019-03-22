using OrderManagmentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentSystem.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        IEnumerable<Order> GetAll();
        Order Get(string clientId);
        void Remove(string orderId);
        void Update(Order order);
    }
}
