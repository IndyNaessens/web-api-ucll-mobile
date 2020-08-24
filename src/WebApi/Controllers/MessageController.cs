using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Groups.Command.CreateMessage;
using Application.Groups.Query.GetMessages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user/{uId}/group/{gId}/message")]
    public class MessageController : BaseController
    {
        public MessageController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// As a member, send a message to a group
        /// </summary>
        /// <response code="201">The id of the created message</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public async Task<IActionResult> CreateMessage(int uId, int gId, CreateMessageCommand createMessageCommand)
        {
            createMessageCommand.Finalize(uId,gId);
            
            var messageId = await _mediator.Send(createMessageCommand);
            return CreatedAtAction(nameof(CreateMessage), messageId);
        }
        
        /// <summary>
        /// As a member, get all messages from a group
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<MessageModel>>> GetMessages(int uId, int gId)
        {
            var getMessagesCommand = new GetMessagesCommand(uId, gId);
            return await _mediator.Send(getMessagesCommand);
        }
    }
}