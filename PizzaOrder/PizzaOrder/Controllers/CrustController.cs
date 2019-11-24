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
    public class CrustController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            List<Crust> crustList = new List<Crust>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Crust/Get/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    crustList = JsonConvert.DeserializeObject<List<Crust>>(apiResponse);
                }
            }
            return View(crustList);
        }
    }
}