using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.APIs.Errors;

namespace ServiceSphere.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] 
    public class ErrorController : ControllerBase
    {
        public ActionResult Error(int code)
        {
            return NotFound(new ApiResponse(404));
        }
    }
}
