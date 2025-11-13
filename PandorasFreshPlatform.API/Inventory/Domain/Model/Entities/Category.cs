using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

/// <summary>
/// Represents a category in the Pandora's Fresh Platform
/// </summary>
public class Category
{
    /// <summary>
    /// Default constructor for the category entity
    /// </summary>
    public Category()
    {
        Name = string.Empty;
    }

    /// <summary>
    /// Constructor for the category entity
    /// </summary>
    public Category(string name)
    {
        Name = name;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }

    public int Id { get; set; }  // Own ID as primitive
    public string Name { get; set; }
    
}