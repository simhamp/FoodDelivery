using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.API.Entities
{
  public class FoodOrder : EntityBase
  {
    
    public string UserName { get; set; }

    public List<OrderItem> Items { get; set; }

    public double TotalCost { get; set; }
    public string FoodPartner { get; set; }
    public string DeliveryPartner { get; set; }
    public string FoodPartnerStatus { get; set; }
    public string DeliveryPartnerStatus { get; set; }
  }

  public class OrderItem : EntityBase
  {
    public int FoodOrderId { get; set; }
    public string ItemName { get; set; }
    public decimal Price { get; set; }

  }


}
