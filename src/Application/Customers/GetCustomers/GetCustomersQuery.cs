using System.Collections.Generic;

namespace DocumentArchive.Application.Customers.GetCustomers;


public record GetCustomersQuery(int Page = 1, int PageSize = 10) : 
    IRequest<IReadOnlyCollection< GetCustomersQueryResponse>>;
