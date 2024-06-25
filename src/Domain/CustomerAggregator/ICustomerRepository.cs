using DocumentArchive.Domain.DocumentAggregator;

namespace DocumentArchive.Domain.CustomerAggregator
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetById(CustomerId documentId, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<Customer>> GetPaged(int page, int pageSize, CancellationToken cancellationToken);

        void Create(Customer document);


        void Delete(Customer document);


        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
