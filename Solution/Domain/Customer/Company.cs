using Domain.Common;
using Domain.Customer.Common;
using Domain.Utility;

namespace Domain.Customer;

public class Company : ICustomer, IEntity
{
    public CustomerType CustomerType { get; set; }
    public int Id { get; set; }
    public string FantasyName { get; set; }
    public string LegalName { get; set; }
    public string Cnpj { get; set; }
    public string StateRegistration { get; set; } // IE  = inscricao estadual
}