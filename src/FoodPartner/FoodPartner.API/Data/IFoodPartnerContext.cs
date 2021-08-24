using FoodPartner.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPartner.API.Data
{
  public interface IFoodPartnerContext
  {
    IMongoCollection<Menu> Menus { get; }
  }
}
