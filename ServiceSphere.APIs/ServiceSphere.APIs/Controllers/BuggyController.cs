using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.APIs.Errors;
using ServiceSphere.repositery.Data;

namespace ServiceSphere.APIs.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly ServiceSphereContext _serviceSphereContext;

        public BuggyController(ServiceSphereContext serviceSphereContext)
        {
            _serviceSphereContext = serviceSphereContext;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var category = _serviceSphereContext.Categories.Find(1000);
            if (category == null) { return NotFound(new ApiResponse(404)); }
            return Ok(category);
        }
        [HttpGet("Server Error")]
        public ActionResult GetServerError()
        {
            var category = _serviceSphereContext.Categories.Find(100);
            var categoryToReturn = category.ToString();
            //return null reference exception
            return Ok(categoryToReturn);
        }
        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("BadRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}

