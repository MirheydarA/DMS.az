using DMS.az.DAL;
using DMS.az.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.az.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ServicesCount = _context.Services.Count();

            var model = new HomeIndexVM
            {
                Sliders = await _context.Sliders.Where(x => !x.IsDeleted).ToListAsync(),
                AboutUs = await _context.AboutUs.Where(x => !x.IsDeleted).ToListAsync(),
                Portfolios = await _context.Portfolios.Where(x => !x.IsDeleted).ToListAsync(),
                Services = await _context.Services.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Take(3).ToListAsync(),
                OurEmployees = await _context.OurEmployees.Where(x => !x.IsDeleted).ToListAsync(),
                Contact = await _context.Contact.ToListAsync(),
            };

            return View(model);
        }

        public async Task<IActionResult> LoadMore(int skipRow)
        {

            var model = new HomeLoadMoreVM
            {
                Services = await _context.Services.OrderByDescending(x => x.Id).Skip(3 * skipRow).Take(3).ToListAsync()
            };

            return PartialView("_ServicesComponentPartial", model);
        }
    }
}
