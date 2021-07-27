using System.Threading.Tasks;
using firstTUT.Contract.V1.VModels;
using firstTUT.Domain;

namespace firstTUT.Data.Services
{
    public interface IUserAuthServices
    {
        Task<AuthUserResponse> RegisterUserAsync(string user,string email, string Passworld);
        Task<AuthUserResponse> LoginUserAsync(string username, string email, string password);
    }
}