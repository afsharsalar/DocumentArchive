using DocumentArchive.Domain.CustomerAggregator;

using Microsoft.EntityFrameworkCore;

namespace DocumentArchive.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository(DocumentArchiveDbContext dbContext) : ICustomerRepository
    {
        public void Create(Customer document)
        {
            dbContext.Add(document);
        }

        public void Delete(Customer document)
        {
            dbContext.Remove(document);
        }

        public Task<Customer?> GetById(CustomerId documentId, CancellationToken cancellationToken)
        {
            return dbContext.Customers.SingleOrDefaultAsync(p=>p.Id==documentId,cancellationToken);
        }

        public async Task<IReadOnlyCollection<Customer>> GetPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var customers = await dbContext.Customers
                                      .Skip((page - 1) * pageSize).Take(pageSize)
                                      .ToListAsync(cancellationToken);

            return [.. customers];
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
