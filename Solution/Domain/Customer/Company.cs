using Domain.Common;
using Domain.Customer.Common;
using Domain.Utility;

namespace Domain.Customer;

public class Company : ICustomer, IEntity
{
    public int Id { get; set; }
    public CustomerType CustomerType { get; set; }
    public string FantasyName { get; set; }
    public string LegalName { get; set; }
    public string Cnpj { get; set; }
    public string StateRegistration { get; set; }
    public bool IsActive { get; set; }
    
    public virtual IEnumerable<Complement>? Complements { get; set; }
}