using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;

/// <summary>
/// Product aggregate root entity
/// </summary>
public partial class Product
{
    /// <summary>
    /// Default constructor for the product entity
    /// </summary>
    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
        Barcode = new Barcode(string.Empty);
    }

    /// <summary>
    /// Constructor for the product entity
    /// </summary>
    public Product(string name, string description, Barcode barcode, CategoryId categoryId) : this()
    {
        Name = name;
        Description = description;
        Barcode = barcode;
        SetCategoryId(categoryId);
    }

    public Product(CreateProductCommand command) : this(
        command.Name, 
        command.Description, 
        new Barcode(command.Barcode), 
        command.CategoryId)
    {
    }

    public int Id { get; private set; }  // Own ID as primitive
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Barcode Barcode { get; private set; }
    
    // Foreign key as primitive for database mapping
    public int CategoryId { get; private set; }
    
    // Navigation property to Category
    public virtual Category Category { get; private set; }

    /// <summary>
    /// Update product information
    /// </summary>
    public void UpdateInformation(string name, string description, Barcode barcode, CategoryId categoryId)
    {
        Name = name;
        Description = description;
        Barcode = barcode;
        SetCategoryId(categoryId);
    }

    /// <summary>
    /// Sets the category ID from a CategoryId value object
    /// </summary>
    private void SetCategoryId(CategoryId categoryId)
    {
        CategoryId = categoryId.Value;
    }

    /// <summary>
    /// Gets the category ID as a value object (for domain operations)
    /// </summary>
    public CategoryId GetCategoryId() => new CategoryId(CategoryId);
}