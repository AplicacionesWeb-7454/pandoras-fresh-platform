using System.Net.Mime;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST;

/// <summary>
/// The inventories controller
/// </summary>
/// <param name="inventoryCommandService">
/// The <see cref="IInventoryCommandService" /> instance to execute commands on inventories
/// </param>
/// <param name="inventoryQueryService">
/// The <see cref="IInventoryQueryService" /> instance to query inventories
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Inventory endpoints")]
public class InventoriesController(
    IInventoryCommandService inventoryCommandService,
    IInventoryQueryService inventoryQueryService) : ControllerBase
{
    /// <summary>
    /// Get an inventory by its id
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <returns>
    /// The <see cref="InventoryResource" /> with the inventory if found, otherwise it returns a response with
    /// <see cref="NotFoundResult" />
    /// </returns>
    [HttpGet("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Get an inventory by its id",
        Description = "Get an inventory by its id",
        OperationId = "GetInventoryById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventory was found", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The inventory was not found")]
    public async Task<IActionResult> GetInventoryById([FromRoute] int inventoryId)
    {
        // Convert primitive int to InventoryItemId value object
        var getInventoryByIdQuery = new GetInventoryByIdQuery(new InventoryItemId(inventoryId));
        var inventory = await inventoryQueryService.Handle(getInventoryByIdQuery);
        if (inventory is null) return NotFound();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }

    /// <summary>
    /// Create an inventory
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateInventoryResource" /> with the inventory data to create
    /// </param>
    /// <returns>
    /// The <see cref="InventoryResource" /> with the inventory created if successful, otherwise it returns a response with
    /// <see cref="BadRequestResult" />
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create an inventory",
        Description = "Create an inventory",
        OperationId = "CreateInventory")]
    [SwaggerResponse(StatusCodes.Status201Created, "The inventory was created", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The inventory was not created")]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryResource resource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var inventory = await inventoryCommandService.Handle(createInventoryCommand);
        if (inventory is null) return BadRequest();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return CreatedAtAction(nameof(GetInventoryById), new { inventoryId = inventory.Id.Id }, inventoryResource);
    }

    /// <summary>
    /// Get all inventories
    /// </summary>
    /// <returns>
    /// The list of <see cref="InventoryResource" /> inventories
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all inventories",
        Description = "Get all inventories",
        OperationId = "GetAllInventories")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventories were found", typeof(IEnumerable<InventoryResource>))]
    public async Task<IActionResult> GetAllInventories()
    {
        var getAllInventoriesQuery = new GetAllInventoriesQuery();
        var inventories = await inventoryQueryService.Handle(getAllInventoriesQuery);
        var inventoryResources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(inventoryResources);
    }

    /// <summary>
    /// Update an inventory
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="resource">
    /// The <see cref="UpdateInventoryResource" /> with the inventory data to update
    /// </param>
    /// <returns>
    /// The <see cref="InventoryResource" /> with the inventory updated if successful, otherwise it returns a response with
    /// <see cref="BadRequestResult" />
    /// </returns>
    [HttpPut("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Update an inventory",
        Description = "Update an inventory",
        OperationId = "UpdateInventory")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventory was updated", typeof(InventoryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The inventory was not updated")]
    public async Task<IActionResult> UpdateInventory([FromRoute] int inventoryId, [FromBody] UpdateInventoryResource resource)
    {
        // Convert primitive int to InventoryItemId value object
        var updateInventoryCommand = UpdateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource, new InventoryItemId(inventoryId));
        var inventory = await inventoryCommandService.Handle(updateInventoryCommand);
        if (inventory is null) return BadRequest();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }

    /// <summary>
    /// Delete an inventory
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <returns>
    /// No content if successful, otherwise it returns a response with <see cref="BadRequestResult" />
    /// </returns>
    [HttpDelete("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Delete an inventory",
        Description = "Delete an inventory",
        OperationId = "DeleteInventory")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The inventory was deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The inventory was not deleted")]
    public async Task<IActionResult> DeleteInventory([FromRoute] int inventoryId)
    {
        // Convert primitive int to InventoryItemId value object
        var deleteInventoryCommand = new DeleteInventoryCommand(new InventoryItemId(inventoryId));
        var result = await inventoryCommandService.Handle(deleteInventoryCommand);
        if (!result) return BadRequest();
        return NoContent();
    }

    /// <summary>
    /// Get inventory summary
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <returns>
    /// The inventory summary data
    /// </returns>
    [HttpGet("{inventoryId:int}/summary")]
    [SwaggerOperation(
        Summary = "Get inventory summary",
        Description = "Get inventory summary",
        OperationId = "GetInventorySummary")]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventory summary was found", typeof(object))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The inventory was not found")]
    public async Task<IActionResult> GetInventorySummary([FromRoute] int inventoryId)
    {
        // Convert primitive int to InventoryItemId value object
        var getInventorySummaryQuery = new GetInventorySummaryQuery(new InventoryItemId(inventoryId));
        var summary = await inventoryQueryService.Handle(getInventorySummaryQuery);
        return Ok(summary);
    }
}