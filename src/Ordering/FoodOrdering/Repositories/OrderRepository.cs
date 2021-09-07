using FoodOrdering.API.Data;
using FoodOrdering.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.API.Repositories
{
  public class OrderRepository : RepositoryBase<FoodOrder>, IOrderRepository
  {
    public OrderRepository(FoodOrderContext _dbContext) : base(_dbContext)
    {

    }
    public async Task<IEnumerable<FoodOrder>> GetOrdersByUserName(string userName)
    {
      var customerList = await _dbContext.FoodOrders
                              .Where(o => o.UserName == userName)
                              .Include(i=>i.Items)
                              .ToListAsync();
      return customerList;
    }
  }
}
