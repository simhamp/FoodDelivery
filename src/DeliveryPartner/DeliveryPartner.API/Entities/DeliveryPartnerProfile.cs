using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryPartner.API.Entities
{
  public class DeliveryPartnerProfile
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("UserName")]
    public string UserName { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string Address3 { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string Photo { get; set; }


  }
}
