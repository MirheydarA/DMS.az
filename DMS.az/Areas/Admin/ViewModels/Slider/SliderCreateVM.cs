using DSM.az.Enums;
using System.ComponentModel.DataAnnotations;

namespace DSM.az.Areas.Admin.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required(ErrorMessage = "Please enter photo")]
        public IFormFile MediaName { get; set; }

        [MinLength(5, ErrorMessage = "Title must be at least 5 characters")]
        [MaxLength(60, ErrorMessage = "Title must be maximum 60 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter photo")]
        public SliderContentType Type { get; set; }

    }
}
