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
using Layers.Models.ViewModels;

namespace PizzaOrder.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Order> orderList = new List<Order>();
            using (var httpClient = new HttpClient())
            {
                // using (var response = await httpClient.GetAsync("http://localhost:51600/api/Orders/GetOrders/" + user))
                using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    orderList = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                }
            }
            return View(orderList);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> GetOrderDetails(int? id)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            PizzaOrderVM newOrder = new PizzaOrderVM();
            
            
            using (var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                using (var response = await httpClient.GetAsync("http://localhost:51600/api/Orders/GetOrder/" + user + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newOrder.CurrOrder = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }


            using (var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/OrderDetails/GetOrdersByOrderId/" + newOrder.CurrOrder.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newOrder.OrderDetailsList = JsonConvert.DeserializeObject<List<OrderDetails>>(apiResponse);
                }
            }

            //id of all pizza that belong to that order
            if (newOrder.OrderDetailsList.Count == 1)
            {
                using (var httpClient = new HttpClient())
                {
                    //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                    using (var response = await httpClient.GetAsync("http://localhost:51600/api/Pizzaapi/getpizza/" + newOrder.OrderDetailsList[0].PizzaID))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newOrder.PizzaPieList.Add(JsonConvert.DeserializeObject<PizzaPie>(apiResponse));
                    }
                }
                
                using (var httpClient = new HttpClient())
                {
                    //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                    using (var response = await httpClient.GetAsync("http://localhost:51600/api/toppingsapi/GetPizzaToppings/" + newOrder.OrderDetailsList[0].PizzaID))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newOrder.PizzaToppingsList.Add(newOrder.OrderDetailsList[0].PizzaID, JsonConvert.DeserializeObject<List<PizzaToppings>>(apiResponse));
                    }
                }
                
            }
            else
            {
                foreach (var item in newOrder.OrderDetailsList)
                {
                    using (var httpClient = new HttpClient())
                    {
                        //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                        using (var response = await httpClient.GetAsync("http://localhost:51600/api/Pizzaapi/getpizza/" + item.PizzaID))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newOrder.PizzaPieList.Add(JsonConvert.DeserializeObject<PizzaPie>(apiResponse));
                        }
                    }

                    using (var httpClient = new HttpClient())
                    {
                        //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                        using (var response = await httpClient.GetAsync("http://localhost:51600/api/toppingsapi/GetPizzaToppings/" + item.PizzaID))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newOrder.PizzaToppingsList.Add(item.PizzaID, JsonConvert.DeserializeObject<List<PizzaToppings>>(apiResponse));
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, List<PizzaToppings>> piePizza in newOrder.PizzaToppingsList)
            {
                int pizzapieId = piePizza.Key;
                List<PizzaToppings> list = piePizza.Value;
                //Console.WriteLine("Key = {0}, contains {1} values:", key, list.Count);
                foreach (var itemTopping in list)
                {
                    using (var httpClient = new HttpClient())
                    {
                        //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                        using (var response = await httpClient.GetAsync("http://localhost:51600/api/ToppingsAPI/" + itemTopping.ToppingsID))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //newOrder.ToppingsList.Add(pizzapieId, JsonConvert.DeserializeObject<List<Toppings>>(apiResponse));
                            if (newOrder.ToppingsList.ContainsKey(pizzapieId))
                            {
                                newOrder.ToppingsList[pizzapieId].Add(JsonConvert.DeserializeObject<Toppings>(apiResponse));

                            }
                            else
                            {
                                newOrder.ToppingsList.Add(pizzapieId, new List<Toppings> { JsonConvert.DeserializeObject<Toppings>(apiResponse) });
                            }
                        }
                    }
                }
            }

            using (var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                using (var response = await httpClient.GetAsync(" http://localhost:51600/api/Sizeapi"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newOrder.SizesList = JsonConvert.DeserializeObject<List<Size>>(apiResponse);
                }
            }


            using (var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.GetAsync("https://pizzaordersystem.azurewebsites.net/api/Orders/GetOrders/" + user))
                using (var response = await httpClient.GetAsync("http://localhost:51600/api/CrustAPI"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newOrder.CrustList = JsonConvert.DeserializeObject<List<Crust>>(apiResponse);
                }
            }



            return View(newOrder);
        }
    }
}