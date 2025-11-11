using System.Runtime.InteropServices.Marshalling;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductParams productParams)
    {
        var spec = new ProductSpecification(productParams);

        return await CreatePageResult(repo, spec, productParams.PageIndex, productParams.PageSize);
    }

    [HttpGet("{id=int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null) return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        repo.Add(product);

        if (await repo.SaveAllAsync())
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);

        return BadRequest("Couldnt create product");
    }

    [HttpPut("{id=int}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (!ProductExist(id) || product.Id != id) return BadRequest("Cannot update product");

        repo.Update(product);

        if (await repo.SaveAllAsync())
            return NoContent();

        return BadRequest("Couldnt update product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        var spec = new BrandListSpecifitcaion();

        return Ok(await repo.GetAllBySpecAsync(spec));
    }
    
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        var spec = new TypeListSpecifitcaion();

        return Ok(await repo.GetAllBySpecAsync(spec));
    }

    private bool ProductExist(int id)
    {
        return repo.Exist(id);
    }

    [HttpDelete("{id=int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await repo.GetByIdAsync(id);

        if (product == null) return NotFound();

        repo.Delete(product);

        if (await repo.SaveAllAsync())
            return NoContent();

        return BadRequest("Couldnt delete product");
    }
}