using Domain.Utility;

namespace Domain.Customer.Common;

public interface ICustomer
{
    CustomerType CustomerType { get; set; }
}