using FPCMMS.API.ActionFilters;
using FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Commands.DeleteNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon;
using FPCMMS.Application.Features.NotifyWeapons.Queries.GetAllNotifyWeapons;
using FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifiesListWithNotifyItem;
using FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifyWeaponById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/notifies")]
    [ApiController]
    public class NotifiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotifiesController> _Logger;
        public NotifiesController(IMediator mediator, ILogger<NotifiesController> logger)
        {
            _mediator = mediator;
            _Logger = logger;
        }
        //  [Authorize]
        [HttpGet("all", Name = "GetAllNotifyWeapons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetAllNotifyWeaponsViewModel>>> GetAllStoreItems([FromQuery] GetAllNotifyWeaponsParameter filter)
        {

            var dtos = await _mediator.Send(new GetAllNotifyWeaponsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
            _Logger.LogInformation("Getting list of NotifyWeapons");
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetAllNotifyWeaponsViewModel>>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetNotifyWeaponsByIdQuery { Id = id }));
        }

        [HttpGet("allwithnotifyitems", Name = "GetNotifiesWithNotifyItems")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<NotifyNotifyItemListVm>>> GetNotifiesWithNotifyItems(bool includeHistory)
        {            
            var dtos = await _mediator.Send(new GetNotifesListWithNotifyItemsQuery() { IncludeHistory = includeHistory });
            return Ok(dtos);
        }


        [HttpPost(Name = "AddNotifyWeapon")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(422)]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<CreateNotifyWeaponCommandResponse>> Create([FromBody] CreateNotifyWeaponCommand createNotifyWeaponCommand)
        {
            var response = await _mediator.Send(createNotifyWeaponCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateStoreItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNotifyWeaponCommand updateNotifyWeaponCommand)
        {
            await _mediator.Send(updateNotifyWeaponCommand);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteNotifyWeapon")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteNotifyWeaponCommand = new DeleteNotifyWeaponCommand()
            { Id = id };
            await _mediator.Send(deleteNotifyWeaponCommand);
            return NoContent();

        }
    }
}
