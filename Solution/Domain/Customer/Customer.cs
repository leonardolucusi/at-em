using Domain.Common;
using Domain.Utility;

namespace Domain.Customer;

public abstract class Customer : IEntity
{
    public int Id { get; set; }
    public CustomerType CustomerType { get; protected set; }
    public virtual Complement? Complement { get; set; }
}