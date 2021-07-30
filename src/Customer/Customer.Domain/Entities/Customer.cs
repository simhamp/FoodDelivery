using Customer.Domain.Common;

namespace Customer.Domain.Entities
{
  public class CustomerEntity : EntityBase
  {
    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string CustomerType { get; set; }

  }
}
