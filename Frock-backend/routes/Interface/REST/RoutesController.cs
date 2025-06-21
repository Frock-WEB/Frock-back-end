using Frock_backend.routes.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Frock_backend.routes.Interface.REST.Resources;
using Frock_backend.routes.Interface.REST.Transform;
namespace Frock_backend.routes.Interface.REST
{
    /// <summary>
    /// Routes controller.
    /// </summary>
    /// <param name="routeCommandService">The Route Command Service</param>
    /// <param name="">The Route Query Service</param>
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Routes")]
    public class RoutesController(IRouteCommandService routeCommandService) : ControllerBase
    {
        /// <summary>
        /// Creates a new stop.
        /// </summary>
        /// <param name="resource">The CreateStopResource resource</param>
        /// <returns>
        /// A response as an action result containing the created stop, or bad request if the stop was not created.
        /// </returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new stop.",
            Description = "Creates a new stop with a given parameters",
            OperationId = "CreateStop"
            )]
        [SwaggerResponse(201, "The stop was created", typeof(CreateFullRouteResource))]
        [SwaggerResponse(400, "The stop was not created")]
        public async Task<ActionResult> CreateRoute([FromBody] CreateFullRouteResource resource)
        {
            if (resource == null)
            {
                return BadRequest("Resource cannot be null.");
            }
            var createRouteCommand = CreateFullRouteCommandFromResourceAssembler.toCommandFromResource(resource);
            var result = await routeCommandService.Handle(createRouteCommand);
            if (result is null) return BadRequest();
            return Ok(result);
        }   
    }
}
