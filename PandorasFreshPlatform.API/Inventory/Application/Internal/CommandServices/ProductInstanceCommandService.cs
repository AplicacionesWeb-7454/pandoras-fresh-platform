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
/// Represents the product instance command service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="productInstanceRepository">
/// The <see cref="IProductInstanceRepository" /> to use.
/// </param>
/// <param name="productRepository">
/// The <see cref="IProductRepository" /> to use.
/// </param>
/// <param name="storageBoxRepository">
/// The <see cref="IStorageBoxRepository" /> to use.
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWork" /> to use.
/// </param>
/// <param name="domainEventPublisher">
/// The <see cref="IMediator" /> to use for publishing domain events.
/// </param>
public class ProductInstanceCommandService(
    IProductInstanceRepository productInstanceRepository,
    IProductRepository productRepository,
    IStorageBoxRepository storageBoxRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher)
    : IProductInstanceCommandService
{
    /// <inheritdoc />
    public async Task<ProductInstance?> Handle(AddProductInstanceToStorageBoxCommand command)
    {
        // Use the repository method that accepts ProductId value object
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product is null) throw new Exception("Product not found");

        // Use the repository method that accepts StorageBoxId value object
        var storageBox = await storageBoxRepository.FindByIdAsync(command.StorageBoxId);
        if (storageBox is null) throw new Exception("Storage box not found");

        if (!storageBox.HasAvailableCapacity())
            throw new Exception("Storage box does not have available capacity");

        var productInstance = new ProductInstance(command);
        storageBox.AddProductInstance(productInstance);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product instance is added
        await domainEventPublisher.PublishAsync(new ProductInstanceAddedEvent(
            command.ProductId, // Use the ProductId value object from command
            command.StorageBoxId, // Use the StorageBoxId value object from command
            productInstance.ExpirationDate.Date));
        
        return productInstance;
    }

    /// <inheritdoc />
    public async Task<ProductInstance?> Handle(UpdateProductInstanceCommand command)
    {
        // Use the repository method that accepts ProductInstanceId value object
        var productInstance = await productInstanceRepository.FindByIdAsync(command.ProductInstanceId);
        if (productInstance is null) throw new Exception("Product instance not found");

        // Update logic would go here - for now we'll just update expiration date and batch
        // Note: In a real implementation, you'd have update methods on the ProductInstance entity
        productInstanceRepository.Update(productInstance);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product instance is updated
        await domainEventPublisher.PublishAsync(new ProductInstanceUpdatedEvent(
            command.ProductInstanceId, // Use the ProductInstanceId value object from command
            productInstance.ExpirationDate.Date));
        
        return productInstance;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(RemoveProductInstanceCommand command)
    {
        // Use the repository method that accepts ProductInstanceId value object
        var productInstance = await productInstanceRepository.FindByIdAsync(command.ProductInstanceId);
        if (productInstance is null) throw new Exception("Product instance not found");

        productInstanceRepository.Remove(productInstance);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product instance is removed
        await domainEventPublisher.PublishAsync(new ProductInstanceRemovedEvent(command.ProductInstanceId));
        
        return true;
    }

    /// <inheritdoc />
    public async Task<ProductInstance?> Handle(TransferProductInstanceCommand command)
    {
        // Use the repository method that accepts ProductInstanceId value object
        var productInstance = await productInstanceRepository.FindByIdAsync(command.ProductInstanceId);
        if (productInstance is null) throw new Exception("Product instance not found");

        // Use the repository methods that accept StorageBoxId value objects
        var fromStorageBox = await storageBoxRepository.FindByIdAsync(command.FromStorageBoxId);
        var toStorageBox = await storageBoxRepository.FindByIdAsync(command.ToStorageBoxId);
        
        if (fromStorageBox is null || toStorageBox is null)
            throw new Exception("Source or destination storage box not found");

        if (!toStorageBox.HasAvailableCapacity())
            throw new Exception("Destination storage box does not have available capacity");

        // Remove from source box and add to destination box
        fromStorageBox.RemoveProductInstance(productInstance.InstanceIdentifier);
        toStorageBox.AddProductInstance(productInstance);
        
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product instance is transferred
        await domainEventPublisher.PublishAsync(new ProductInstanceTransferredEvent(
            command.ProductInstanceId, // Use the ProductInstanceId value object from command
            command.FromStorageBoxId, // Use the StorageBoxId value object from command
            command.ToStorageBoxId)); // Use the StorageBoxId value object from command
        
        return productInstance;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> Handle(BatchAddProductInstancesCommand command)
    {
        var results = new List<ProductInstance>();
        // Implementation for batch operations would go here
        await unitOfWork.CompleteAsync();
        return results;
    }
}