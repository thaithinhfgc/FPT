using Data;
using Data.DTO.BlogTagDTO;
using Data.DTO.CategoryDTO;
using Data.Model.BlogModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogTagController : ControllerBase
    {
        private readonly IBlogTagService blogTagService;

        public BlogTagController(IBlogTagService blogTagService)
        {
            this.blogTagService = blogTagService;
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

            var tags = blogTagService.GetBlogTag(input.BlogId);
            res.data = tags;
            return new ObjectResult(res.getResponse());

        }

    }
}
