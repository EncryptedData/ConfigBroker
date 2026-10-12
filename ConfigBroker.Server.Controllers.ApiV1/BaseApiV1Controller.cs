using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfigBroker.Server.Controllers.ApiV1;

[Route("/api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public abstract class BaseApiV1Controller : ControllerBase
{
}