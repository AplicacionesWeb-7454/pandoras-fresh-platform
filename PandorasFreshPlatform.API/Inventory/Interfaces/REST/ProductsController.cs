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

/// <summary>
/// The products controller
/// </summary>
/// <param name="productCommandService">
/// The <see cref="IProductCommandService" /> instance to execute commands on products
/// </param>
/// <param name="productQueryService">
/// The <see cref="IProductQueryService" /> instance to query products
/// </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Product endpoints")]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService) : ControllerBase
{
    /// <summary>
    /// Get a product by its id
    /// </summary>
    /// <param name="productId">
    /// The product id
    /// </param>
    /// <returns>
    /// The <see cref="ProductResource" /> with the product if found, otherwise it returns a response with
    /// <see cref="NotFoundResult" />
    /// </returns>
    [HttpGet("{productId:int}")]
    [SwaggerOperation(
        Summary = "Get a product by its id",
        Description = "Get a product by its id",
        OperationId = "GetProductById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was found", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<IActionResult> GetProductById([FromRoute] int productId)
    {
        // Convert primitive int to ProductId value object
        var getProductByIdQuery = new GetProductByIdQuery(new ProductId(productId));
        var product = await productQueryService.Handle(getProductByIdQuery);
        if (product is null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }

    /// <summary>
    /// Create a product
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateProductResource" /> with the product data to create
    /// </param>
    /// <returns>
    /// The <see cref="ProductResource" /> with the product created if successful, otherwise it returns a response with
    /// <see cref="BadRequestResult" />
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a product",
        Description = "Create a product",
        OperationId = "CreateProduct")]
    [SwaggerResponse(StatusCodes.Status201Created, "The product was created", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The product was not created")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, productResource);
    }

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns>
    /// The list of <see cref="ProductResource" /> products
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all products",
        Description = "Get all products",
        OperationId = "GetAllProducts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The products were found", typeof(IEnumerable<ProductResource>))]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await productQueryService.Handle(getAllProductsQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }

    /// <summary>
    /// Update a product
    /// </summary>
    /// <param name="productId">
    /// The product id
    /// </param>
    /// <param name="resource">
    /// The <see cref="UpdateProductResource" /> with the product data to update
    /// </param>
    /// <returns>
    /// The <see cref="ProductResource" /> with the product updated if successful, otherwise it returns a response with
    /// <see cref="BadRequestResult" />
    /// </returns>
    [HttpPut("{productId:int}")]
    [SwaggerOperation(
        Summary = "Update a product",
        Description = "Update a product",
        OperationId = "UpdateProduct")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was updated", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The product was not updated")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] UpdateProductResource resource)
    {
        // Convert primitive int to ProductId value object
        var updateProductCommand = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(resource, new ProductId(productId));
        var product = await productCommandService.Handle(updateProductCommand);
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }

    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="productId">
    /// The product id
    /// </param>
    /// <returns>
    /// No content if successful, otherwise it returns a response with <see cref="BadRequestResult" />
    /// </returns>
    [HttpDelete("{productId:int}")]
    [SwaggerOperation(
        Summary = "Delete a product",
        Description = "Delete a product",
        OperationId = "DeleteProduct")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The product was deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The product was not deleted")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
    {
        // Convert primitive int to ProductId value object
        var deleteProductCommand = new DeleteProductCommand(new ProductId(productId));
        var result = await productCommandService.Handle(deleteProductCommand);
        if (!result) return BadRequest();
        return NoContent();
    }

    /// <summary>
    /// Get products by category
    /// </summary>
    /// <param name="categoryId">
    /// The category id
    /// </param>
    /// <returns>
    /// The list of <see cref="ProductResource" /> products in the category
    /// </returns>
    [HttpGet("categories/{categoryId:int}")]
    [SwaggerOperation(
        Summary = "Get products by category",
        Description = "Get products by category",
        OperationId = "GetProductsByCategory")]
    [SwaggerResponse(StatusCodes.Status200OK, "The products were found", typeof(IEnumerable<ProductResource>))]
    public async Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
    {
        // Convert primitive int to CategoryId value object
        var getProductsByCategoryQuery = new GetProductsByCategoryQuery(new CategoryId(categoryId));
        var products = await productQueryService.Handle(getProductsByCategoryQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }

    /// <summary>
    /// Search products
    /// </summary>
    /// <param name="searchTerm">
    /// The search term
    /// </param>
    /// <returns>
    /// The list of <see cref="ProductResource" /> products matching the search term
    /// </returns>
    [HttpGet("search")]
    [SwaggerOperation(
        Summary = "Search products",
        Description = "Search products",
        OperationId = "SearchProducts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The products were found", typeof(IEnumerable<ProductResource>))]
    public async Task<IActionResult> SearchProducts([FromQuery] string searchTerm)
    {
        var searchProductsQuery = new SearchProductsQuery(searchTerm);
        var products = await productQueryService.Handle(searchProductsQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }

    /// <summary>
    /// Scan a barcode
    /// </summary>
    /// <param name="resource">
    /// The <see cref="ScanBarcodeResource" /> with the barcode data
    /// </param>
    /// <returns>
    /// The <see cref="ProductResource" /> with the product if found, otherwise it returns a response with
    /// <see cref="NotFoundResult" />
    /// </returns>
    [HttpPost("scan")]
    [SwaggerOperation(
        Summary = "Scan a barcode",
        Description = "Scan a barcode",
        OperationId = "ScanBarcode")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was found", typeof(ProductResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<IActionResult> ScanBarcode([FromBody] ScanBarcodeResource resource)
    {
        // Create the command directly since the assembler is empty
        var scanBarcodeCommand = new ScanBarcodeCommand(resource.Barcode, resource.DeviceId);
        var product = await productCommandService.Handle(scanBarcodeCommand);
        if (product is null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
}