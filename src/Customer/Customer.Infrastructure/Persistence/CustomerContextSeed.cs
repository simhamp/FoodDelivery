using Customer.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Persistence
{
  public class CustomerContextSeed
  {

    public static async Task SeedAsync(CustomerContext customerContext, ILogger<CustomerContextSeed> logger)
    {
      if (!customerContext.Customers.Any())
      {
        customerContext.Customers.AddRange(GetPreconfiguredOrders());
        await customerContext.SaveChangesAsync();
        logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CustomerContext).Name);
      }
    }

    private static IEnumerable<CustomerEntity> GetPreconfiguredOrders()
    {
      return new List<CustomerEntity>
            {
                new CustomerEntity() {UserName = "simhamp", FirstName = "Narasimha", LastName = "Peta", Email = "simhamp@gmail.com", Phone = "6364798081", CustomerType = "Admin" }
            };
    }
  }
}
