using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPartner.API.Entities
{
  public class Menu
  {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("UserName")]
    public string UserName { get; set; }

    public List<MenuItem> Items { get; set; }
    
  }

  public class MenuItem
  {
    public string ItemName { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }
    public string ImageFile { get; set; }


  }

}
