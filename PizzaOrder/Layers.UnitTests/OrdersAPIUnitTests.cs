using Layers.Models.Models;
using Layers.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderAPI.Controllers;
using System;

namespace Layers.UnitTests
{
    //[TestClass]
    //public class OrdersAPIUnitTests
    //{
    //    [TestMethod]
    //    public void TestOrders_ReturnOrder()
    //    {
    //        IOrder orderRepo = new OrdersTestRepository();
    //        OrdersController ordersAPI = new OrdersController(orderRepo);

    //        var expected = new Order();
    //        expected.CustomerID = "abc";
    //        expected.Id = 1;
    //       // expected.OrderDate = DateTime.Now;
    //       // expected.Total = 1.5m;

    //        var taskReturn = ordersAPI.GetOrder(1, "abc");
    //        taskReturn.Wait();
    //        var result = taskReturn.Result.Result;


    //        Assert.IsInstanceOfType(result, typeof(Order));

    //    }
    //}
}
