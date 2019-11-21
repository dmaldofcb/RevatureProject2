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
using System.Security.Claims;

namespace PizzaOrder.Controllers
{
    public class OrdersDetailsController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            List<OrderDetails> reservationList = new List<OrderDetails>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:51600/api/OrderDetails/GetOrdersByOrderId/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<OrderDetails>>(apiResponse);
                }
            }
            return View(reservationList);
        }
    }
}