using EcommApi.Models;
using Microsoft.AspNetCore.Mvc;
using ProductApi_BLL.Abstract;
using System.Diagnostics;

namespace EcomMVC.Controllers
{
    public class HomeController : Controller
    {
        IProductBLL productService;

        public HomeController(IProductBLL productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var product = productService.GetProductById(6); //Veri geldi, UI düzenlemeleri kaldı
            return View();
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
    }
}