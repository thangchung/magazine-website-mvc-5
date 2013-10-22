namespace Cik.MagazineWeb.Application.ViewModels
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;

    public class CategorySummaryViewModel
    {
        public IEnumerable<CategorySummaryDto> Categories { get; set; }

        public int TotalPage { get; set; }
    }
}