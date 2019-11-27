using Layers.Models.Models;
using Layers.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderAPI.Controllers;
using System;
using System.Collections.Generic;

namespace Layers.UnitTests
{
    [TestClass]
    public class OrdersAPIUnitTests
    {
        [TestMethod]
        public void TestOrders_ReturnOrder()
        {
            IOrder orderRepo = new OrdersTestRepository();
            OrdersController ordersAPI = new OrdersController(orderRepo);

            var expected = new Order();
            expected.CustomerID = "abc";
            expected.Id = 1;
        

            var taskReturn = ordersAPI.GetOrder(1, "abc");
            taskReturn.Wait();
            var result = taskReturn.Result.Value;


            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.CustomerID, result.CustomerID);
            
        }

        //[TestMethod]
        //public void TestOrders_ReturnListOfOrders()
        //{
        //    IOrder orderRepo = new OrdersTestRepository();
        //    OrdersController ordersAPI = new OrdersController(orderRepo);

        //    List<Order> expectedOrders = new List<Order>()
        //{
        //    new Order
        //    {
        //        Id = 1,
        //        CustomerID = "abc",
        //        OrderDate = DateTime.Now,
        //        Total = 1.5m
        //    },
         
        //        new Order
        //    {
        //        Id = 3,
        //        CustomerID = "abc",
        //        OrderDate = DateTime.Now,
        //        Total = 10.5m
        //    },
        //};

        //    var taskReturn = ordersAPI.GetOrders("abc");
        //    taskReturn.Wait();
        //    var result = taskReturn.Result;

        //    Assert.AreEqual(2, result);
            
        //}
        //[TestMethod]
        //public void TestOrders_CreateOrder()
        //{
        //    IOrder orderRepo = new OrdersTestRepository();
        //    OrdersController ordersAPI = new OrdersController(orderRepo);

        //    var expected = new Order();
        //    expected.CustomerID = "abc";
        //    expected.Id = 1;
        //    expected.OrderDate = DateTime.Now;
        //    expected.Total = 1.5m;

        //    var taskReturn = ordersAPI.PostOrder(expected); 
        //    taskReturn.Wait();
        //    var result = taskReturn.Result.Value;

        //    Assert.AreEqual(expected.Id, result.Id);


        ////}
    }
}
