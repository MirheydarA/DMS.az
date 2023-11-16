using DMS.az.Models;
using DSM.az.Models;

namespace DMS.az.ViewModels.Home
{
    public class HomeIndexVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Models.AboutUs> AboutUs { get; set; }
        public List<Models.Portfolio> Portfolios { get; set; }
        public List<Service> Services { get; set; }
        public List<OurEmployee> OurEmployees { get; set; }
        public List<Models.Contact> Contact { get; set; }
    }
}
