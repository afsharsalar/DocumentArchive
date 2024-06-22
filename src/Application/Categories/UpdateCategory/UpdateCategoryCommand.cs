using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentArchive.Application.Categories.UpdateCategory
{
    public record UpdateCategoryCommand(CategoryId CategoryId, string Title)
    {
    }
}
