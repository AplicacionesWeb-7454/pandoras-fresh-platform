using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using Cortex.Mediator;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.CommandServices;

/// <summary>
/// Represents the inventory command service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="inventoryRepository">
/// The <see cref="IInventoryRepository" /> to use.
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWork" /> to use.
/// </param>
/// <param name="domainEventPublisher">
/// The <see cref="IMediator" /> to use for publishing domain events.
/// </param>
public class InventoryCommandService(
    IInventoryRepository inventoryRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher)
    : IInventoryCommandService
{
    /// <inheritdoc />
    public async Task<InventoryItem?> Handle(CreateInventoryCommand command)
    {
        if (await inventoryRepository.FindByNameAsync(command.Name) != null)
            throw new Exception("Inventory with the same name already exists");

        var inventory = new InventoryItem(command);
        await inventoryRepository.AddAsync(inventory);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the inventory is created
        await domainEventPublisher.PublishAsync(new InventoryCreatedEvent(inventory.Name, inventory.Location.Value));
        
        return inventory;
    }

    /// <inheritdoc />
    public async Task<InventoryItem?> Handle(UpdateInventoryCommand command)
    {
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");

        inventory.UpdateInformation(command.Name, command.Description, new Domain.Model.ValueObjects.Location(command.Location));
        inventoryRepository.Update(inventory);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the inventory is updated
        await domainEventPublisher.PublishAsync(new InventoryUpdatedEvent(inventory.Id, inventory.Name, inventory.Location.Value));
        
        return inventory;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(DeleteInventoryCommand command)
    {
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");

        inventoryRepository.Remove(inventory);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the inventory is deleted
        await domainEventPublisher.PublishAsync(new InventoryDeletedEvent(inventory.Id));
        
        return true;
    }
}