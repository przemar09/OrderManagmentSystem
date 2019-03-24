﻿using OrderManagmentSystem.Domain;
using OrderManagmentSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace OrderManagmentSystem.Services
{
    public class CsvReader
    {
        private readonly IOrderRepository _orderRepository;

        public CsvReader(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Structure of csv file should be constant
        public void ReadCsv(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var firstLine = reader.ReadLine();
                if(firstLine != "Client_Id,Request_id,Name,Quantity,Price")
                {
                    throw new Exception("Incorrect format of first line in .csv file");
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    string clientId = values[0];
                    long requestId = long.Parse(values[1]);
                    string name = values[2];
                    int quantity = int.Parse(values[3]);
                    double price = double.Parse(values[4], CultureInfo.InvariantCulture);

                    Order order = new Order(clientId, requestId, name, quantity, price);
                    _orderRepository.Add(order);
                }
            }
        }

        public void Raport()
        {
            var order = _orderRepository.Get("1");
            Console.WriteLine($"ClientId: {order.ClientId}, Name of product: {order.Name}");
        }
    }
}
