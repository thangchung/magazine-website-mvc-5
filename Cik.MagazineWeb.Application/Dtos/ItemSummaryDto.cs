namespace Cik.MagazineWeb.Application.Dtos
{
    public class ItemSummaryDto : DtoBase
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int ItemId { get; set; }

        public string Title { get; set; }

        public string AvatarImage { get; set; }

        public string ShortDescription { get; set; }
    }
}