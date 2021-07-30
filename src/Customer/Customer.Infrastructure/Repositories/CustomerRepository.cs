using Customer.Application.Contracts.Persistence;
using Customer.Domain.Entities;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Repositories
{
  public class CustomerRepository : RepositoryBase<CustomerEntity>, ICustomerRepository
  {
    public CustomerRepository(CustomerContext _dbContext) : base(_dbContext)
    {

    }

    public async Task<IEnumerable<CustomerEntity>> GetCustomersByUserName(string userName)
    {
      var customerList = await _dbContext.Customers
                              .Where(o => o.UserName == userName)
                              .ToListAsync();
      return customerList;
    }
  }
}
