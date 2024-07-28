using Lojinha.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [ServiceFilter(typeof(ErrorFilter))]
    [ServiceFilter(typeof(ResponseFilter))]

    public class BaseController : ControllerBase
    {
        public BaseController() { }
    }
}