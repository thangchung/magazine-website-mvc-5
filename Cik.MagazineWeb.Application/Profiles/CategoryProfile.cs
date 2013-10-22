namespace Cik.MagazineWeb.Application.Profiles
{
    using AutoMapper;

    using Cik.MagazineWeb.Application.Dtos;
    using Cik.MagazineWeb.DomainModel;

    public class CategoryProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategorySummaryDto>();
            Mapper.CreateMap<CategorySummaryDto, Category>();
        }
    }
}