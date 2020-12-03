using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class UserRoleController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private ILogger<UserRoleController> _logger;
        private readonly IMapper _mapper;

        public UserRoleController(IRepositoryWrapper repositoryWrapper, ILogger<UserRoleController> logger, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllRoles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] PaginationVM pagination)
        {
            ResponseListObject<ApplicationUserRolesVM> response = new ResponseListObject<ApplicationUserRolesVM>();
            try
            {
                foreach(var item in await _repositoryWrapper.roleRepository.GetAll(null, null, pagination))
                {
                    var data = _mapper.Map<ApplicationUserRolesVM>(item);
                    response.data.Add(data);
                }
                response.status = true;
                response.message = "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                response.status = false;
                response.message = "|Messgae: " + ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("addRoles")]
        public async Task<ActionResult> AddRoles(ApplicationUserRolesVM request)
        {
            try
            {
                var data = _mapper.Map<ApplicationUserRoleModel>(request);
                data.id = Guid.NewGuid();
                await _repositoryWrapper.roleRepository.Add(data);
                _repositoryWrapper.Save();
                return Ok(true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
