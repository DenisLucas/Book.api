using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using firstTUT.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace firstTUT.Data.Services
{
    public class UserAuthServices : IUserAuthServices
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly JwtSettings _jwtsettings;
        public UserAuthServices (UserManager<IdentityUser> usermanager, JwtSettings jwtSettings)
        {
            _usermanager = usermanager;
            _jwtsettings = jwtSettings;

        }

        public async Task<AuthUserResponse> LoginUserAsync(string username, string email, string password)
        {
            var User = await _usermanager.FindByEmailAsync(email);

            if (User == null){
                return new AuthUserResponse
                {
                    Errors = new [] {"Login Error"}
                };
            };

            var CheckPassword = await _usermanager.CheckPasswordAsync(User,password);
            if (!CheckPassword) 
            {
                return new AuthUserResponse
                {
                    Errors = new [] {"Login Error"}
                };
            }
            return AuthenticationResultForUser(User);
            
            
        }

        public async Task<AuthUserResponse> RegisterUserAsync(string user, string email, string Password)
        {
            var UserExists = await _usermanager.FindByEmailAsync(email);

            if (UserExists != null){
                return new AuthUserResponse
                {
                    Errors = new [] {"Email Ja registrado"}
                };
            };

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = user
            };

            var CreateUser = await _usermanager.CreateAsync(newUser, Password);

            if (!CreateUser.Succeeded)
            {
                return new AuthUserResponse
                {
                    Errors = CreateUser.Errors.Select(x => x.Description)
                };  
            }
            return AuthenticationResultForUser(newUser);
              
        }

        private AuthUserResponse AuthenticationResultForUser(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new []
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, newUser.UserName),
                    new Claim(type: JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString()),
                    new Claim(type: JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim(type: "id", newUser.Id)

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),algorithm: SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthUserResponse
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }       
    }
}