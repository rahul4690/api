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
        public async Task<IActionResult> GetAllRoles()
        {
            ResponseListObject<ApplicationUserRole> response = new ResponseListObject<ApplicationUserRole>();
            try
            {
                foreach(var item in await _repositoryWrapper.roleRepository.GetAll())
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

    }
}
