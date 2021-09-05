using DeliveryPartner.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Data
{
  public interface IDeliveryPartnerContext
  {
    IMongoCollection<DeliveryPartnerProfile> DeliveryPartnerProfiles { get; }
  }
}
