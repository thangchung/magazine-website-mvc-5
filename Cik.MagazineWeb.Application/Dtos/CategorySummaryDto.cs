namespace Cik.MagazineWeb.Application.Dtos
{
    public class CategorySummaryDto : DtoBase
    {
        public string Name { get; set; }

        public bool IsCurrentPage { get; set; }
    }
}