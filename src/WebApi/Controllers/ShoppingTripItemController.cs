using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ShoppingTrips.Command.Items.AddItem;
using Application.ShoppingTrips.Command.Items.ChangeItem;
using Application.ShoppingTrips.Command.Items.RemoveItem;
using Application.ShoppingTrips.Query.GetItems;

namespace WebApi.Controllers
{
    [Route("api/user/{uId}/group/{gId}/shoptrip/{sId}/item")]
    public class ShoppingTripItemController : BaseController
    {
        public ShoppingTripItemController(IMediator mediator) : base(mediator) {}

        /// <summary>
        /// As a member add an item to a shopping trip you hava access to
        /// </summary>
        /// <response code="201">The id of the added item</response>
        [HttpPost]
        public async Task<ActionResult<int>> AddItem(int uId, int gId, int sId, AddItemCommand addItemCommand)
        {
            addItemCommand.Finalize(uId, gId, sId);

            var shoppingTripItemId = await _mediator.Send(addItemCommand);
            return shoppingTripItemId;
        }
        
        /// <summary>
        /// As the creator of a shopping trip item, remove it
        /// </summary>
        [HttpDelete("{itId}")]
        public async Task<IActionResult> RemoveItem(int uId, int gId, int sId, int itId)
        {
            var removeItemCommand = new RemoveItemCommand(itId, uId, gId, sId);

            await _mediator.Send(removeItemCommand);
            return Ok();
        }
        
        /// <summary>
        /// As the creator of a shopping trip item, change it
        /// </summary>
        [HttpPut("{itId}")]
        public async Task<IActionResult> ChangeItem(int uId, int gId, int sId, int itId, ChangeItemCommand changeItemCommand)
        {
            changeItemCommand.Finalize(uId, gId, sId, itId);

            await _mediator.Send(changeItemCommand);
            return Ok();
        }

        /// <summary>
        /// As a member, retrieve all planned shopping trips in a group
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<ItemEntryModel>>> GetItems(int uId, int gId, int sId)
        {
            var getShoppingTripsCommand = new GetItemsCommand(uId, gId, sId);
            
            return await _mediator.Send(getShoppingTripsCommand);
        }

    }
}
