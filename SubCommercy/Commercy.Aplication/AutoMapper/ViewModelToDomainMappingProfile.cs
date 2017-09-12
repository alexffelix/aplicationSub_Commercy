using AutoMapper;
using Commercy.Aplication.ViewModels;
using CommercyDomain.Entities;

namespace Equinox.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>()
                .ConstructUsing(c => new Employee());
        }
    }
}
