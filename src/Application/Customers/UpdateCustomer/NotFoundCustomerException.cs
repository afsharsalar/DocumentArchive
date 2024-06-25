using DocumentArchive.Common.Domain;

namespace DocumentArchive.Application.Customers.UpdateCustomer;

public class NotFoundCustomerException : DomainException
{
    private const string _message = "Category not found.";
    public NotFoundCustomerException() : base(_message)
    {

    }

}
