using Customer.Domain.Common;
using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Persistence
{
  public class CustomerContext : DbContext
  {

    public CustomerContext(DbContextOptions<CustomerContext> options):base(options)
    {

    }

    public DbSet<CustomerEntity> Customers { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

      foreach (var entry in ChangeTracker.Entries<EntityBase>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.Now;
            entry.Entity.CreatedBy = "Narasimha";
            break;
          case EntityState.Modified:
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = "Narasimha";
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

  }
}
