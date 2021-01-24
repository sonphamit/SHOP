using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductController : Controller
    {

        protected readonly IProductService _productService;
        protected readonly IOrderService _orderService;
        public const string CARTKEY = "cart";
        public ProductController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsAsync(string id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return View("NotFound");
            }

            return View("Details", product);
        }

        //add to cart
        [HttpGet]
        public async Task AddToCart([FromQuery] string productId, [FromQuery] int quantity, [FromQuery] string? orderId = null)
        {

            if (!string.IsNullOrWhiteSpace(orderId))
            {
                var order = await _orderService.GetByIdAsync(orderId);
                if(order != null)
                {
                   await _orderService.UpdateExistingOrder(productId, quantity, orderId);
                }
            }

            await _orderService.AddNewOrder(productId, quantity);
        }

        //remove item in cart
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            return View();
        }

        //update item in cart
        public IActionResult UpdateCart([FromRoute] int productid)
        {
            return View();
        }

        //show cart
        public IActionResult Cart()
        {
            return View();
        }

        //checked out
        public IActionResult CheckOut()
        {
            // Xử lý khi đặt hàng
            return View();
        }
    }
}
