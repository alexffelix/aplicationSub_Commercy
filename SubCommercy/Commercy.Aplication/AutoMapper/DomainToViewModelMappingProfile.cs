using AutoMapper;
using Commercy.Aplication.ViewModels;
using CommercyDomain.Entities;

namespace Equinox.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
