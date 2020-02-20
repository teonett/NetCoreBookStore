using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreBookStores.Infra.Interface;

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

        public IActionResult Cadastre()
        {
            return View();
        }
    }
}
