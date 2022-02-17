using Data;
using Data.DTO.BlogModule.VoteDTO;
using Data.Model.BlogModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.BlogModule;
using Service.Interface.UserModule;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly IBlogService blogService;
        private readonly IUserService userService;
        public VoteController(IVoteService voteService, IBlogService blogService, IUserService userService)
        {
            this.voteService = voteService;
            this.blogService = blogService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("upvote")]
        public IActionResult UpVote([FromBody] VoteDTO input)
        {
            var res = new ServerResponse<Vote>();
            ValidationResult result = new VoteDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            var blog = blogService.GetBlog(input.BlogId);

            if (blog == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Blog");
                return new NotFoundObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);
            var upVote = voteService.UpVote(blog, currentUser);
            res.data = upVote;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Up Vote");
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("downvote")]
        public IActionResult DownVote([FromBody] VoteDTO input)
        {
            var res = new ServerResponse<Vote>();
            ValidationResult result = new VoteDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            var blog = blogService.GetBlog(input.BlogId);

            if (blog == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Blog");
                return new NotFoundObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);
            var downVote = voteService.DownVote(blog, currentUser);
            res.data = downVote;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Down Vote");
            return new ObjectResult(res.getResponse());
        }
    }
}
