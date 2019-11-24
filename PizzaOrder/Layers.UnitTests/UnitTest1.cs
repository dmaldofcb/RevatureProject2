using Layers.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaOrderAPI.Controllers;

namespace Layers.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IPizza pizzaRepo = new PizzaPieTestRepository();
            ISize sizeRepo = new SizeTestRepository();
            ICrust crustRepo = new CrustTestRepository();
            IToppings toppingsRepo = new ToppingsTestRepository();
            PizzaAPIController controller = new PizzaAPIController(pizzaRepo, sizeRepo, crustRepo, toppingsRepo);


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
