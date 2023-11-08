using DSM.az.Models.Base;

namespace DSM.az.Models
{
    public class Portfolio : BaseEntity
    {
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDesc { get; set; }
    }
}
