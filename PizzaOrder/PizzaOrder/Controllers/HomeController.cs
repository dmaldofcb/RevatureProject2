using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrder.Models;
//Raymond's Test Comment
namespace PizzaOrder.Controllers
{
    //new commit 2:58pm
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //Jakes first Commit
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Logans commit
            return View();
        }

        public IActionResult Privacy()
        {
            //comment
            //comment
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //logans second comment
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//Raymond's second test commit