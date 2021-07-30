using AutoMapper;
using Customer.Application.Contracts.Persistence;
using Customer.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Features.Commands.SaveCustomer
{
  public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, int>
  {

    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<SaveCustomerCommandHandler> _logger;

    public SaveCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<SaveCustomerCommandHandler> logger)
    {
      _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
    {
      var customerEntity = _mapper.Map<CustomerEntity>(request);
      var newCustomer = await _customerRepository.AddAsync(customerEntity);

      _logger.LogInformation($"Customer {newCustomer.Id} is successfully created.");

      return newCustomer.Id;

    }
  }
}
