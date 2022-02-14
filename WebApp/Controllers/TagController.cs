using Data;
using Data.DTO.TagDTO;
using Data.Model.BlogModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetTags()
        {
            var res = new ServerResponse<List<Tag>>();
            List<Tag> tags = tagService.GetAllTags();
            res.data = tags;
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchTag(string search)
        {
            var res = new ServerResponse<List<Tag>>();
            List<Tag> tags = tagService.SearchTags(search);
            res.data = tags;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateTag([FromBody] CreateTagDTO input)
        {

            var res = new ServerResponse<Tag>();
            ValidationResult result = new CreateTagDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            var tag = tagService.GetTagByName(input.Name);
            if (tag != null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "Tag");
                return new BadRequestObjectResult(res.getResponse());
            }
            var newTag = new Tag
            {
                Id = Guid.NewGuid().ToString(),
                Name = input.Name,
                CreatedDate = DateTime.Now
            };

            tagService.CreateTag(newTag);

            res.data = newTag;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Tag");
            return new ObjectResult(res.getResponse());
        }

    }
}
