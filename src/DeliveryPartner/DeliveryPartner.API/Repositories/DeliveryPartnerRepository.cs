using DeliveryPartner.API.Data;
using DeliveryPartner.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Repositories
{
  public class DeliveryPartnerRepository : IDeliveryPartnerRepository
  {
    private readonly IDeliveryPartnerContext _context;

    public DeliveryPartnerRepository(IDeliveryPartnerContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateProfile(DeliveryPartnerProfile deliveryPartnerProfile)
    {
      await _context.DeliveryPartnerProfiles.InsertOneAsync(deliveryPartnerProfile);
    }

    public async Task<bool> DeleteProfile(string id)
    {
      FilterDefinition<DeliveryPartnerProfile> filter = Builders<DeliveryPartnerProfile>.Filter.Eq(p => p.Id, id);

      DeleteResult deleteResult = await _context
                                          .DeliveryPartnerProfiles
                                          .DeleteOneAsync(filter);

      return deleteResult.IsAcknowledged
          && deleteResult.DeletedCount > 0;
    }

    public async Task<DeliveryPartnerProfile> GetProfile(string id)
    {
      return await _context
                     .DeliveryPartnerProfiles
                     .Find(p => p.Id == id)
                     .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<DeliveryPartnerProfile>> GetProfileByUserName(string username)
    {
      return await _context
                     .DeliveryPartnerProfiles
                     .Find(p => p.UserName == username)
                     .ToListAsync();
    }

    public async Task<bool> UpdateProfile(DeliveryPartnerProfile profile)
    {
      var updateResult = await _context
                                  .DeliveryPartnerProfiles
                                  .ReplaceOneAsync(filter: g => g.Id == profile.Id, replacement: profile);

      return updateResult.IsAcknowledged
              && updateResult.ModifiedCount > 0;
    }
  }
}
