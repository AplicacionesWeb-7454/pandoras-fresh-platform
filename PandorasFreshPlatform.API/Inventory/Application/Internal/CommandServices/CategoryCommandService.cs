using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using Cortex.Mediator;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.CommandServices;

/// <summary>
/// Represents the category command service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="categoryRepository">
/// The <see cref="ICategoryRepository" /> to use.
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWork" /> to use.
/// </param>
/// <param name="domainEventPublisher">
/// The <see cref="IMediator" /> to use for publishing domain events.
/// </param>
public class CategoryCommandService(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork,
        IMediator domainEventPublisher)
    : ICategoryCommandService
{
    /// <inheritdoc />
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        if (await categoryRepository.FindByNameAsync(command.Name) != null)
            throw new Exception("Category with the same name already exists");

        var category = new Category(command);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the category is created
        await domainEventPublisher.PublishAsync(new CategoryCreatedEvent(category.Name));
        
        return category;
    }
}