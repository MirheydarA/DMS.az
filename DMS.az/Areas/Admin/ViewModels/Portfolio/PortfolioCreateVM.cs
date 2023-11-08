using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace DSM.az.Areas.Admin.ViewModels.Portfolio
{
    public class PortfolioCreateVM
    {
        [Required(ErrorMessage ="Şəkil daxil edilməlidir")]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Link daxil edilməlidir")]
        public string RedirectLink { get; set; }
    }
}
