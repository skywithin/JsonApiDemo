using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Controllers.Annotations;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Sample.Data.Entities;
using System.Threading;

namespace Sample.Api.Controllers;

[DisableRoutingConvention]
[Route("api/people")]
[Produces("application/vnd.api+json")]
[ApiController]
public class PeopleController : JsonApiQueryController<Person, int>
{
    public PeopleController(
        IJsonApiOptions options, 
        IResourceGraph resourceGraph, 
        ILoggerFactory loggerFactory, 
        IResourceQueryService<Person, int> queryService) 
        : base(
            options, 
            resourceGraph, 
            loggerFactory, 
            queryService)
    {
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync(CancellationToken cancellationToken) =>
        await base.GetAsync(cancellationToken);

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken) =>
        await base.GetAsync(id, cancellationToken);

    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken) =>
        await base.DeleteAsync(id, cancellationToken);
}
