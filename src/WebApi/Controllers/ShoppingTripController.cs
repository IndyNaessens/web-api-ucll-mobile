using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Groups.Query.GetShoppingTrips;
using Application.ShoppingTrips.Command.CancelShoppingTrip;
using Application.ShoppingTrips.Command.ChangeShoppingTripInfo;
using Application.ShoppingTrips.Command.ChangeShoppingTripPlanning;
using Application.ShoppingTrips.Command.CreateShoppingTrip;
using Application.ShoppingTrips.Query.GetShoppingTrip;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user/{uId}/group/{gId}/shoptrip")]
    public class ShoppingTripController : BaseController
    {
        public ShoppingTripController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// As a member of a group, create a shopping trip
        /// </summary>
        /// <response code="201">The id of the created shopping trip</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> CreateShoppingTrip(int uId, int gId, CreateShoppingTripCommand createShoppingTripCommand)
        {
            createShoppingTripCommand.Finalize(uId,gId);
            
            return await _mediator.Send(createShoppingTripCommand);
        }
        
        /// <summary>
        /// As the creator of a shopping trip, cancel it
        /// </summary>
        [HttpDelete("{sId}")]
        public async Task<IActionResult> CancelShoppingTrip(int uId, int gId, int sId)
        {
            var cancelShoppingTripCommand = new CancelShoppingTripCommand(uId,gId,sId);
            
            await _mediator.Send(cancelShoppingTripCommand);
            return Ok();
        }
        
        /// <summary>
        /// As the creator of a shopping trip, change it's header information 
        /// </summary>
        [HttpPut("{sId}/header")]
        public async Task<IActionResult> ChangeShoppingTripInfo(int uId, int gId, int sId, ChangeShoppingTripInfoCommand command)
        {
            command.Finalize(uId, gId, sId);
            
            await _mediator.Send(command);
            return Ok();
        }
        
        /// <summary>
        /// As the creator of a shopping trip, change it's planning details 
        /// </summary>
        [HttpPut("{sId}/planning")]
        public async Task<IActionResult> ChangeShoppingTripInfo(int uId, int gId, int sId, ChangeShoppingTripPlanningCommand command)
        {
            command.Finalize(uId, gId, sId);
            
            await _mediator.Send(command);
            return Ok();
        }
        
        /// <summary>
        /// As a member, retrieve all planned shopping trips in a group
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<ShoppingTripEntryModel>>> GetShoppingTrips(int uId, int gId)
        {
            var getShoppingTripsCommand = new GetShoppingTripsCommand(uId, gId);
            
            return await _mediator.Send(getShoppingTripsCommand);
        }
        
        /// <summary>
        /// As a member, retrieve details about a shopping trip
        /// </summary>
        [HttpGet("{sId}")]
        public async Task<ActionResult<ShoppingTripModel>> GetShoppingTrip(int uId, int gId, int sId)
        {
            var getShoppingTripCommand = new GetShoppingTripCommand(uId, gId, sId);
            
            return await _mediator.Send(getShoppingTripCommand);
        }
    }
}