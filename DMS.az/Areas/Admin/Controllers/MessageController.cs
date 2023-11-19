using DMS.az.Areas.Admin.ViewModels.Message;
using DMS.az.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.az.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly AppDbContext _context;

        public MessageController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new MessageIndexVM();

            model.Messages = await _context.Messages.OrderByDescending(m => m.Id).ToListAsync();
            return View(model);
        }
    }
}
