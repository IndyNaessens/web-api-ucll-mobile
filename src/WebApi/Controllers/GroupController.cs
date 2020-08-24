using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Groups.Command.ChangeGroupName;
using Application.Groups.Command.CreateGroup;
using Application.Groups.Command.JoinGroup;
using Application.Groups.Command.LeaveGroup;
using Application.Groups.Command.RefreshInviteCode;
using Application.Groups.Query.GetGroup;
using Application.Users.Query.GetJoinedGroups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user/{uId}/group")]
    public class GroupController : BaseController
    {
        public GroupController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// As an authenticated user, create a new group
        /// </summary>
        /// <response code="201">The id of the created group</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> CreateGroup(int uId, CreateGroupCommand createGroupCommand)
        {
            createGroupCommand.Finalize(uId);
            
            var gId = await _mediator.Send(createGroupCommand);
            return CreatedAtAction(nameof(CreateGroup), gId);
        }

        /// <summary>
        /// As a member, retrieve details about a group
        /// </summary>
        [HttpGet("{gId}")]
        public async Task<ActionResult<GroupModel>> GetGroup(int uId, int gId)
        {
            var getGroupCommand = new GetGroupCommand(uId,gId);

            return await _mediator.Send(getGroupCommand);
        }
        
        /// <summary>
        /// As an administrator, change the group name
        /// </summary>
        [HttpPut("{gId}/name")]
        public async Task<IActionResult> ChangeGroupName(int uId, int gId, ChangeGroupNameCommand changeGroupNameCommand)
        {
            changeGroupNameCommand.Finalize(uId, gId);
            
            await _mediator.Send(changeGroupNameCommand);
            return Ok();
        }

        /// <summary>
        /// As an authenticated user, join a group with an invite code
        /// </summary>
        [HttpPut("join")]
        public async Task<IActionResult> JoinGroup(int uId, JoinGroupCommand joinGroupCommand)
        {
            joinGroupCommand.Finalize(uId);
            
            await _mediator.Send(joinGroupCommand);
            return Ok();
        } 
        
        /// <summary>
        /// As a member of a group, leave that group
        /// </summary>
        [HttpDelete("{gId}/leave")]
        public async Task<IActionResult> LeaveGroup(int uId, int gId)
        {
            var leaveGroupCommand = new LeaveGroupCommand(uId, gId);
            
            await _mediator.Send(leaveGroupCommand);
            return Ok();
        } 
        
        /// <summary>
        /// As an admin, refresh the invite code
        /// </summary>
        /// <response code="200">The refreshed invite code</response>
        [HttpPut("{gId}/inviteCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> RefreshInviteCode(int uId, int gId)
        {
            var refreshInviteCodeCommand = new RefreshInviteCodeCommand(uId, gId);
            
            var inviteCode = await _mediator.Send(refreshInviteCodeCommand);
            return inviteCode;
        }
        
        /// <summary>
        /// As an authenticated user, get all your groups
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<JoinedGroupsModel>>> GetJoinedGroups(int uId)
        {
            var getJoinedGroupsCommand = new GetJoinedGroupsCommand(uId);
            return await _mediator.Send(getJoinedGroupsCommand);
        }
    }
}