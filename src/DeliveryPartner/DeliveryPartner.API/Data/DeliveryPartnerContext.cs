using DeliveryPartner.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Data
{
  public class DeliveryPartnerContext : IDeliveryPartnerContext
  {

    public DeliveryPartnerContext(IConfiguration configuration)
    {

      var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

      DeliveryPartnerProfiles = database.GetCollection<DeliveryPartnerProfile>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
      DeliveryPartnerContextSeed.SeedData(DeliveryPartnerProfiles);

    }
    public IMongoCollection<DeliveryPartnerProfile> DeliveryPartnerProfiles { get;  }
  }
}
