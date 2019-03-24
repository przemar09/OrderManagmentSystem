using Microsoft.Extensions.DependencyInjection;
using OrderManagmentSystem.Domain;
using OrderManagmentSystem.Repositories;
using OrderManagmentSystem.Services;
using System;
using System.Globalization;
using System.IO;

namespace OrderManagmentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOrderRepository, InMemoryOrderRepository>()
                .BuildServiceProvider();
            Console.WriteLine("Hello World!");

            IOrderRepository orderRepository = new InMemoryOrderRepository();
            CsvReader csvReader = new CsvReader(orderRepository);
            OrderRaports ordersRaports = new OrderRaports(orderRepository);
            csvReader.ReadCsv(@"C:\test.csv");
            csvReader.Raport();
            Console.WriteLine(orderRepository.Get("1").Name);
            Console.WriteLine(ordersRaports.GetOrderAmount());
            Console.ReadKey();
        }
    }
}
