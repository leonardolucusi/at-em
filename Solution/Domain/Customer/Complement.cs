using Domain.Common;

namespace Domain.Customer;

public class Complement : IEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Address { get; set; }
    public string AddressComplement { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Telephone { get; set; }
    public string Cellphone { get; set; }
    public string Email { get; set; }
    public string ContactName { get; set; }
    public bool IsActive { get; set; }
    public virtual Person? Person { get; set; }
    public virtual Company? Company { get; set; }
}