namespace Cik.MagazineWeb.Application.ViewModels
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;

    public class ItemSummaryViewModel
    {
        public ItemSummaryViewModel()
        {
            this.Items = new List<ItemSummaryDto>();
        }

        public int TotalPage { get; set; }
        public IEnumerable<ItemSummaryDto> Items { get; set; }
    }
}