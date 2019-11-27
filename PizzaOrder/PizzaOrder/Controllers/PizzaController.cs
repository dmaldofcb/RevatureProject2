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
using Layers.Models.ViewModels;

namespace PizzaOrder.Controllers
{
    public class PizzaController : Controller
    {

       

        //// Display Menu
        //public async Task<ActionResult> IndexAsync()
        //{
        //    List<PizzaPie> pizzas = new List<PizzaPie>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://pizzorderapi.azurewebsites.net/api/Pizza"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            pizzas = JsonConvert.DeserializeObject<List<PizzaPie>>(apiResponse);
        //        }
        //    +
            // Display Menu
            public async Task<IActionResult> Index()
            {
                //List<PizzaPie> pizzas = null;
                PizzaPie pizzas = null;
                using (var client = new HttpClient())
                {
                //client.BaseAddress = new Uri("http://localhost:51600/"); // DONT PLACE API HERE. OR ELSE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/json"));

                //var apiUrl = "api/Pizza";
                var responseTask = await client.GetAsync("https://pizzaordersystem.azurewebsites.net/api/PizzaAPI");
                    //responseTask.Wait();
                    //var result = responseTask.Result;
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var readTask = responseTask.Content.ReadAsStringAsync().Result;
                        //readTask.Wait();
                        pizzas = JsonConvert.DeserializeObject<PizzaPie>(readTask);

                    }
                    else //web api sent error response 
                    {

                        ModelState.AddModelError(string.Empty, "Server error. Please wait a few minutes and refresh the page.");
                    }
                }
                //return Content(pizzas.Size.ToString());
                return View(pizzas);
            }


            //var pizzasAsString = stringTask.Result;
            //var result = JsonConvert.DeserializeObject<List<PizzaPie>>(pizzasAsString);




            // GET: Pizza/Details/5
            //public async Task<IActionResult> Details(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var pizza = await _context.Pizzas
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (pizza == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(pizza);
            //}

            //// GET: Pizza/Create
            //public IActionResult Create()
            //{
            //    return View();
            //}

            //// POST: Pizza/Create
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Create([Bind("Id,Type,CrustID,SizeId,IsCustom")] Layers.Models.Models.Pizza pizza)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _context.Add(pizza);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(pizza);
            //}

            //// GET: Pizza/Edit/5
            //public async Task<IActionResult> Edit(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var pizza = await _context.Pizzas.FindAsync(id);
            //    if (pizza == null)
            //    {
            //        return NotFound();
            //    }
            //   return View(pizza);
            //}

            //// POST: Pizza/Edit/5
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Edit(int id, [Bind("Id,Type,CrustID,SizeId,IsCustom")] Layers.Models.Models.Pizza pizza)
            //{
            //    if (id != pizza.Id)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(pizza);
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!PizzaExists(pizza.Id))
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(pizza);
            //}

            //// GET: Pizza/Delete/5
            //public async Task<IActionResult> Delete(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var pizza = await _context.Pizzas
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (pizza == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(pizza);
            //}

            //// POST: Pizza/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(int id)
            //{
            //    var pizza = await _context.Pizzas.FindAsync(id);
            //    _context.Pizzas.Remove(pizza);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //private bool PizzaExists(int id)
            //{
            //    return _context.Pizzas.Any(e => e.Id == id);
            //}
        }
    }
