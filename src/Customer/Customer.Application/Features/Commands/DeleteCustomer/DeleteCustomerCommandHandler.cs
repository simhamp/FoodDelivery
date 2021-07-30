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

namespace Customer.Application.Features.Commands.DeleteCustomer
{
  public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
  {

    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteCustomerCommandHandler> _logger;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
    {
      _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
      var customerToDelete = _customerRepository.GetByIdAsync(request.Id);

      if(customerToDelete == null)
      {
        //throw new NotFoundException();
      }

      var customerEntiry = _mapper.Map<CustomerEntity>(customerToDelete);
      await _customerRepository.DeleteAsync(customerEntiry);

      _logger.LogInformation($"Customer {customerToDelete.Id} is successfully deleted.");

      return Unit.Value;

    }
  }
}
