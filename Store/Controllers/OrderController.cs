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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task OrderByUser([FromQuery] string userId)
        {
            //GetHashCode by Id user
           var order = _orderService.GetById("");

        }
    }
}
