namespace Cik.MagazineWeb.Application
{
    using System.Collections.Generic;

    using Cik.MagazineWeb.Application.Dtos;
    using Cik.MagazineWeb.Application.ViewModels;

    public interface IMagazineApplication
    {
        //#region admin page

        //#region category

        //IEnumerable<CategorySummaryDto> GetCategorySummaries();

        //CategorySummaryDto GetCategoryById(int id);

        //CategorySummaryViewModel GetCategoryPaging(int pageSize, int page);

        //void SaveCategory(CategorySummaryDto dto);

        //void DeleteCategory (int id);

        //#endregion

        //#region item

        //ItemSummaryViewModel GetItemSummaryPaging(int pageSize, int page);

        //ItemDetailsDto GetItemById(int id);

        //void SaveItem(ItemDetailsDto dto);

        //void DeleteItem(int id);

        //#endregion

        //#endregion

        #region front-end page

        HomePageViewModel BuildHomePageViewModel(int numOfItemOnHomePage);

        CategoryPageViewModel BuildCategoryPageViewModel(int id);

        ItemDetailsViewModel BuildItemDetailsViewModel(int categoryId, int itemId);

        CategoryMenuViewModel GetCategoryMenu(int id);

        #endregion
    }
}