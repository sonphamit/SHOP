using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Store.Controllers
{


    public class OrderController : Controller
    {
        protected readonly IOrderService _orderService;
        protected readonly UserManager<ApplicationUser> _userManager;
        public const string CARTKEY = "cart";

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string userName = null)
        {
            var orderCart = GetCartItems();

            if (!string.IsNullOrWhiteSpace(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
               var order = await _orderService.GetByCustomerIdOrderingAsync(user.Id);
                return View(order);

            }

            if (!string.IsNullOrWhiteSpace(orderCart))
            {
                var order = await _orderService.GetByIdOrderingAsync(orderCart);
                return View(order);

            }

            return View("Empty");

        }

        // Lấy cart từ Session (danh sách CartItem)
        public string GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<string>(jsoncart);
            }

            return "";
        }
    }
}
