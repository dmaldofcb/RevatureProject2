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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PizzaOrder.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Order> reservationList = new List<Order>();
            using (var httpClient = new HttpClient())
            {
                // using (var response = await httpClient.GetAsync("http://localhost:51600/api/Orders/GetOrders/" + user))
                using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                }
            }
            return View(reservationList);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}