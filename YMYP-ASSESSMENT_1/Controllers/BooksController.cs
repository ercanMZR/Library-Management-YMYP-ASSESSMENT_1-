using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYP_ASSESSMENT_1.Models.Services;
using YMYP_ASSESSMENT_1.Models.Services.Dtos;

namespace YMYP_ASSESSMENT_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(BookService bookService) : CustomControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            return CreateObjectResult(await bookService.GetAllList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            return CreateObjectResult(await bookService.Get(id));
        }
    }
}
