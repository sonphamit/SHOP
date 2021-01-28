using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        protected readonly IOrderService _orderService;
        protected readonly IRoleService _roleService;

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string userName)
        {
            var user = await _roleService.FindByNameAsync(userName);
            //GetHashCode by Id user
            var order = _orderService.GetById(user.Id);
            return View(order);
        }
    }
}
