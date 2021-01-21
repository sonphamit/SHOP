using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductController : Controller
    {

        protected readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        public IActionResult AddToCart([FromRoute] int productid)
        {
            return View();
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
