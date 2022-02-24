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
    [Authorize]
    public class EventParticipantController : ControllerBase
    {
        private readonly IEventParticipantService eventParticipantService;
        private readonly IEventService eventService;
        private readonly IUserService userService;
        public EventParticipantController(IEventParticipantService eventParticipantService, IEventService eventService, IUserService userService)
        {
            this.eventParticipantService = eventParticipantService;
            this.eventService = eventService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("user")]
        public IActionResult GetEventParticipantByUser()
        {
            var res = new ServerResponse<List<Event>>();
            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);
            var events = eventParticipantService.GetEventParticipantByUser(currentUser.Id);
            res.data = events;
            return new ObjectResult(res.getResponse());

        }
        [HttpPost]
        [Route("")]
        public IActionResult ParticipantEvent([FromBody] ParticipantEventDTO input)
        {
            var res = new ServerResponse<EventParticipant>();
            ValidationResult result = new ParticipantEventDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            var upcomingEvent = eventService.GetUpComingEvents();
            var @event = eventService.GetEvent(input.EventId);
            if (!upcomingEvent.Contains(@event))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Event");
                return new NotFoundObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);
            var eventParticipant = eventParticipantService.GetEventParticipant(currentUser.Id, @event.Id);
            if (eventParticipant != null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "Participant");
                return new NotFoundObjectResult(res.getResponse());
            }
            eventParticipant = new EventParticipant
            {
                Id = Guid.NewGuid().ToString(),
                EventId = input.EventId,
                Event = @event,
                PaticipantId = currentUser.Id,
                Paticipant = currentUser,
                CreateDate = DateTime.Now
            };

            eventParticipantService.PaticipantEvent(eventParticipant);
            res.data = eventParticipant;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Participant");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        [Route("")]
        public IActionResult RemoveParticipant([FromBody] RemoveParticipantDTO input)
        {
            var res = new ServerResponse<EventParticipant>();
            ValidationResult result = new RemoveParticipantDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var upcomingEvent = eventService.GetUpComingEvents();
            var @event = eventService.GetEvent(input.EventId);
            if (!upcomingEvent.Contains(@event))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Event");
                return new NotFoundObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);

            var eventParticipant = eventParticipantService.GetEventParticipant(currentUser.Id, @event.Id);
            if (eventParticipant == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Event Participant");
                return new NotFoundObjectResult(res.getResponse());
            }

            eventParticipantService.RemovePaticipant(eventParticipant);

            res.data = eventParticipant;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_DELETE_SUCCESS, "Participant");
            return new ObjectResult(res.getResponse());
        }
    }
}
