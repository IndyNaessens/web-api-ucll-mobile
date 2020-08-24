using System.Threading.Tasks;
using Application.Users.Command.ChangeUserFullName;
using Application.Users.Command.ChangeUserStatus;
using Application.Users.Command.CreateUser;
using Application.Users.Command.FakeLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }
        
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <response code="201">The id of the created user</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand createUserCommand)
        {
            var userId = await _mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(CreateUser), userId);
        }

        /// <summary>
        /// Fake login
        /// </summary>
        /// <response code="200">The id of the logged in user</response>
        /// <response code="400">Login was not successful</response>
        [HttpPost("fakeLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FakeLogin(FakeLoginCommand fakeLoginCommand)
        {
            var userId = await _mediator.Send(fakeLoginCommand);
            if (userId == 0) 
                return BadRequest("Invalid user password combination");

            return Ok(userId);
        }

        /// <summary>
        /// As an authenticated user, change your full name
        /// </summary>
        [HttpPut("{uId}/name")]
        public async Task<IActionResult> ChangeUserFullName(int uId, ChangeUserFullNameCommand changeUserFullNameCommand)
        {
            changeUserFullNameCommand.Finalize(uId);
            
            await _mediator.Send(changeUserFullNameCommand);
            return Ok();
        }
        
        /// <summary>
        /// As an authenticated user, change your status
        /// </summary>
        [HttpPut("{uId}/status")]
        public async Task<IActionResult> ChangeStatus(int uId, ChangeUserStatusCommand changeUserStatusCommand)
        {
            changeUserStatusCommand.Finalize(uId);
            
            await _mediator.Send(changeUserStatusCommand);
            return Ok();
        }
    }
}