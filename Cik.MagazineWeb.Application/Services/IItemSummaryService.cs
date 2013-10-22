namespace Cik.MagazineWeb.Application.Services
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;

    public interface IItemSummaryService
    {
        IEnumerable<ItemSummaryDto> GetItemSummaries();
        IEnumerable<ItemSummaryDto> GetHottestItems(int numOfItemOnHomePage);
        IEnumerable<ItemSummaryDto> GetLatestItems(int numOfItemOnHomePage);
        IEnumerable<ItemSummaryDto> GetItemsByCategoryId(int categoryId);
        ItemDetailsDto GetItemDetails(int itemId);
    }
}