using Domain.Common;

namespace Domain.Customer;

public class Person : Customer
{
    public Person()
    {
        CustomerType = Domain.Utility.CustomerType.Person;
    }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
}