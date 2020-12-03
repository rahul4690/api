using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> GetAllUsers([FromQuery] PaginationVM pagination)
        {
            ResponseListObject<ApplicationUserVM> response = new ResponseListObject<ApplicationUserVM>();
            try
            {
                foreach (var item in await _repositoryWrapper.userRepository.GetAll(null, x => x.OrderByDescending(x => x.createdDate), pagination))
                {
                    var data = _mapper.Map<ApplicationUserVM>(item);
                    var getRoleName = await _repositoryWrapper.roleRepository.GetById(data.roleId);
                    data.roleName = getRoleName.roleName;
                    response.data.Add(data);
                }
                response.pageSize = pagination.PageSize;
                response.pageNumber = pagination.PageNumber;
                var paginationData = await _repositoryWrapper.userRepository.PaginationHandler(pagination);
                response.totalCount = paginationData.Item1;
                response.totalPages = paginationData.Item2;
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
            ResponseListObject<ApplicationUserModel> response = new ResponseListObject<ApplicationUserModel>();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    response.status = false;
                    response.message = "User Id can't be null";
                }
                else
                {
                    var find = await _repositoryWrapper.userRepository.GetById(Guid.Parse(id));
                    if (find != null)
                    {
                        response.status = true;
                        response.message = "Success";
                        response.data.Add(find);
                    }
                    else
                    {
                        response.status = false;
                        response.message = "User doesn't exist";
                    }
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
        public async Task<IActionResult> AddUser([FromBody] ApplicationUserVM request)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (request != null)
                {
                    var data = _mapper.Map<ApplicationUserModel>(request);
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
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("updateUser")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] ApplicationUserVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(this.ModelState));
            }
            ResponseObject response = new ResponseObject();
            if (request != null)
            {
                var findUser = await _repositoryWrapper.userRepository.GetById(request.id);
                var data = _mapper.Map<ApplicationUserVM, ApplicationUserModel>(request, findUser);
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

        [HttpDelete]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] string id)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                var find = await _repositoryWrapper.userRepository.GetById(Guid.Parse(id));
                if (find != null)
                {
                    _repositoryWrapper.userRepository.Delete(find);
                    _repositoryWrapper.Save();
                    response.message = "Success";
                    response.status = true;
                }
                else
                {
                    response.message = "Failure";
                    response.status = false;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = false;
            }
            return Ok(response);
        }

        [HttpPatch]
        [Route("updateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] ApplicationUserVM request)
        {
            ResponseObject response = new ResponseObject();
            var find = await _repositoryWrapper.userRepository.GetById(request.id);
            if (find != null)
            {
                find.isActive = request.isActive;
                _repositoryWrapper.userRepository.Update(find);
                _repositoryWrapper.Save();
                response.status = true;
                response.message = "Success";
            }
            else
            {
                response.status = false;
                response.message = "Failure";
            }
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("getLoggedInUser")]
        public async Task<IActionResult> GetLoggedInUser()
        {
            ResponseListObject<ApplicationUserVM> response = new ResponseListObject<ApplicationUserVM>();
            try
            {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
                var getUserData = await _repositoryWrapper.userRepository.GetAll(x => x.email == userId);
                if (getUserData.Count() >= 1)
                {
                    foreach (var item in getUserData)
                    {
                        var mapData = _mapper.Map<ApplicationUserVM>(item);
                        var getRoleName = await _repositoryWrapper.roleRepository.GetById(mapData.roleId);
                        mapData.roleName = getRoleName.roleName;
                        response.data.Add(mapData);
                        response.message = "Success";
                        response.status = true;
                    }
                }
                else
                {
                    response.status = false;
                    response.message = "No user found";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("analytics/registeredUser")]
        public async Task<IActionResult> RegisteredUser()
        {
            var fetch = await _repositoryWrapper.userRepository.GetAll();
            Dictionary<string, int> series = new Dictionary<string, int>();

            for (int i = 1; i <= 12; i++)
            {
                var filter = fetch.Where(x => x.createdDate.Month == i);
                series.Add(GetMonth(i), filter.Count());
            }

            return Ok(series);
        }

        private string GetMonth(int month)
        {
            string res = string.Empty;
            switch (month)
            {
                case 1:
                    res = "Jan";
                    break;
                case 2:
                    res = "Feb";
                    break;
                case 3:
                    res = "Mar";
                    break;
                case 4:
                    res = "Apr";
                    break;
                case 5:
                    res = "May";
                    break;
                case 6:
                    res = "Jun";
                    break;
                case 7:
                    res = "Jul";
                    break;
                case 8:
                    res = "Aug";
                    break;
                case 9:
                    res = "Sep";
                    break;
                case 10:
                    res = "Oct";
                    break;
                case 11:
                    res = "Nov";
                    break;
                case 12:
                    res = "Dec";
                    break;
            }
            return res;
        }

    }
}
