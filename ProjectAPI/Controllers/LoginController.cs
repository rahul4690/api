using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Data.Services.IServices;
using Repository.Models.ViewModels;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogger<LoginController> _logger;
        private ILoginRepository _loginRepository;

        public LoginController(ILogger<LoginController> logger, ILoginRepository loginRepository)
        {
            _logger = logger;
            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (loginVM != null)
                {
                    var verifyUser = await _loginRepository.AuthenticateUser(loginVM);
                    if (verifyUser != null && verifyUser.Item1)
                    {
                        response.status = verifyUser.Item1;
                        response.message = _loginRepository.GenerateJSONWebToken(verifyUser.Item2);
                    }
                    else
                    {
                        response.status = verifyUser.Item1;
                        response.message = verifyUser.Item3;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword request)
        {
            return Ok(await _loginRepository.changePassword(request));
        }

        [HttpGet]
        [Route("getOtp/{userId}")]
        public async Task<IActionResult> GetOtp(string userId)
        {
            return Ok(await _loginRepository.getOtp(userId));
        }

        [HttpPost]
        [Route("forgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPassword request)
        {
            return Ok(await _loginRepository.forgetPassword(request));
        }

    }
}
