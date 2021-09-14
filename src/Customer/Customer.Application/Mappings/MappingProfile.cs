using AutoMapper;
using Customer.Application.Features.Commands.SaveCustomer;
using Customer.Application.Features.Commands.UpdateCustomer;
using Customer.Application.Features.Queries.CustomerListQuery;
using Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Mappings
{
  class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<CustomerEntity, CustomerVm>().ReverseMap();
      CreateMap<SaveCustomerCommand, CustomerEntity>().ReverseMap();
      CreateMap<UpdateCustomerCommand, CustomerEntity>().ReverseMap();
    }


  }
}
