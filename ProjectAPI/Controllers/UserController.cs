using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Data.Services.IServices;
using Repository.Models.Models;
using Repository.Models.ViewModels;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(IRepositoryWrapper repositoryWrapper, ILogger<UserController> logger, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [Route("getCount")]
        public async Task<IActionResult> GetCount()
        {
            AnalyticsObject analyticsObject = new AnalyticsObject();
            analyticsObject.totalUsersCount = await _repositoryWrapper.userRepository.GetUserCount();
            return Ok(analyticsObject);
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            ResponseListObject<ApplicationUser> response = new ResponseListObject<ApplicationUser>();
            try
            {
                foreach (var item in await _repositoryWrapper.userRepository.GetAll())
                {
                    response.loadData.Add(item);
                }
                response.status = true;
                response.message = "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                response.status = false;
                response.message = "Failure";
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("getUserById")]
        public async Task<IActionResult> GetUserById(string id = null)
        {
            ResponseListObject<ApplicationUser> response = new ResponseListObject<ApplicationUser>();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    response.status = false;
                    response.message = "User Id can't be null";
                }
                else
                {
                    response.status = true;
                    response.message = "Success";
                    response.loadData.Add(await _repositoryWrapper.userRepository.GetById(Guid.Parse(id)));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                response.status = false;
                response.message = "Failure";
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> AddUser(ApplicationUserVM request)
        {
            ResponseObject response = new ResponseObject();
            if (request != null)
            {
                var data = _mapper.Map<ApplicationUser>(request);
                data.id = Guid.NewGuid();
                data.createdDate = DateTime.Now;
                await _repositoryWrapper.userRepository.Add(data);
                _repositoryWrapper.Save();
                response.message = "Success";
                response.status = true;
            }
            else
            {
                response.message = "Failure";
                response.status = false;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUser(ApplicationUserVM request)
        {
            ResponseObject response = new ResponseObject();
            if (request != null)
            {
                var findUser = await _repositoryWrapper.userRepository.GetById(request.id);
                var data = _mapper.Map<ApplicationUserVM, ApplicationUser>(request, findUser);
                data.updatedDate = DateTime.Now;
                data.createdDate = findUser.createdDate;
                data.lastLogin = findUser.lastLogin;
                _repositoryWrapper.userRepository.Update(data);
                _repositoryWrapper.Save();
                response.message = "Success";
                response.status = true;
            }
            else
            {
                response.message = "Failure";
                response.status = false;
            }
            return Ok(response);
        }
    }
}
