namespace Cik.MagazineWeb.Application.ViewModels
{
    using Cik.MagazineWeb.Application.Dtos;

    public class ItemDetailsViewModel : FrontPageViewModelBase
    {
        public ItemDetailsViewModel()
        {
            this.ItemDetails = new ItemDetailsDto();
        }
        
        public ItemDetailsDto ItemDetails { get; set; }
    }
}