using DMS.az.DAL;
using DMS.az.ViewModels.Portfolio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.az.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new PortfolioIndexVM
            {
                Portfolio = await _context.Portfolios.ToListAsync()
            };
            return View(model);
        }
    }
}
