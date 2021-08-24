using FoodPartner.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPartner.API.Data
{
  public class FoodPartnerContextSeed
  {
    public static void SeedData(IMongoCollection<Menu> menuCollection)
    {
      bool existProduct = menuCollection.Find(p => true).Any();
      if (!existProduct)
      {
        menuCollection.InsertManyAsync(GetPreconfiguredMenus());
      }
    }

    private static IEnumerable<Menu> GetPreconfiguredMenus()
    {
      return new List<Menu>()
            {
                new Menu()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    UserName = "Nandini",
                    Items = new List<MenuItem>
                    {
                      new MenuItem{ ItemName="Manchuria", Description="Manchuria", ImageFile="", Price=20},
                      new MenuItem{ ItemName="Biryani", Description="Manchuria", ImageFile="", Price=100},
                      new MenuItem{ ItemName="Gulabjam", Description="Manchuria", ImageFile="", Price=40}
                    }
                    
                },
                new Menu()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    UserName = "KrishnaSagar",
                    Items = new List<MenuItem>
                    {
                      new MenuItem{ ItemName="Manchuria", Description="Manchuria", ImageFile="", Price=20},
                      new MenuItem{ ItemName="Biryani", Description="Manchuria", ImageFile="", Price=100},
                      new MenuItem{ ItemName="Gulabjam", Description="Manchuria", ImageFile="", Price=40}
                    }
                },
                new Menu()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    UserName = "Windchimes",
                    Items = new List<MenuItem>
                    {
                      new MenuItem{ ItemName="Manchuria", Description="Manchuria", ImageFile="", Price=20},
                      new MenuItem{ ItemName="Biryani", Description="Manchuria", ImageFile="", Price=100},
                      new MenuItem{ ItemName="Gulabjam", Description="Manchuria", ImageFile="", Price=40}
                    }
                }
            };
    }

  }
}
