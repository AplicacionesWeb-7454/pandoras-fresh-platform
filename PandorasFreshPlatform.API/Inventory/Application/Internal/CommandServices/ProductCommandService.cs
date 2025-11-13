using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Events;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;
using Cortex.Mediator;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.CommandServices;

/// <summary>
/// Represents the product command service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="productRepository">
/// The <see cref="IProductRepository" /> to use.
/// </param>
/// <param name="categoryRepository">
/// The <see cref="ICategoryRepository" /> to use.
/// </param>
/// <param name="unitOfWork">
/// The <see cref="IUnitOfWork" /> to use.
/// </param>
/// <param name="domainEventPublisher">
/// The <see cref="IMediator" /> to use for publishing domain events.
/// </param>
public class ProductCommandService(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher)
    : IProductCommandService
{
    /// <inheritdoc />
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        // Extract primitive value from CategoryId value object
        var category = await categoryRepository.FindByIdAsync(command.CategoryId.Value);
        if (category is null) throw new Exception("Category not found");
        
        if (await productRepository.ExistsByNameAsync(command.Name))
            throw new Exception("Product with the same name already exists");

        var product = new Product(command);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product is created
        await domainEventPublisher.PublishAsync(new ProductCreatedEvent(
            product.Name, 
            product.Barcode.Code, 
            product.GetCategoryId())); // Use GetCategoryId() method to get the value object
        
        return product;
    }

    /// <inheritdoc />
    public async Task<Product?> Handle(UpdateProductCommand command)
    {
        // Use the repository method that accepts ProductId value object
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product is null) throw new Exception("Product not found");

        // Extract primitive value from CategoryId value object
        var category = await categoryRepository.FindByIdAsync(command.CategoryId.Value);
        if (category is null) throw new Exception("Category not found");

        product.UpdateInformation(
            command.Name, 
            command.Description, 
            new Barcode(command.Barcode), 
            command.CategoryId);
        
        productRepository.Update(product);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product is updated
        await domainEventPublisher.PublishAsync(new ProductUpdatedEvent(
            new ProductId(product.Id), // Convert primitive to value object
            product.Name, 
            product.Barcode.Code, 
            product.GetCategoryId())); // Use GetCategoryId() method
        
        return product;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(DeleteProductCommand command)
    {
        // Use the repository method that accepts ProductId value object
        var product = await productRepository.FindByIdAsync(command.ProductId);
        if (product is null) throw new Exception("Product not found");

        productRepository.Remove(product);
        await unitOfWork.CompleteAsync();
        
        // Publish the domain event after the product is deleted
        await domainEventPublisher.PublishAsync(new ProductDeletedEvent(command.ProductId));
        
        return true;
    }

    /// <inheritdoc />
    public async Task<Product?> Handle(ScanBarcodeCommand command)
    {
        var product = await productRepository.FindByBarcodeAsync(command.Barcode);
        if (product is null) throw new Exception("Product not found for the scanned barcode");

        // Publish the domain event for barcode scan
        await domainEventPublisher.PublishAsync(new BarcodeScannedEvent(command.Barcode, command.DeviceId, DateTime.UtcNow));
        
        return product;
    }
}