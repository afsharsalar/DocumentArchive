using DocumentArchive.Domain.CategoryAggregator;

using Microsoft.EntityFrameworkCore;

namespace DocumentArchive.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(DocumentArchiveDbContext dbContext) : ICategoryRepository
    {
        public void Create(Category category)
        {
            dbContext.Categories.Add(category);
        }

        public Task<Category?> GetById(CategoryId categoryId, CancellationToken cancellationToken)
        {
            return dbContext.Categories.SingleOrDefaultAsync(p=>p.Id == categoryId,cancellationToken);
        }

        public async Task<IReadOnlyCollection<Category>> GetPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var categories = await dbContext.Categories
                                       .Skip((page - 1) * pageSize).Take(pageSize)
                                       .ToListAsync(cancellationToken);

            return [.. categories];
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
