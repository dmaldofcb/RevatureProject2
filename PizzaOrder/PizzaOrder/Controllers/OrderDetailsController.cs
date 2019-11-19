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
    public class OrdersDetailsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<OrderDetails> reservationList = new List<OrderDetails>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:59293/api/OrderDetails"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<OrderDetails>>(apiResponse);
                }
            }
            return View(reservationList);
        }
    }
}