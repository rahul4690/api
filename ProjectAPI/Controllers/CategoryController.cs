using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Filters;
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
        private readonly IMapper _mapper;

        public CategoryController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getCategoryById")]
        public async Task<IActionResult> getCategoryById([FromQuery] string id)
        {
            ResponseListObject<CategoryModel> response = new ResponseListObject<CategoryModel>();
            try
            {
                var find = await _repositoryWrapper.categoryRepository.GetAll(x => x.categoryCode.ToLower().Equals(id.ToLower()));
                if (find.Count() > 0)
                {
                    foreach (var item in find)
                    {
                        response.data.Add(item);
                        response.status = true;
                        response.message = "Success";
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
                response.message = "Error: " + ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("getCategories")]
        public async Task<IActionResult> GetCategory([FromQuery] PaginationVM pagination)
        {
            ResponseListObject<CategoryModel> response = new ResponseListObject<CategoryModel>();
            foreach (var item in await _repositoryWrapper.categoryRepository.GetAll(null, null, pagination))
            {
                response.data.Add(item);
                response.status = true;
                response.message = "Success";
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [Route("addCategory")]
        public async Task<ActionResult> AddCategory(CategoryModel request)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (request != null && !string.IsNullOrEmpty(request.categoryCode) && !string.IsNullOrEmpty(request.categoryName))
                {
                    request.isActive = true;
                    request.createdDate = DateTime.Now;
                    await _repositoryWrapper.categoryRepository.Add(request);
                    _repositoryWrapper.Save();
                    response.status = true;
                    response.message = "Success";
                }
                else
                {
                    response.status = false;
                    response.message = "Failure";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Error: " + ex;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("updateCategory")]
        public async Task<ActionResult> UpdateCategory(CategoryModel request)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (request != null)
                {
                    var find = await _repositoryWrapper.categoryRepository.GetAll(x => x.categoryCode == request.categoryCode);
                    find.FirstOrDefault().categoryCode = !string.IsNullOrEmpty(request.categoryCode) ? request.categoryCode : find.FirstOrDefault().categoryCode;
                    find.FirstOrDefault().categoryName =!string.IsNullOrEmpty(request.categoryName)? request.categoryName: find.FirstOrDefault().categoryName;
                    find.FirstOrDefault().categoryImage = !string.IsNullOrEmpty(request.categoryImage) ? request.categoryImage : find.FirstOrDefault().categoryImage;
                    find.FirstOrDefault().isActive = request.isActive;
                    _repositoryWrapper.categoryRepository.Update(find.FirstOrDefault());
                    _repositoryWrapper.Save();
                    response.status = true;
                    response.message = "Success";
                }
                else
                {
                    response.status = false;
                    response.message = "Failure";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Error: " + ex;
            }
            return Ok(response);
        }


    }
}
