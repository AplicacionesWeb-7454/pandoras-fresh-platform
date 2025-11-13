namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Create category resource for REST API
/// </summary>
/// <param name="Name">
/// The name of the category
/// </param>
public record CreateCategoryResource(string Name);