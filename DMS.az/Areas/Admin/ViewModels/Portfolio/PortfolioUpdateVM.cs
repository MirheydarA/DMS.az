using System.ComponentModel.DataAnnotations;

namespace DSM.az.Areas.Admin.ViewModels.Portfolio
{
    public class PortfolioUpdateVM
    {
        public string? PhotoPath { get; set; }
        public IFormFile? Photo { get; set; }
        [Required(ErrorMessage = "Link daxil edilməlidir")]
        public string RedirectLink { get; set; }
    }
}
