using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GraphQLFirstPLApp.Web.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQLFirstPLApp.Web.Models;

namespace GraphQLFirstPLApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductGraphClient _productGraphClient;

        public HomeController(ProductGraphClient productGraphClient)
        {
            _productGraphClient = productGraphClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productGraphClient.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductDetail(int productId)
        {
            var product = await _productGraphClient.GetProduct(productId);
            return View(product);
        }
    }
}
