using Infrastructure.Entities;
using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        protected readonly UserManager<ApplicationUser> _userManager;
        public const string CARTKEY = "cart";
        public ProductController(IProductService productService, IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _productService = productService;
            _orderService = orderService;
            _userManager = userManager;
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
        public async Task AddToCart([FromQuery] string productId, [FromQuery] int quantity, [FromQuery] string? orderId = null, [FromQuery] string? userName = null)
        {
            var newOrder = new OrderResponseModel();
            if (!string.IsNullOrWhiteSpace(orderId))
            {
                var order = await _orderService.GetByIdAsync(orderId);
                if(order != null && string.IsNullOrWhiteSpace(userName))
                {
                  newOrder =   await _orderService.UpdateExistingOrder(productId, quantity, orderId);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    var user = await _userManager.FindByNameAsync(userName);

                    newOrder = await _orderService.AddNewOrder(productId, quantity, user.Id);
                }
                else
                {
                    newOrder = await _orderService.AddNewOrder(productId, quantity);
                }
                
            }
         
            // Lưu cart vào Session
            SaveCartSession(newOrder);

            return;
        }



        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(OrderResponseModel order)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(order);
            session.SetString(CARTKEY, jsoncart);
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
