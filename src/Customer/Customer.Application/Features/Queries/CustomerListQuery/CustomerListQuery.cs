using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Queries.CustomerListQuery
{
  public class CustomerListQuery : IRequest<List<CustomerVm>>
  {
    //public string UserName { get; set; }

    public CustomerListQuery()
    {
      //UserName = userName ?? throw new ArgumentNullException(nameof(userName));
    }
  }
}
