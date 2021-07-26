using firstTUT.Contract.V1;
using firstTUT.Data.Models.VModels;
using firstTUT.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace firstTUT.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookServices _BookServices;

        public BookController(IBookServices bookServices)
        {
            _BookServices = bookServices;
        }

        [HttpPost(ApiRoutes.Books.AddBook)]
        public async Task<IActionResult> AddBook([FromBody] VmBook book)
        {
            await _BookServices.AddBook(book);
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationuri = BaseUrl + "/" + ApiRoutes.Books.Get.Replace("{id}",book.Title);
            return Created(locationuri,book);
        }
        
        [HttpGet(ApiRoutes.Books.GetAll)]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _BookServices.GetAllBooks());
        }

        [HttpGet(ApiRoutes.Books.GetBookById)]
        public async Task<IActionResult> GetBookById(int id)
        {
            var Book = await _BookServices.GetBookById(id);

            if(Book == null)
            {
                return NotFound();
            }
            
            return Ok(Book);
        }

        [HttpGet(ApiRoutes.Books.GetBookByTitle)]
        public async Task<IActionResult> GetBookBytittle(string title)
        {
            var Book = await _BookServices.GetBookByTitle(title);
            return Ok(Book);
        }

        [HttpPut(ApiRoutes.Books.ChangeBookById)]
        public async Task<IActionResult> ChangeBookById(int id,[FromBody] VmBook book){
            var result = await _BookServices.ChangeBook(id, book);
            if (result)
            {
                return Ok(); 
            }
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Books.DeleteBookById)]
        public async Task<IActionResult> DeleteBookById(int id){
            var result = await _BookServices.DeleteBook(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Books.DeleteAllBooks)]
        public async Task<IActionResult> DeleteAllBooks()
        {
            var result = await _BookServices.DeleteAllBooks();
            if (result) 
            {
                return Ok();
            }
            return NotFound();
        }
   }
}