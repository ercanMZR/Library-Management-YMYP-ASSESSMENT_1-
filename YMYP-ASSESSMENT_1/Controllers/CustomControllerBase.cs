using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;
using YMYP_ASSESSMENT_1.Models.Services;

namespace YMYP_ASSESSMENT_1.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult CreateObjectResult<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)serviceResult.Status
                };
            }

            return new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }

        [NonAction]
        public IActionResult CreateObjectResult(ServiceResult serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {

                return new ObjectResult(null)
                {
                    StatusCode = (int)serviceResult.Status
                };

              
            }
            return new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }
    }
}
