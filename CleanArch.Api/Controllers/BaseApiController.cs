using MyProject.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}