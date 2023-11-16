namespace DMS.az.ViewModels.Portfolio
{
    public class PortfolioIndexVM
    {
        public PortfolioIndexVM()
        {
            Portfolio = new List<Models.Portfolio>();
        }

        public List<Models.Portfolio> Portfolio { get; set; }
    }
}
