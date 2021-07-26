using System.Threading.Tasks;
using firstTUT.Contract.V1;
using firstTUT.Data.Services;
using firstTUT.Data.VModels;
using Microsoft.AspNetCore.Mvc;

namespace firstTUT.Controllers
{
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public IPublishers _PublisherServices;
        public PublisherController(IPublishers PublisherServices)
        {
            _PublisherServices = PublisherServices;
        }

        [HttpPost(ApiRoutes.Publisher.AddPublisher)]
        public async Task<IActionResult> CreatePublisher([FromBody] VmPublisher Publisher)
        {
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationuri = BaseUrl + "/" + ApiRoutes.Books.Get.Replace("{id}",Publisher.name);
            await _PublisherServices.AddPublisher(Publisher);
            return Created(locationuri,Publisher);
        }

        [HttpGet(ApiRoutes.Publisher.GetPublisher)]
        public async Task<IActionResult> GetPublishers(int id)
        {
            var publisher = await _PublisherServices.GetPublisherBookById(id);
            if(publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }
        
    }
}