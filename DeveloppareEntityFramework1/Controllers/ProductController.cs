using DeveloppareEntityFramework.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloppareEntityFramework.Controllers
{
    public class ProductController : Controller
    {
        private readonly DatabaseContext DbContext;
        public ProductController(DatabaseContext inputDbContext)
        {
            DbContext = inputDbContext;
        }

        public async Task<IActionResult> Index(long productId)
        {
            var product = await DbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            return View(product);
        }

    }
}
