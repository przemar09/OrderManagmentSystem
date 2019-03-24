using OrderManagmentSystem.Domain;
using OrderManagmentSystem.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagmentSystem.Services
{
    public class OrderRaports
    {
        private readonly IOrderRepository _orderRepository;

        public OrderRaports(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int GetOrderAmount()
            => _orderRepository.GetAll().Count();

        public int GetOrderAmountPerClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException("ClientId can't be null");
            }
            if (clientId.Contains(" "))
            {
                throw new Exception("ClientId can't contain space.");
            }
            if (clientId.Length > 6)
            {
                throw new Exception("ClientId can't be longer than 6 characters.");
            }

            return _orderRepository.GetAll().Where(x => x.ClientId == clientId).Count();
        }

        public object GetTotalPriceOfOrders()
        {
            double totalPrice = 0;
            foreach (var order in _orderRepository.GetAll())
            {
                totalPrice += order.Quantity * order.Price;
            }
            return totalPrice;
        }

        public object GetTotalPriceOfOrdersPerClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException("ClientId can't be null");
            }
            if (clientId.Contains(" "))
            {
                throw new Exception("ClientId can't contain space.");
            }
            if (clientId.Length > 6)
            {
                throw new Exception("ClientId can't be longer than 6 characters.");
            }

            double totalPrice = 0;
            foreach (var order in _orderRepository.GetAll().Where(x => x.ClientId == clientId))
            {
                totalPrice += order.Quantity * order.Price;
            }
            return totalPrice;
        }

        public IList<Order> GetTotalListOfOrders()
            => _orderRepository.GetAll().ToList();

        public object GetTotalListOfOrdersPerClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException("ClientId can't be null");
            }
            if (clientId.Contains(" "))
            {
                throw new Exception("ClientId can't contain space.");
            }
            if (clientId.Length > 6)
            {
                throw new Exception("ClientId can't be longer than 6 characters.");
            }

            return _orderRepository.GetAll().Where(x => x.ClientId == clientId).ToList();
        }

        public object GetAverageValueOfOrderPerClient()
        {
            throw new NotImplementedException();
        }

        public void GetAverageValueOfOrder()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, int> GetAmountOfOrdersGroupedByName()
        {
            var groupedList = new ConcurrentDictionary<string, int>();
            foreach(var order in _orderRepository.GetAll())
            {
                groupedList.AddOrUpdate(order.Name, 1, (k, v) => v +1);
            }
            return groupedList;
        }

        public IDictionary<string, int> GetAmountOfOrdersGroupedByNamePerClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException("ClientId can't be null");
            }
            if (clientId.Contains(" "))
            {
                throw new Exception("ClientId can't contain space.");
            }
            if (clientId.Length > 6)
            {
                throw new Exception("ClientId can't be longer than 6 characters.");
            }

            var groupedList = new ConcurrentDictionary<string, int>();
            foreach (var order in _orderRepository.GetAll().Where(x => x.ClientId == clientId))
            {
                groupedList.AddOrUpdate(order.Name, 1, (k, v) => v + 1);
            }
            return groupedList;
        }

        public IList<Order> GetOrdersInPriceRange(double minPrice, double maxPrice)
            => _orderRepository.GetAll().Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
    }
}
