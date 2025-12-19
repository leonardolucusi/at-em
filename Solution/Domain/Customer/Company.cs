using Domain.Customer.Common;
using Domain.Utility;

namespace Domain.Customer;

public class Company : ICustomer
{
    public CustomerType CustomerType { get; set; }
    public string FantasyName { get; set; }
    public string LegalName { get; set; }
    public string Cnpj { get; set; }
    public string StateRegistration { get; set; } // IE  = inscricao estadual
}