using FoodPartner.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPartner.API.Repositories
{
  public interface IFoodPartnerRepository
  {
    //Task<IEnumerable<Menu>> GetMenus();
    Task<Menu> GetMenu(string id);
    Task<IEnumerable<Menu>> GetMenuByUserName(string username);
    //Task<IEnumerable<Menu>> GetProductByCategory(string categoryName);

    Task CreateMenu(Menu menu);
    Task<bool> UpdateMenu(Menu menu);
    Task<bool> DeleteMenu(string id);
  }
}
