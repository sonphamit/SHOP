using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Models;
using Infrastructure.Services;
using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Extentions;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        protected readonly IProductService _productService;


        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;

        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.Search(null, null, Gender.ALL, null, null, null);

            return View("Index", Tuple.Create(products, 1));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Products([FromQuery]string catagoryId, Gender gender, int? page = 1,
            int? size = null)
        {

            var products = await _productService.Search(catagoryId, null, gender, null, null, null, page, size);

            var pageCurrent = 1;
            if (page > 0 && page!=null)
            {
                pageCurrent = (int)page;
            }

            return View("Index", Tuple.Create(products, pageCurrent));
        }

        public async Task<IActionResult> Sale(int? page = 1, int? size = null)
        {

            var products = await _productService.getSale(page, size);

            var pageCurrent = 1;
            if (page > 0 && page != null)
            {
                pageCurrent = (int)page;
            }

            return View("Index", Tuple.Create(products, pageCurrent));
        }

        public async Task<IActionResult> New(string? catagoryId = null, int? page = 1, int? size = null)
        {
            var products = await _productService.getNew(page, size);

            var pageCurrent = 1;
            if (page > 0 && page != null)
            {
                pageCurrent = (int)page;
            }

            return View("Index", Tuple.Create(products, pageCurrent));
        }

        public async Task<IActionResult> HotItem(string? catagoryId = null, int? page = 1, int? size = null)
        {
            var products = await _productService.getNew(page, size);

            var pageCurrent = 1;
            if (page > 0 && page != null)
            {
                pageCurrent = (int)page;
            }

            return View("Index", Tuple.Create(products, pageCurrent));
        }
    }
}
