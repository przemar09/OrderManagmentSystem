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
            CsvReader csvReader = new CsvReader(new InMemoryOrderRepository());
            csvReader.ReadCsv();
            csvReader.Raport();
            Console.ReadKey();
        }
    }
}
