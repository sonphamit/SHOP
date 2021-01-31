using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            string userName = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            var orderCart = GetCartItems();

            if (!string.IsNullOrWhiteSpace(userName))
            {
                var user = await _userManager.FindByNameAsync(userName);
                var order = await _orderService.GetByCustomerIdOrderingAsync(user.Id);
                if (order is not null)
                {
                    var total = order.OrderDetails.Select(x => x.UnitPrice * x.Quantity).Sum();
                    order.SubTotal = string.Format("{0:0,0 VND}", total);
                    return View(order);
                }
            }

            if (!string.IsNullOrWhiteSpace(orderCart))
            {
                var order = await _orderService.GetByIdOrderingAsync(orderCart);
                var total = order.OrderDetails.Select(x => x.UnitPrice * x.Quantity).Sum();
                order.SubTotal = string.Format("{0:0,0 VND}", total);
                return View(order);

            }

            return View("Empty");

        }

        [HttpGet]
        public async Task<string> getCountOrderDtails()
        {
            var orderCart = GetCartItems();
            if (string.IsNullOrWhiteSpace(orderCart))
            {
                return "0";
            }
            var order = await _orderService.GetByIdOrderingAsync(orderCart);
            return order.OrderDetails.Count().ToString();
        }
        // Lấy cart từ Session orderId
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
