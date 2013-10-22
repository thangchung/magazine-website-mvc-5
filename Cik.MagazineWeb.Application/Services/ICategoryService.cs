namespace Cik.MagazineWeb.Application.Services
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;

    public interface ICategoryService
    {
        List<CategorySummaryDto> GetCategoryForMenu();
    }
}