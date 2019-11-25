using Layers.Models.Models;
using Layers.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderAPI.Controllers;

namespace Layers.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPizzaPie_ReturnsPizza()
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

        //public void TestCustomerDetails_ReturnsCustomer()
        //{
        //    // Arrange.

        //    ICustomerRepository repo = new CustomerTestRepository();

        //    CustomersController controller = new CustomersController(repo);

        //    var expected = "John";

        //    // Act.

        //    var result = controller.Details(102);

        //    var fname = ((Customer)(result.Result as ViewResult).Model).Firstname;

        //    // Assert.

        //    Assert.AreEqual(expected, fname);

        //}
    }
}
