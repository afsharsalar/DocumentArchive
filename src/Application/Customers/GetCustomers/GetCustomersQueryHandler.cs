namespace DocumentArchive.Application.Customers.GetCustomers;

public class GetCustomersQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomersQuery, IReadOnlyCollection<GetCustomersQueryResponse>>
{
    public async Task<IReadOnlyCollection<GetCustomersQueryResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetPaged(request.Page,
            request.PageSize, cancellationToken);
        return [.. customers.Select(x => (GetCustomersQueryResponse)x)];
    }
}
