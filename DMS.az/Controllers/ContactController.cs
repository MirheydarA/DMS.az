using DMS.az.DAL;
using DMS.az.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.az.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ContactIndexVM
            {
                Contact = await _context.Contact.ToListAsync()
            };

            return View(model);
        }
    }
}
