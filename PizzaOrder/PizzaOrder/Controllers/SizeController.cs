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
    public class SizeController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            List<Size> sizeList = new List<Size>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Size/Get/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sizeList = JsonConvert.DeserializeObject<List<Size>>(apiResponse);
                }
            }
            return View(sizeList);
        }
    }
}