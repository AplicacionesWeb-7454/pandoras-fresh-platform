using System.Net.Mime;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands; // ADD THIS USING
using PandorasFreshPlatform.API.Inventory.Domain.Services;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects; // ADD THIS USING
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/inventories/{inventoryId:int}/storage-boxes")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Inventories")]
public class InventoryStorageBoxesController(
    IStorageBoxCommandService storageBoxCommandService,
    IStorageBoxQueryService storageBoxQueryService) : ControllerBase
{
    /// <summary>
    /// Get all storage boxes by inventory id
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <returns>
    /// The list of <see cref="StorageBoxResource" /> storage boxes
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all storage boxes by inventory id",
        Description = "Get all storage boxes by inventory id",
        OperationId = "GetStorageBoxesByInventoryId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of storage boxes", typeof(IEnumerable<StorageBoxResource>))]
    public async Task<IActionResult> GetStorageBoxesByInventoryId(int inventoryId)
    {
        // Convert primitive int to InventoryItemId value object
        var getStorageBoxesByInventoryQuery = new GetStorageBoxesByInventoryQuery(new InventoryItemId(inventoryId));
        var storageBoxes = await storageBoxQueryService.Handle(getStorageBoxesByInventoryQuery);
        var storageBoxResources = storageBoxes.Select(StorageBoxResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(storageBoxResources);
    }

    /// <summary>
    /// Create a storage box in an inventory
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="resource">
    /// The <see cref="CreateStorageBoxResource" /> with the storage box data to create
    /// </param>
    /// <returns>
    /// The <see cref="StorageBoxResource" /> with the storage box created if successful, otherwise it returns a response with
    /// <see cref="BadRequestResult" />
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a storage box in an inventory",
        Description = "Create a storage box in an inventory",
        OperationId = "CreateStorageBox")]
    [SwaggerResponse(StatusCodes.Status201Created, "The storage box was created", typeof(StorageBoxResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The storage box was not created")]
    public async Task<IActionResult> CreateStorageBox(int inventoryId, [FromBody] CreateStorageBoxResource resource)
    {
        // Convert primitive int to InventoryItemId value object
        var createStorageBoxCommand = CreateStorageBoxCommandFromResourceAssembler.ToCommandFromResource(resource, new InventoryItemId(inventoryId));
        var storageBox = await storageBoxCommandService.Handle(createStorageBoxCommand);
        if (storageBox is null) return BadRequest();
        var storageBoxResource = StorageBoxResourceFromEntityAssembler.ToResourceFromEntity(storageBox);
        return CreatedAtAction(nameof(GetStorageBoxById), new { inventoryId, storageBoxId = storageBox.Id }, storageBoxResource);
    }

    /// <summary>
    /// Get a storage box by its id
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id
    /// </param>
    /// <returns>
    /// The <see cref="StorageBoxResource" /> with the storage box if found, otherwise it returns a response with
    /// <see cref="NotFoundResult" />
    /// </returns>
    [HttpGet("{storageBoxId:int}")]
    [SwaggerOperation(
        Summary = "Get a storage box by its id",
        Description = "Get a storage box by its id",
        OperationId = "GetStorageBoxById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The storage box was found", typeof(StorageBoxResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The storage box was not found")]
    public async Task<IActionResult> GetStorageBoxById(int inventoryId, int storageBoxId)
    {
        // Convert primitive int to StorageBoxId value object
        var getStorageBoxByIdQuery = new GetStorageBoxByIdQuery(new StorageBoxId(storageBoxId));
        var storageBox = await storageBoxQueryService.Handle(getStorageBoxByIdQuery);
        if (storageBox is null) return NotFound();
        var storageBoxResource = StorageBoxResourceFromEntityAssembler.ToResourceFromEntity(storageBox);
        return Ok(storageBoxResource);
    }

    /// <summary>
    /// Update a storage box
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id
    /// </param>
    /// <param name="resource">
    /// The <see cref="UpdateStorageBoxResource" /> with the storage box data to update
    /// </param>
    /// <returns>
    /// The <see cref="StorageBoxResource" /> with the storage box updated if successful, otherwise it returns a response with
    /// <see cref="BadRequestResult" />
    /// </returns>
    [HttpPut("{storageBoxId:int}")]
    [SwaggerOperation(
        Summary = "Update a storage box",
        Description = "Update a storage box",
        OperationId = "UpdateStorageBox")]
    [SwaggerResponse(StatusCodes.Status200OK, "The storage box was updated", typeof(StorageBoxResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The storage box was not updated")]
    public async Task<IActionResult> UpdateStorageBox(int inventoryId, int storageBoxId, [FromBody] UpdateStorageBoxResource resource)
    {
        // Convert primitive int to StorageBoxId value object
        var updateStorageBoxCommand = UpdateStorageBoxCommandFromResourceAssembler.ToCommandFromResource(resource, new StorageBoxId(storageBoxId));
        var storageBox = await storageBoxCommandService.Handle(updateStorageBoxCommand);
        if (storageBox is null) return BadRequest();
        var storageBoxResource = StorageBoxResourceFromEntityAssembler.ToResourceFromEntity(storageBox);
        return Ok(storageBoxResource);
    }

    /// <summary>
    /// Delete a storage box
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id
    /// </param>
    /// <returns>
    /// No content if successful, otherwise it returns a response with <see cref="BadRequestResult" />
    /// </returns>
    [HttpDelete("{storageBoxId:int}")]
    [SwaggerOperation(
        Summary = "Delete a storage box",
        Description = "Delete a storage box",
        OperationId = "DeleteStorageBox")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The storage box was deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The storage box was not deleted")]
    public async Task<IActionResult> DeleteStorageBox(int inventoryId, int storageBoxId)
    {
        // Convert primitive int to StorageBoxId value object
        var deleteStorageBoxCommand = new DeleteStorageBoxCommand(new StorageBoxId(storageBoxId));
        var result = await storageBoxCommandService.Handle(deleteStorageBoxCommand);
        if (!result) return BadRequest();
        return NoContent();
    }

    /// <summary>
    /// Get storage box content
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id
    /// </param>
    /// <returns>
    /// The list of product instances in the storage box
    /// </returns>
    [HttpGet("{storageBoxId:int}/content")]
    [SwaggerOperation(
        Summary = "Get storage box content",
        Description = "Get storage box content",
        OperationId = "GetStorageBoxContent")]
    [SwaggerResponse(StatusCodes.Status200OK, "The storage box content was found", typeof(IEnumerable<object>))]
    public async Task<IActionResult> GetStorageBoxContent(int inventoryId, int storageBoxId)
    {
        // Convert primitive int to StorageBoxId value object
        var getStorageBoxContentQuery = new GetStorageBoxContentQuery(new StorageBoxId(storageBoxId));
        var content = await storageBoxQueryService.Handle(getStorageBoxContentQuery);
        return Ok(content);
    }

    /// <summary>
    /// Get product types in storage box
    /// </summary>
    /// <param name="inventoryId">
    /// The inventory id
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id
    /// </param>
    /// <returns>
    /// The list of product types in the storage box
    /// </returns>
    [HttpGet("{storageBoxId:int}/product-types")]
    [SwaggerOperation(
        Summary = "Get product types in storage box",
        Description = "Get product types in storage box",
        OperationId = "GetProductTypesInStorageBox")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product types were found", typeof(IEnumerable<object>))]
    public async Task<IActionResult> GetProductTypesInStorageBox(int inventoryId, int storageBoxId)
    {
        // Convert primitive int to StorageBoxId value object
        var getProductTypesInStorageBoxQuery = new GetProductTypesInStorageBoxQuery(new StorageBoxId(storageBoxId));
        var productTypes = await storageBoxQueryService.Handle(getProductTypesInStorageBoxQuery);
        return Ok(productTypes);
    }
}