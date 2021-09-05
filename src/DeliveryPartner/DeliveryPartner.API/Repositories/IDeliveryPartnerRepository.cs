using DeliveryPartner.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Repositories
{
  public interface IDeliveryPartnerRepository
  {
    Task<DeliveryPartnerProfile> GetProfile(string id);
    Task<IEnumerable<DeliveryPartnerProfile>> GetProfileByUserName(string username);  

    Task CreateProfile(DeliveryPartnerProfile menu);
    Task<bool> UpdateProfile(DeliveryPartnerProfile menu);
    Task<bool> DeleteProfile(string id);
  }
}
