namespace Cik.MagazineWeb.Application.ViewModels
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;

    public class CategoryMenuViewModel
    {
        public CategoryMenuViewModel()
        {
            this.Categories = new List<CategorySummaryDto>();
        }

        public IEnumerable<CategorySummaryDto> Categories { get; set; }
    }
}