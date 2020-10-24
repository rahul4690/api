using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Services.IServices;
using Repository.Models.Models;
using Repository.Models.ViewModels;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CategoryController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        [Route("getCategories")]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _repositoryWrapper.categoryRepository.GetAll());
        }

        [HttpPost]
        [Route("addCategory")]
        public async Task<ActionResult> AddCategory(CategoryModel request)
        {
            await _repositoryWrapper.categoryRepository.Add(request);
            _repositoryWrapper.Save();
            return Ok(true);
        }
    }
}
