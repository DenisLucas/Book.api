using System.Threading.Tasks;
using firstTUT.Contract.V1;
using firstTUT.Contract.V1.VModels;
using firstTUT.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace firstTUT.Controllers.V1
{
    public class UserAuthController : Controller
    {
        private readonly IUserAuthServices _userAuthServices;
        public UserAuthController(IUserAuthServices userAuthServices){
            _userAuthServices = userAuthServices;
        }

        [HttpPost(template: ApiRoutes.User.Register)]
        public async Task<IActionResult> RegisterUser([FromBody] VmUserAuth user)
        {
            var authResponse = await _userAuthServices.RegisterUserAsync(user.Username,user.Email,user.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new VmRegistrationFailure()
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok( new VmRegistrationSuccess()
            {
                Token = authResponse.Token
            });
        }

    }
}