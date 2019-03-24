using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using OrderManagmentSystem.Domain;
using OrderManagmentSystem.Repositories;
using Moq;
using OrderManagmentSystem.Services;

namespace Tests.Services
{
    [TestFixture]
    public class OrderRaportsTest
    {
        public OrderRaports orderRaports;

        public OrderRaportsTest()
        {
            var listOfOrders = new List<Order>();
            listOfOrders.Add(new Order("1", 1, "Bułka", 1, 10.0));
            listOfOrders.Add(new Order("1", 2, "Chleb", 2, 15.0));
            listOfOrders.Add(new Order("1", 2, "Chleb", 5, 15.0));
            listOfOrders.Add(new Order("2", 1, "Chleb", 1, 10.0));

            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(x => x.GetAll()).Returns(listOfOrders);
            orderRaports = new OrderRaports(mockOrderRepository.Object);
        }

        [Test]
        public void GetOrderAmountTest()
        {
            orderRaports.GetOrderAmount().Should().Be(4);
        }

        [Test]
        public void GetOrderAmountPerClientTest()
        {
            orderRaports.GetOrderAmountPerClient("1").Should().Be(3);
        }

        [Test]
        public void GetTotalPriceOfOrdersTest()
        {
            orderRaports.GetTotalPriceOfOrders().Should().Be(125.0);
        }

        [Test]
        public void GetTotalPriceOfOrdersPerClientTest()
        {
            orderRaports.GetTotalPriceOfOrdersPerClient("1").Should().Be(115.0);
        }

        [Test]
        public void GetTotalListOfOrdersTest()
        {
            var TestListOfOrders = new List<Order>();
            TestListOfOrders.Add(new Order("1", 1, "Bułka", 1, 10.0));
            TestListOfOrders.Add(new Order("1", 2, "Chleb", 2, 15.0));
            TestListOfOrders.Add(new Order("1", 2, "Chleb", 5, 15.0));
            TestListOfOrders.Add(new Order("2", 1, "Chleb", 1, 10.0));

            orderRaports.GetTotalListOfOrders().Should().BeEquivalentTo(TestListOfOrders);
        }

        [Test]
        public void GetTotalListOfOrdersPerClientTest()
        {
            var TestListOfOrders = new List<Order>();
            TestListOfOrders.Add(new Order("1", 1, "Bułka", 1, 10.0));
            TestListOfOrders.Add(new Order("1", 2, "Chleb", 2, 15.0));
            TestListOfOrders.Add(new Order("1", 2, "Chleb", 5, 15.0));

            orderRaports.GetTotalListOfOrdersPerClient("1").Should().BeEquivalentTo(TestListOfOrders);
        }

        //[Test]
        //public void GetAverageValueOfOrderTest()
        //{
        //    orderRaports.GetAverageValueOfOrder().Should().Be
        //}

        //[Test]
        //public void GetAverageValueOfOrderPerClientTest()
        //{
        //    orderRaports.GetAverageValueOfOrderPerClient().Should().Be
        //}

        [Test]
        public void GetAmountOfOrdersGroupedByNameTest()
        {
            var groupedList = new Dictionary<string, int>();
            groupedList.Add("Bułka", 1);
            groupedList.Add("Chleb", 3);
            orderRaports.GetAmountOfOrdersGroupedByName().Should().BeEquivalentTo(groupedList);
        }

        [Test]
        public void GetAmountOfOrdersGroupedByNamePerClientTest()
        {
            var groupedList = new Dictionary<string, int>();
            groupedList.Add("Bułka", 1);
            groupedList.Add("Chleb", 2);
            orderRaports.GetAmountOfOrdersGroupedByNamePerClient("1").Should().BeEquivalentTo(groupedList);
        }

        [Test]
        public void GetOrdersInPriceRangeTest()
        {
            var TestListOfOrders = new List<Order>();
            TestListOfOrders.Add(new Order("1", 1, "Bułka", 1, 10.0));;
            TestListOfOrders.Add(new Order("2", 1, "Chleb", 1, 10.0));

            orderRaports.GetOrdersInPriceRange(10.0, 14.0).Should().BeEquivalentTo(TestListOfOrders);
        }
    }
}
