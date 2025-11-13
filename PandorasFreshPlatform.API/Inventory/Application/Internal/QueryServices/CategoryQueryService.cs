using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Represents the category query service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="categoryRepository">
/// The <see cref="ICategoryRepository" /> to use.
/// </param>
public class CategoryQueryService(ICategoryRepository categoryRepository)
    : ICategoryQueryService
{
    /// <inheritdoc />
    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        // Extract the primitive value from CategoryId value object
        return await categoryRepository.FindByIdAsync(query.CategoryId.Value);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Category?> Handle(GetCategoryWithProductsQuery query)
    {
        // Extract the primitive value from CategoryId value object
        var category = await categoryRepository.FindByIdAsync(query.CategoryId.Value);
        // In a real implementation, you might have a GetWithProductsAsync method
        return category;
    }
}