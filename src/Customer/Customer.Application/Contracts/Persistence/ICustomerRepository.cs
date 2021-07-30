using Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Contracts.Persistence
{
  public interface ICustomerRepository : IAsyncRepository<CustomerEntity>
  {
    Task<IEnumerable<CustomerEntity>> GetCustomersByUserName(string userName);
  }
}
