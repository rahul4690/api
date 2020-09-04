using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository.Data.Services.IServices;
using Repository.Models.Models;
using Repository.Models.ViewModels;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private ILogger<LoginController> _logger;
        private IRepositoryWrapper _repositoryWrapper;

        public LoginController(
            IConfiguration configuration,
            ILogger<LoginController> logger,
            IRepositoryWrapper repositoryWrapper
            )
        {
            _configuration = configuration;
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            string response = string.Empty;
            try
            {
                if (loginVM != null)
                {
                    var verifyUser = await AuthenticateUser(loginVM);
                    if (verifyUser != null && verifyUser.Item1)
                    {
                        response = GenerateJSONWebToken(verifyUser.Item2);
                    }
                    else
                    {
                        response = verifyUser.Item3;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(new { token = response });
        }

        private string GenerateJSONWebToken(LoginVM userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var getKey = _configuration["Jwt:Key"];
            var key = Encoding.ASCII.GetBytes(getKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, userInfo.userName),
                    new Claim(ClaimTypes.Role, userInfo.role)
               }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var createToken = tokenHandler.CreateToken(tokenDescriptor);
            string _token = tokenHandler.WriteToken(createToken);
            return _token;
        }


        private async Task<Tuple<bool, LoginVM, string>> AuthenticateUser(LoginVM loginVM)
        {
            LoginVM response = new LoginVM();
            bool status = false;
            string message = string.Empty;
            var findUser = await _repositoryWrapper.userRepository.GetAll(x => x.email.ToLower() == loginVM.userName.ToLower());
            if (findUser.Count() > 0)
            {
                var verifyPassword = (findUser.FirstOrDefault().password == loginVM.password);
                if (verifyPassword)
                {
                    status = true;
                    response.userName = findUser.FirstOrDefault().email;
                    response.password = findUser.FirstOrDefault().password;
                    var findRoleId = await _repositoryWrapper.roleRepository.GetById(findUser.FirstOrDefault().roleId);
                    response.role = findRoleId.roleName;
                }
                else
                {
                    status = false;
                    message = "Incorrect Password";
                }
            }
            else
            {
                status = false;
                message = "User not found";
            }
            return Tuple.Create(status, response, message);
        }
    }
}
