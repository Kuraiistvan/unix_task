using System.Runtime.InteropServices.Marshalling;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository repo) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
    {
        return Ok(await repo.GetProductsAsync(brand, type, sort));
    }

    [HttpGet("{id=int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetProductAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.AddProduct(product);

        if (await repo.SaveChangesAsync())
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

        return BadRequest("Couldnt create product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
    {
        return Ok(await repo.GetProductBrandsAsync());
    }
    
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
        return Ok(await repo.GetProductTypesAsync());
    }

    [HttpPut("{id=int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (!ProductExist(id) || product.Id != id) return BadRequest("Cannot update product");

        repo.UpdateProduct(product);

        if (await repo.SaveChangesAsync())
            return NoContent();

        return BadRequest("Couldnt update product");
    }

    private bool ProductExist(int id)
    {
        return repo.ProductExist(id);
    }

    [HttpDelete("{id=int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await repo.GetProductAsync(id);

        if (product == null) return NotFound();

        repo.DeleteProduct(product);

        if (await repo.SaveChangesAsync())
            return NoContent();

        return BadRequest("Couldnt delete product");
    }
}