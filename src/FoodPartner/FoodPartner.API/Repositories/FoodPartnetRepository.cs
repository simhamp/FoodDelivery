using FoodPartner.API.Data;
using FoodPartner.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPartner.API.Repositories
{
  public class FoodPartnetRepository : IFoodPartnerRepository
  {

    private readonly IFoodPartnerContext _context;

    public FoodPartnetRepository(IFoodPartnerContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateMenu(Menu menu)
    {
      await _context.Menus.InsertOneAsync(menu);
    }

    public async Task<bool> DeleteMenu(string id)
    {
      FilterDefinition<Menu> filter = Builders<Menu>.Filter.Eq(p => p.Id, id);

      DeleteResult deleteResult = await _context
                                          .Menus
                                          .DeleteOneAsync(filter);

      return deleteResult.IsAcknowledged
          && deleteResult.DeletedCount > 0;
    }

    public async Task<Menu> GetMenu(string id)
    {
      return await _context
                     .Menus
                     .Find(p => p.Id == id)
                     .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Menu>> GetMenuByUserName(string username)
    {
      return await _context
                     .Menus
                     .Find(p => p.UserName == username)
                     .ToListAsync();
    }

    public async Task<bool> UpdateMenu(Menu menu)
    {
      var updateResult = await _context
                                  .Menus
                                  .ReplaceOneAsync(filter: g => g.Id == menu.Id, replacement: menu);

      return updateResult.IsAcknowledged
              && updateResult.ModifiedCount > 0;
    }
  }
}
