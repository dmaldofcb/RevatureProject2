using Layers.Models.Models;
using Layers.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderAPI.Controllers;

namespace Layers.UnitTests
{
    [TestClass]
    public class PizzaAPIUnitTests
    {
        [TestMethod]
        public void TestPizzaPie_ReturnsSize()
        {
            #region ASSIGN
            IPizza pizzaRepo = new PizzaPieTestRepository();
            ISize sizeRepo = new SizeTestRepository();
            ICrust crustRepo = new CrustTestRepository();
            IToppings toppingsRepo = new ToppingsTestRepository();
            IPizzaToppings pizzaToppings = new PizzaToppingsTestRepository();

            PizzaAPIController controller = new PizzaAPIController(pizzaRepo, sizeRepo, toppingsRepo, crustRepo, pizzaToppings);

            #endregion

            #region ACT
           
            var expected = new Size();
            expected.Type = "small";
            expected.Price = 20;
            expected.Id = 1;

            var taskReturn = controller.GetSize(1);
            taskReturn.Wait();
            var result = taskReturn.Result;


            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Type, result.Type);
            Assert.AreEqual(expected.Price, result.Price);

            #endregion
        }

        [TestMethod]
        public void TestPizzaPie_NoReturnSize()
        {
            #region ASSIGN
            IPizza pizzaRepo = new PizzaPieTestRepository();
            ISize sizeRepo = new SizeTestRepository();
            ICrust crustRepo = new CrustTestRepository();
            IToppings toppingsRepo = new ToppingsTestRepository();
            IPizzaToppings pizzaToppings = new PizzaToppingsTestRepository();

            PizzaAPIController controller = new PizzaAPIController(pizzaRepo, sizeRepo, toppingsRepo, crustRepo, pizzaToppings);

            #endregion

            #region ACT



            var taskReturn = controller.GetSize(5);
            taskReturn.Wait();
            var result = taskReturn.Result;


            Assert.IsNull(result);
            //Assert.AreEqual((result as NotFoundObjectResult).StatusCode, 404);
            #endregion
        }

        [TestMethod]
        public void TestPizzaPie_ReturnsCrust()
        {
            #region ASSIGN
            IPizza pizzaRepo = new PizzaPieTestRepository();
            ISize sizeRepo = new SizeTestRepository();
            ICrust crustRepo = new CrustTestRepository();
            IToppings toppingsRepo = new ToppingsTestRepository();
            IPizzaToppings pizzaToppings = new PizzaToppingsTestRepository();

            PizzaAPIController controller = new PizzaAPIController(pizzaRepo, sizeRepo, toppingsRepo, crustRepo, pizzaToppings);

            #endregion

            #region ACT

            var expected = new Crust();
            expected.Type = "Thick Crust";
            expected.Price = 10;
            expected.Id = 2;

            var taskReturn = controller.GetCrust(2);
            taskReturn.Wait();
            var result = taskReturn.Result;



            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Type, result.Type);
            Assert.AreEqual(expected.Price, result.Price);
            #endregion
        }
    }
}
