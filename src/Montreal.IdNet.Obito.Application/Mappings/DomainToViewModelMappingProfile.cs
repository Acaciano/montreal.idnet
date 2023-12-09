using AutoMapper;
using Montreal.IdNet.Obito.Application.ViewModels;
using Montreal.IdNet.Obito.Domain.Entity;


namespace Montreal.IdNet.Obito.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Demo, DemoViewModel>().ReverseMap();
        }
    }
}
