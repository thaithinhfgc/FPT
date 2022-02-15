
using Data;
using Data.DTO.BlogTagDTO;
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
    public class BlogTagController : ControllerBase
    {
        private readonly IBlogTagService blogTagService;
        private readonly IBlogService blogService;
        private readonly ITagService tagService;

        public BlogTagController(IBlogTagService blogTagService, IBlogService blogService, ITagService tagService)
        {
            this.blogTagService = blogTagService;
            this.blogService = blogService;
            this.tagService = tagService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetBlogTag([FromBody] GetBlogTagDTO input)
        {
            var res = new ServerResponse<List<Tag>>();
            ValidationResult result = new GetBlogTagDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var tags = blogTagService.GetBlogTags(input.BlogId);
            res.data = tags;
            return new ObjectResult(res.getResponse());

        }

        [HttpPost]
        [Route("")]
        public IActionResult AddTagToBlog([FromBody] AddBlogTagDTO input)
        {
            var res = new ServerResponse<BlogTag>();
            ValidationResult result = new AddBlogTagDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var blog = blogService.GetDraft(input.BlogId);
            if (blog == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Blog");
                return new NotFoundObjectResult(res.getResponse());
            }

            var tag = tagService.GetTagByName(input.TagName);
            if (tag == null)
            {
                tag = new Tag();
                tag.Id = Guid.NewGuid().ToString();
                tag.Name = input.TagName;
                tag.CreatedDate = DateTime.Now;
                tagService.CreateTag(tag);
            }

            var blogTag = new BlogTag
            {
                Id = Guid.NewGuid().ToString(),
                Blog = blog,
                BlogId = input.BlogId,
                Tag = tag,
                TagId = tag.Id,
            };

            blogTagService.AddBlogTag(blogTag);
            res.data = blogTag;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

    }
}
