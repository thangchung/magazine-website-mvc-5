namespace Cik.MagazineWeb.Application.Services.Impl
{
    using System.Collections.Generic;
    using System.Linq;

    using Cik.MagazineWeb.Application.Dtos;
    using Cik.MagazineWeb.DomainModel;
    using Cik.Web.Utilities;

    public class ItemSummaryService : IItemSummaryService
    {
        private readonly IMagazineWebRepository _repository;

        public ItemSummaryService(IMagazineWebRepository repository)
        {
            Guard.ArgumentNotNull(repository, "Repository");

            _repository = repository;
        }

        public IEnumerable<ItemSummaryDto> GetItemSummaries()
        {
            var queryable = this._repository.GetAllItems();
            return this.ConvertToItemSummaryDtoQuery(queryable);
        }

        public IEnumerable<ItemSummaryDto> GetHottestItems(int numOfItemOnHomePage)
        {
            var queryable = this._repository.GetAllItems();
            return this.ConvertToItemSummaryDtoQuery(
                        queryable.OrderByDescending(item => item.CreatedDate),
                        numOfItemOnHomePage);
        }

        public IEnumerable<ItemSummaryDto> GetLatestItems(int numOfItemOnHomePage)
        {
            var queryable = this._repository.GetAllItems();

            return this.ConvertToItemSummaryDtoQuery(
                        queryable.OrderByDescending(item => item.ItemContent.NumOfView), 
                        numOfItemOnHomePage);
        }

        public IEnumerable<ItemSummaryDto> GetItemsByCategoryId(int categoryId)
        {
            var queryable = this._repository.GetAllItems();
            return this.ConvertToItemSummaryDtoQuery(
                        queryable.OrderByDescending(item => item.CreatedDate))
                            .Where(item => item.CategoryId == categoryId);
        }

        public ItemDetailsDto GetItemDetails(int itemId)
        {
            return (from item in this._repository.GetAllItems()
                    where item.Id == itemId
                    select new ItemDetailsDto
                        {
                            Title = item.ItemContent.Title,
                            Content = item.ItemContent.Content,
                            SmallImageUrl = item.ItemContent.SmallImage
                        }).FirstOrDefault();
        }

        private IEnumerable<ItemSummaryDto> ConvertToItemSummaryDtoQuery(IQueryable<Item> sourceQuery,  int? numOfItemOnHomePage = null)
        {
            var queryableResult = sourceQuery.Select(
                item => new ItemSummaryDto
                {
                    CategoryId = item.Category.Id,
                    CategoryName = item.Category.Name,
                    ItemId = item.Id,
                    Title = item.ItemContent.Title,
                    AvatarImage = item.ItemContent.SmallImage,
                    ShortDescription = item.ItemContent.ShortDescription,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate
                });

            if (numOfItemOnHomePage.HasValue)
            {
                queryableResult = queryableResult.Take(numOfItemOnHomePage.Value);
            }

            return queryableResult;
        }
    }
}