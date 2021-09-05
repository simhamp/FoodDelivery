using DeliveryPartner.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Data
{
  public class DeliveryPartnerContextSeed
  {
    public static void SeedData(IMongoCollection<DeliveryPartnerProfile> menuCollection)
    {
      bool existProduct = menuCollection.Find(p => true).Any();
      if (!existProduct)
      {
        menuCollection.InsertManyAsync(GetPreconfiguredProfiles());
      }
    }

    private static IEnumerable<DeliveryPartnerProfile> GetPreconfiguredProfiles()
    {
      return new List<DeliveryPartnerProfile>()
            {
                new DeliveryPartnerProfile()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    UserName = "John",
                    Address1 = "House No 123",
                    Address2 = "1st A cross",
                    Address3 = "Kirshan Nagar",
                    City = "Bangalore",
                    Country= "India",
                    Photo = "",
                    ZipCode= "560016",
                    State = "KA"                   

                },
                new DeliveryPartnerProfile()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    UserName = "Kumar",
                    Address1 = "House No 456",
                    Address2 = "1st A cross",
                    Address3 = "Sri Nagar",
                    City = "Bangalore",
                    Country= "India",
                    Photo = "",
                    ZipCode= "560016",
                    State = "KA"
                },
                new DeliveryPartnerProfile()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    UserName = "Taman",
                    Address1 = "House No xyz",
                    Address2 = "1st Main",
                    Address3 = "Kalyan Nagar",
                    City = "Bangalore",
                    Country= "India",
                    Photo = "",
                    ZipCode= "515017",
                    State = "KA"
                }
            };
    }

  }
}
