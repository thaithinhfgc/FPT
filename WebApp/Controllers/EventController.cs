using Data;
using Data.DTO.EventModule.EventDTO;
using Data.Model.EventModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.EventModule;
using Service.Interface.UserModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;
        private readonly IUserService userService;
        public EventController(IEventService eventService, IUserService userService)
        {
            this.eventService = eventService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetEvent([FromBody] GetEventDTO input)
        {
            var res = new ServerResponse<Event>();

            ValidationResult result = new GetEventDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var @event = eventService.GetEvent(input.EventId);
            if (@event == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Event");
                return new NotFoundObjectResult(res.getResponse());
            }

            res.data = @event;
            return new ObjectResult(res.getResponse());

        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetEvents()
        {
            var res = new ServerResponse<List<Event>>();
            var events = eventService.GetEvents();
            res.data = events;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateEvent([FromBody] CreateEventDTO input)
        {
            var res = new ServerResponse<Event>();

            ValidationResult result = new CreateEventDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (input.EndDate < input.StartDate)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_END_DATE);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (input.StartDate.Date <= DateTime.Now.Date)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_START_DATE);
                return new BadRequestObjectResult(res.getResponse());
            }



            var admin = userService.GetUserById(userService.GetCurrentUser().Id);

            var @event = new Event
            {
                Id = Guid.NewGuid().ToString(),
                Title = input.Title,
                Description = input.Description,
                NumOfPaticipant = input.NumOfPatitcipant,
                CreateDate = DateTime.Now.Date,
                AdminId = admin.Id,
                Admin = admin,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Status = EventStatus.UPCOMING
            };

            eventService.CreateEvent(@event);
            res.data = @event;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Event");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult UpdateEvent([FromBody] UpdateEventDTO input)
        {
            var res = new ServerResponse<Event>();

            ValidationResult result = new UpdateEventDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (input.EndDate < input.StartDate)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_END_DATE);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (input.StartDate.Date <= DateTime.Now.Date)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_START_DATE);
                return new BadRequestObjectResult(res.getResponse());
            }
            var @event = eventService.GetEvent(input.EventId);
            if (@event == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Event");
                return new NotFoundObjectResult(res.getResponse());
            }

            @event.Title = input.Title;
            @event.Description = input.Description;
            @event.StartDate = input.StartDate;
            @event.EndDate = input.EndDate;
            @event.NumOfPaticipant = input.NumOfPatitcipant;

            eventService.UpdateEvent(@event);
            res.data = @event;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Event");
            return new ObjectResult(res.getResponse());
        }


        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CancelEvent([FromBody] CancelEventDTO input)
        {
            var res = new ServerResponse<Event>();

            ValidationResult result = new CancelEventDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }


            var @event = eventService.GetEvent(input.EventId);
            if (@event == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Event");
                return new NotFoundObjectResult(res.getResponse());
            }

            @event.Status = EventStatus.CANCEL;

            eventService.UpdateEvent(@event);
            res.data = @event;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Event");
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchEvent(int pageSize, int pageIndex, string search)
        {
            IDictionary<string, object> dataRes = new Dictionary<string, object>();
            ServerResponse<IDictionary<string, object>> res = new ServerResponse<IDictionary<string, object>>();
            if (search == null)
            {
                search = "";
            }
            var (events, total) = eventService.SearchEvent(pageSize, pageIndex, search);
            dataRes.Add("events", events);
            dataRes.Add("total", total);
            res.data = dataRes;
            return new ObjectResult(res.getResponse());
        }

    }
}