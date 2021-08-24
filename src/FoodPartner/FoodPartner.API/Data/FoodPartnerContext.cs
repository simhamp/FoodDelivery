using FoodPartner.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPartner.API.Data
{
  public class FoodPartnerContext : IFoodPartnerContext
  {
    public FoodPartnerContext(IConfiguration configuration)
    {

      var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

      Menus = database.GetCollection<Menu>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
      FoodPartnerContextSeed.SeedData(Menus);

    }
    public IMongoCollection<Menu> Menus { get; }
  }
}
