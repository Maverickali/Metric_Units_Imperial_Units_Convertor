using Microsoft.AspNetCore.Mvc;

namespace Imperial_Metric.WebApi.Controllers
{
  
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
       
    }
}
