using DSM.az.Enums;
using DSM.az.Models.Base;

namespace DSM.az.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string MediaPath { get; set; }
        public SliderContentType Type { get; set; }
    }
}
