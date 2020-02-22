using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreBookStores.Infra.Interface;
using NetCoreBookStores.Models;

namespace NetCoreBookStores.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductRepository productRepository;

        public StoreController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> Carrossel()
        {
            return View(await productRepository.GetAll());
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Jobs()
        {
            return View();
        }
    }
}
