using Microsoft.AspNetCore.Mvc;

namespace ConfigBroker.Server.Controllers.ApiV1;

public class PingController : BaseApiV1Controller
{
    public ActionResult Get()
    {
        return Ok("Pong");
    }
}