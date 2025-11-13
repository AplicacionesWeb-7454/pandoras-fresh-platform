using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using Cortex.Mediator;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.CommandServices;

/// <summary>
/// Represents the storage box command service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="storageBoxRepository">
/// The <see cref="IStorageBoxRepository" /> to use.
/// </param>
/// <param name="inventoryRepository">
/// The <see cref="IInventoryRepository" /> to use.
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWork" /> to use.
/// </param>
/// <param name="domainEventPublisher">
/// The <see cref="IMediator" /> to use for publishing domain events.
/// </param>
public class StorageBoxCommandService(
    IStorageBoxRepository storageBoxRepository,
    IInventoryRepository inventoryRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher)
    : IStorageBoxCommandService
{
    /// <inheritdoc />
    public async Task<StorageBox?> Handle(CreateStorageBoxCommand command)
    {
        // Use the repository method that accepts InventoryItemId value object
        var inventory = await inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");

        // Use the repository method that accepts InventoryItemId value object
        if (await storageBoxRepository.ExistsByLabelInInventoryAsync(command.Label, command.InventoryId))
            throw new Exception("Storage box with the same label already exists in this inventory");

        var storageBox = new StorageBox(command);
        await storageBoxRepository.AddAsync(storageBox);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the storage box is created
        // Use the value objects from the command instead of primitive IDs
        await domainEventPublisher.PublishAsync(new StorageBoxCreatedEvent(
            storageBox.Label, 
            command.InventoryId)); // Use InventoryItemId value object from command
        
        return storageBox;
    }

    /// <inheritdoc />
    public async Task<StorageBox?> Handle(UpdateStorageBoxCommand command)
    {
        // Use the repository method that accepts StorageBoxId value object
        var storageBox = await storageBoxRepository.FindByIdAsync(command.StorageBoxId);
        if (storageBox is null) throw new Exception("Storage box not found");

        storageBox.UpdateInformation(command.Label, 
            new Capacity(command.MaxCapacity, command.CurrentCapacity),
            new StorageConditions(command.TemperatureRange));
        storageBoxRepository.Update(storageBox);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the storage box is updated
        await domainEventPublisher.PublishAsync(new StorageBoxUpdatedEvent(
            command.StorageBoxId, // Use StorageBoxId value object from command
            storageBox.Label));
        
        return storageBox;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(DeleteStorageBoxCommand command)
    {
        // Use the repository method that accepts StorageBoxId value object
        var storageBox = await storageBoxRepository.FindByIdAsync(command.StorageBoxId);
        if (storageBox is null) throw new Exception("Storage box not found");

        storageBoxRepository.Remove(storageBox);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the storage box is deleted
        await domainEventPublisher.PublishAsync(new StorageBoxDeletedEvent(command.StorageBoxId));
        
        return true;
    }
}