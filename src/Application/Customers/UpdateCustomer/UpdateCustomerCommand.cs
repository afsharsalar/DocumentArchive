namespace DocumentArchive.Application.Customers.UpdateCustomer;

public record UpdateCustomerCommand(
    CustomerId CustomerId,
    CustomerType Type,
    string Title,
    Address Address) : IRequest<UpdateCustomerCommandResponse>;

