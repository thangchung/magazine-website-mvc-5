namespace Cik.MagazineWeb.Application.Services.Impl
{
    using System.Collections.Generic;
    using System.Linq;

    using Cik.MagazineWeb.Application.Dtos;
    using Cik.MagazineWeb.DomainModel;
    using Cik.Web.Utilities;
    using Cik.Web.Utilities.Extensions;

    public class CategoryService : ICategoryService
    {
        private readonly IMagazineWebRepository _repository;

        public CategoryService(IMagazineWebRepository repository)
        {
            Guard.ArgumentNotNull(repository, "Repository");

            _repository = repository;
        }

        public List<CategorySummaryDto> GetCategoryForMenu()
        {
            return _repository.GetAllCategories().ToList().MapTo<CategorySummaryDto>();
        }
    }
}