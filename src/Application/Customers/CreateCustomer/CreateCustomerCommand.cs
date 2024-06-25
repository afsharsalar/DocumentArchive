namespace DocumentArchive.Application.Customers.CreateCustomer;

public record CreateCustomerCommand(
    CustomerType Type,
    string Title,
    Address Address) : IRequest<CreateCustomerCommandResponse>;

