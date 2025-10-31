namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
///     Command to create an Inventory .
/// </summary>
/// <param name="ClientId">
///     The Id of the Client for the Inventory
/// </param>
///
/// <param name="Name">
///     The name of the inventory to create.
/// </param>

public record CreateInventoryCommand(int ClientId, string Name);