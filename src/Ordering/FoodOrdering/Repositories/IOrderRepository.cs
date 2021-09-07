using FoodOrdering.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.API.Repositories
{  
  public interface IOrderRepository : IAsyncRepository<FoodOrder>
  {
    Task<IEnumerable<FoodOrder>> GetOrdersByUserName(string userName);
  }
}
