using Domain.Common;

namespace Domain.Customer;

public class Company : Customer
{
    public Company()
    {
        this.CustomerType = Domain.Utility.CustomerType.Company;
    }
    public string FantasyName { get; set; }
    public string LegalName { get; set; }
    public string Cnpj { get; set; }
    public string StateRegistration { get; set; }
    public bool IsActive { get; set; }
}