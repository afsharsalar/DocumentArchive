using DocumentArchive.Domain.CategoryAggregator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentArchive.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetById(CategoryId categoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Category>> GetPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
