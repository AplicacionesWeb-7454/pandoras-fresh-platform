using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the product repository in the Pandora's Fresh Platform.
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext" /> to use.
/// </param>
public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    /// <inheritdoc />
    public async Task<Product?> FindByBarcodeAsync(string barcode)
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Barcode.Code == barcode);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> FindByCategoryIdAsync(CategoryId categoryId)
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .Where(p => p.CategoryId.Equals(categoryId))
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await Context.Set<Product>().AnyAsync(p => p.Name == name);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> SearchAsync(string searchTerm)
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToListAsync();
    }

    // Add method for the new Id type
    public async Task<Product?> FindByIdAsync(ProductId id)
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    /// <inheritdoc />
    public new async Task<IEnumerable<Product>> ListAsync()
    {
        return await Context.Set<Product>()
            .Include(p => p.Category)
            .ToListAsync();
    }
}