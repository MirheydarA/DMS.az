using DMS.az.DAL;
using DSM.az.Areas.Admin.ViewModels.Portfolio;
using DSM.az.Areas.Admin.ViewModels.Slider;
using DSM.az.Models;
using DSM.az.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSM.az.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public PortfolioController(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        #region PortfolioList
        [HttpGet]
        public async Task<IActionResult> Index(PortfolioIndexVM model)
        {
            model = new PortfolioIndexVM
            {
                Portfolios = await _context.Portfolios.OrderByDescending(s => s.Id).Where(s => !s.IsDeleted).ToListAsync(),
            };

            return View(model);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PortfolioCreateVM model)
        {
            if (!ModelState.IsValid) return View();

            if (!_fileService.IsImage(model.Photo))
            {
                ModelState.AddModelError("MediaName", "Fayl formatı yalnışdır");
                return View();
            }

            if (!_fileService.IsBiggerThanSize(model.Photo, 2000))
            {
                ModelState.AddModelError("MediaName", "Faylın ölçüsü 2MB-dan böyükdür");
                return View();
            }

            var portfolio = new Portfolio
            {
                Title = model.Title,
                Description = model.Description,
                ShortDesc = model.ShortDesc,
                Photo = _fileService.Upload(model.Photo),
                CreatedAt = DateTime.Now
            };

            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == id);
            if (portfolio is null) return NotFound("Portfolio Tapılmadı");

            var model = new PortfolioUpdateVM
            {
                Title = portfolio.Title,
                Description = portfolio.Description,
                ShortDesc = portfolio.ShortDesc,
                PhotoPath = portfolio.Photo
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, PortfolioUpdateVM model)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(s => s.Id == id);
            if (portfolio is null) return NotFound("Portfolio Tapılmadı");


            if (!ModelState.IsValid) return View();

            if (model.Photo is not null)
            {
                if (!_fileService.IsImage(model.Photo))
                {
                    ModelState.AddModelError("MediaName", "Fayl formatı yalnışdır");
                    return View();
                }

                if (!_fileService.IsBiggerThanSize(model.Photo, 2000))
                {
                    ModelState.AddModelError("MediaName", "Faylın ölçüsü 2MB-dan böyükdür");
                    return View();
                }
                _fileService.Delete(portfolio.Photo);
                portfolio.Photo = _fileService.Upload(model.Photo);
            }

            portfolio.Title = model.Title;
            portfolio.Description = model.Description;
            portfolio.ShortDesc = model.ShortDesc;
            portfolio.ModifiedAt = DateTime.Now;

            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio is null) return NotFound("Portfolio Tapılmadı!");

            portfolio.IsDeleted = true;
            _context.Update(portfolio);
            _context.SaveChanges();

            return Ok();
        }
        #endregion
    }
}
