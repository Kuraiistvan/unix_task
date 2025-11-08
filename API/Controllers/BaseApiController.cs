using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatePageResult<T>(IGenericRepository<T> repo, ISpecification<T> spec,
     int pageIndex, int pageSize) where T : BaseEntity
    {
        var items = await repo.GetAllBySpecAsync(spec);
        var itemCount = await repo.CountAsync(spec);

        var pagination = new Pagination<T>(pageIndex, pageSize, itemCount, items);

        return Ok(pagination);
    }
}