using Domain.Common;
using Domain.Customer.Common;
using Domain.Utility;

namespace Domain.Customer;

public class Person : ICustomer, IEntity
{
    public CustomerType CustomerType { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
}