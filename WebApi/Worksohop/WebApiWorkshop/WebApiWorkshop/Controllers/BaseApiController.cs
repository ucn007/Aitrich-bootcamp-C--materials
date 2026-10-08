using Microsoft.AspNetCore.Mvc;

namespace WebApiWorkshop.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase
    {
    }
}
