using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates; // Add this using
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    /// <inheritdoc />
    public async Task<Category?> FindByNameAsync(string name)
    {
        return await Context.Set<Category>()
            .FirstOrDefaultAsync(c => c.Name == name);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Category>> GetWithProductsAsync()
    {
        // Option 1: Use explicit type specification
        var categoriesWithProductInfo = await Context.Set<Category>()
            .Select(category => new
            {
                Category = category,
                ProductCount = Context.Set<Product>().Count(p => p.CategoryId == category.Id)
            })
            .ToListAsync(); // This now works with explicit anonymous type

        return categoriesWithProductInfo.Select(x => x.Category);
    }
}