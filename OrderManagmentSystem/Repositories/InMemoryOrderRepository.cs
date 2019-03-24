using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderManagmentSystem.Domain;

namespace OrderManagmentSystem.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        public ISet<Order> _orders = new HashSet<Order>();
 
        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public Order Get(string clientId)
            => _orders.SingleOrDefault(x => x.ClientId == clientId);

        public IEnumerable<Order> GetAll()
            => _orders;

        public void Remove(string orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
