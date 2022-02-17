using Data;
using Data.DTO.BlogModule.CommentDTO;
using Data.Model.BlogModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.BlogModule;
using Service.Interface.UserModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IBlogService blogService;
        private readonly IUserService userService;
        public CommentController(ICommentService commentService, IBlogService blogService, IUserService userService)
        {
            this.commentService = commentService;
            this.blogService = blogService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetCommentsFromBlog([FromBody] GetCommentsFromBlogDTO input)
        {
            var res = new ServerResponse<List<Comment>>();

            ValidationResult result = new GetCommentsFromBlogDTOValidator().Validate(input);
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

            var comments = commentService.GetCommentsFromBlog(input.BlogId);
            res.data = comments;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("")]
        public IActionResult PostComment([FromBody] PostCommentDTO input)
        {
            var res = new ServerResponse<Comment>();

            ValidationResult result = new PostCommentDTOValidator().Validate(input);
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

            var comment = new Comment
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = input.BlogId,
                BLog = blog,
                Content = input.Content,

                UserId = currentUser.Id,
                User = currentUser,
                DateCreate = DateTime.Now,
            };

            if (input.ParentCommentId != null)
            {
                var parrentComment = commentService.GetComment(input.ParentCommentId);
                if (parrentComment == null)
                {
                    res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Comment");
                    return new NotFoundObjectResult(res.getResponse());
                }
                else
                {
                    comment.ParentCommentId = input.ParentCommentId;
                    comment.ParentComment = parrentComment;
                }
            }

            commentService.PostComment(comment);
            res.data = comment;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Comment");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateComment([FromBody] UpdateCommentDTO input)
        {

            var res = new ServerResponse<Comment>();

            ValidationResult result = new UpdateCommentDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var comment = commentService.GetComment(input.CommentId);
            if (comment == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Comment");
                return new NotFoundObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);
            if (!comment.UserId.Equals(currentUser.Id))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_ALLOW_ACTION, "Edit Comment");
                return new BadRequestObjectResult(res.getResponse());
            }

            comment.Content = input.Content;

            commentService.UpdateComment(comment);
            res.data = comment;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Comment");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        [Route("")]
        public IActionResult DeleteComment([FromBody] DeleteCommentDTO input)
        {
            var res = new ServerResponse<Comment>();

            ValidationResult result = new DeleteCommentDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var comment = commentService.GetComment(input.CommentId);
            if (comment == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Comment");
                return new NotFoundObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);
            if (!comment.UserId.Equals(currentUser.Id))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_ALLOW_ACTION, "Delete Comment");
                return new BadRequestObjectResult(res.getResponse());
            }

            commentService.DeleteComment(comment);
            res.data = comment;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_DELETE_SUCCESS, "Comment");
            return new ObjectResult(res.getResponse());
        }
    }
}
