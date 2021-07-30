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

namespace Customer.Application.Features.Commands.UpdateCustomer
{
  public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
  {

    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCustomerCommand> _logger;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<UpdateCustomerCommand> logger)
    {
      _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
      var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);

      if(customerToUpdate == null)
      {
        //throw new NotFoundException();
      }

      _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(CustomerEntity));
      
      await _customerRepository.UpdateAsync(customerToUpdate);
      _logger.LogInformation($"Order {customerToUpdate.Id} is successfully updated.");

      return Unit.Value;
    }
  }
}
