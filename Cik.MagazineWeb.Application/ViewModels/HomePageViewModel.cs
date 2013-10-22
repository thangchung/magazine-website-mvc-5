namespace Cik.MagazineWeb.Application.ViewModels
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;

    public class HomePageViewModel : FrontPageViewModelBase
    {
        public HomePageViewModel()
        {
            this.HottestItems = new List<ItemSummaryDto>();
            this.LatestItems = new List<ItemSummaryDto>();
        }

        public List<ItemSummaryDto> HottestItems { get; set; }

        public List<ItemSummaryDto> LatestItems { get; set; }
    }
}