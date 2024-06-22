namespace DocumentArchive.Domain.CategoryAggregator;

public interface ICategoryRepository
{
    Task<Category?> GetById(CategoryId categoryId, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Category>> GetPaged(int page, int pageSize, CancellationToken cancellationToken);

    void Create(Category category);

    void Update(Category category);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
