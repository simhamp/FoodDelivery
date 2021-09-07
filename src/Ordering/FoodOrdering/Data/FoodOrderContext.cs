using FoodOrdering.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrdering.API.Data
{
  public class FoodOrderContext : DbContext
  {

    public FoodOrderContext(DbContextOptions<FoodOrderContext> options) : base(options)
    {

    }

    public DbSet<FoodOrder> FoodOrders { get; set; }

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
