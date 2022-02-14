using Data;
using Data.DTO.CategoryDTO;
using Data.Model.BlogModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet]
        [Route("all")]
        public IActionResult GetCategories()
        {
            var res = new ServerResponse<List<Category>>();
            var categories = categoryService.GetCategories();
            res.data = categories;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("create")]

        public IActionResult CreateCategory([FromBody] CreateCategoryDTO input)
        {
            var res = new ServerResponse<Category>();
            ValidationResult result = new CreateCategoryDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var category = categoryService.GetCategoryByName(input.Name);
            if (category != null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "Category Name");
                return new BadRequestObjectResult(res.getResponse());
            }

            var newCategory = new Category();
            newCategory.Id = Guid.NewGuid().ToString();
            newCategory.Name = input.Name;
            newCategory.Description = input.Description;
            newCategory.Status = CategoryStatus.ENABLE;
            newCategory.CreatedDate = DateTime.Now;

            categoryService.CreateCategory(newCategory);
            res.data = newCategory;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Category");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDTO input)
        {
            var res = new ServerResponse<Category>();
            ValidationResult result = new UpdateCategoryDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var category = categoryService.GetCategoryById(input.Id);
            if (category == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Category");
                return new NotFoundObjectResult(res.getResponse());
            }

            category.Name = input.Name;
            category.Description = input.Description;
            category.Status = input.Status;

            categoryService.UpdateCategory(category);

            res.data = category;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Category");
            return new ObjectResult(res.getResponse());

        }

    }

}
