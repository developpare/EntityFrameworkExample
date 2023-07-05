using DeveloppareEntityFramework.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloppareEntityFramework.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext DbContext;
        public ProductsController(DatabaseContext inputDbContext)
        {
            DbContext = inputDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await DbContext.Products.OrderBy(x => x.ProductName).ToListAsync();

            return View(products);
        }

    }
}
