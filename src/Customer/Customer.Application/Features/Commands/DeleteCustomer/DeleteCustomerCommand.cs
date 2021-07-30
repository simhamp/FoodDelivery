using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Commands.DeleteCustomer
{
  public class DeleteCustomerCommand : IRequest
  {
    public int Id { get; set; }
  }
}
