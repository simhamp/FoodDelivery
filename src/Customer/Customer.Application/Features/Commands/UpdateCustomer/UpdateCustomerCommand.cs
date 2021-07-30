using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Commands.UpdateCustomer
{
  public class UpdateCustomerCommand : IRequest
  {

    public int Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string CustomerType { get; set; }
  }
}
