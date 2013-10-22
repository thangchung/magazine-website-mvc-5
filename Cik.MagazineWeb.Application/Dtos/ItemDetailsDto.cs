namespace Cik.MagazineWeb.Application.Dtos
{
    public class ItemDetailsDto : DtoBase
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public string SmallImageUrl { get; set; }

        public string MediumImageUrl { get; set; }

        public string BigImageUrl { get; set; }

        public long NumOfView { get; set; }
    }
}