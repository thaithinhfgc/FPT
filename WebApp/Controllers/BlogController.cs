using Data;
using Data.DTO.BlogDTO;
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
    [Authorize]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;

        public BlogController(IBlogService blogService, IUserService userService, ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.userService = userService;
            this.categoryService = categoryService;
        }

        [HttpPost]
        [Route("draft")]
        public IActionResult CreateDraft()
        {
            var res = new ServerResponse<Blog>();
            var categories = categoryService.GetCategories();
            var student = userService.GetUserById(userService.GetCurrentUser().Id);
            var draft = new Blog
            {
                Id = Guid.NewGuid().ToString(),
                Title = "New Draft",
                Content = "",
                CategoryId = categories[0].Id,
                Category = categories[0],
                Student = student,
                StudentId = student.Id,
                CreateDate = DateTime.Now,
                Status = BlogStatus.DRAFT
            };

            blogService.CreateDraft(draft);
            res.data = draft;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("drafts")]
        public IActionResult GetAllDraft()
        {
            var res = new ServerResponse<List<Blog>>();
            var draft = blogService.GetDrafts();
            res.data = draft;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("draft/edit")]
        public IActionResult EditBlog([FromBody] EditDraftDTO input)
        {
            var res = new ServerResponse<Blog>();
            ValidationResult result = new EditDraftDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var draft = blogService.GetDraft(input.Id);
            if (draft == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Draft");
                return new NotFoundObjectResult(res.getResponse());
            }

            var category = categoryService.GetCategoryById(input.CategoryId);
            if (category == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Category");
                return new NotFoundObjectResult(res.getResponse());
            }

            draft.Title = input.Title;
            draft.Content = input.content;
            draft.Category = category;
            draft.CategoryId = category.Id;

            blogService.SaveDraft(draft);
            res.data = draft;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        [Route("draft")]
        public IActionResult DeleteDraft([FromBody] DeleteDraftDTO input)
        {
            var res = new ServerResponse<Blog>();
            ValidationResult result = new DeleteDraftDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var draft = blogService.GetDraft(input.Id);
            if (draft == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Draft");
                return new NotFoundObjectResult(res.getResponse());
            }
            blogService.DeleteDraft(draft);
            res.data = draft;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_DELETE_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Route("draft/submit")]
        public IActionResult SubmitDraft([FromBody] SubmitDraftDTO input)
        {
            var res = new ServerResponse<Blog>();
            ValidationResult result = new SubmitDraftDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var draft = blogService.GetDraft(input.Id);
            if (draft == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Draft");
                return new NotFoundObjectResult(res.getResponse());
            }

            draft.Status = BlogStatus.WAIT;
            res.data = draft;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS);
            return new ObjectResult(res.getResponse());
        }
    }
}