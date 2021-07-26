using System.Threading.Tasks;
using firstTUT.Contract.V1;
using firstTUT.Data.Services;
using firstTUT.Data.VModels;
using Microsoft.AspNetCore.Mvc;

namespace firstTUT.Controllers
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public IAuthorServices _AuthorServices;
        public AuthorController(IAuthorServices AuthorServices)
        {
            _AuthorServices = AuthorServices;
        }

        [HttpPost(ApiRoutes.Author.AddAuthor)]
        public async Task<IActionResult> CreateAuthor([FromBody] VmAuthor author)
        {
            var completed = await _AuthorServices.AddAuthor(author);
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationuri = BaseUrl + "/" + ApiRoutes.Author.Get.Replace("{id}",author.FullName);
            return Created(locationuri,author);

        }

        [HttpGet(ApiRoutes.Author.GetAuthor)]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _AuthorServices.GetAuthorWithBooksById(id);

            if(author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpDelete(ApiRoutes.Author.DeleteAuthor)]
        public async Task<IActionResult> DeleteBookById(int id){
            var result = await _AuthorServices.DeleteAuthor(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}