using AutoMapper;
using Customer.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Features.Queries.CustomerListQuery
{

 
  public class CustomerListQueryHandler : IRequestHandler<CustomerListQuery, List<CustomerVm>>
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
      _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<CustomerVm>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
    {
      var customerList = await _customerRepository.GetAllAsync();
      return _mapper.Map<List<CustomerVm>>(customerList);
    }
  }
}
