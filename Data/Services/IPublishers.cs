using System.Threading.Tasks;
using firstTUT.Data.VModels;

namespace firstTUT.Data.Services
{
    public interface IPublishers
    {
        Task<bool> AddPublisher(VmPublisher publisher);
        Task<VmPublisherBook> GetPublisherBookById(int publicid);    
    }
}