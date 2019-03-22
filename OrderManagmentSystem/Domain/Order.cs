using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderManagmentSystem.Domain
{
    public class Order
    {
        [Required]
        public string ClientId { get; private set; }
        public long RequestId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        // For some mappers default constructor is required.
        protected Order()
        { 
        }

        public Order(string clientId, long requestId, string name, int quantity, double price)
        {
            SetClientId(clientId);
            SetRequestId(requestId);
            SetName(name);
            SetQuantity(quantity);
            SetPrice(price);
        }

        public void SetClientId(string clientId)
        {
            if(string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException("ClientId is required.");
            }
            if(clientId.Contains(" "))
            {
                throw new Exception("ClientId can't contain space.");
            }
            if(clientId.Length > 6)
            {
                throw new Exception("ClientId can't be longer than 6 characters.");
            }
            ClientId = clientId;
        }

        public void SetRequestId(long requestId)
        {
            if(requestId <= 0)
            {
                throw new Exception("RequestId shouldn't be equal or less than 0.");
            }
            RequestId = requestId;
        }

        public void SetName(string name)
        {
            if(name.Length > 255)
            {
                throw new Exception("Name can't be longer than 255 charaters.");
            }
            Name = name;
        }

        public void SetQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new Exception("Quantity can't be equal or less than 0.");
            }
            Quantity = quantity;
        }

        public void SetPrice(double price)
        {
            if(price < 0)
            {
                throw new Exception("Price can't be less than 0.");
            }
            Price = price;
        }
    }
}
