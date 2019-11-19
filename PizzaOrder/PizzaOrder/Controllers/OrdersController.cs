using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Layers.Models.Models;
using PizzaOrder.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PizzaOrder.Controllers
{
    public class OrdersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Order> reservationList = new List<Order>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:59293/api/Orders"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                }
            }
            return View(reservationList);
        }
    }
}