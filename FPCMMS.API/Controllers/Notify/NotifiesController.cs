using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FPCMMS.Application.Features.Weapon.NotifyComands;
using FPCMMS.Application.Features.Weapon.NotifyQueries;

namespace FPCMMS.WebAPI.Controllers.Notify
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifiesController : VersionedApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotifiesController> _Logger;
        public NotifiesController(IMediator mediator, ILogger<NotifiesController> logger)
        {
            _mediator = mediator;
            _Logger = logger;
        }
        [HttpGet("all ", Name = "GetAllNotifyWeapons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetAllNotifyVm>>> GetAllStoreItems([FromQuery] GetAllNotifyParameter filter)
        {

            var dtos = await _mediator.Send(new GetAllNotifyQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
            _Logger.LogInformation("Getting list of NotifyWeapons");
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetAllNotifyVm>>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetNotifyByIdQuery { Id = id }));
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
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<CreateNotifyCommandResponse>> Create([FromBody] CreateNotifyCommand createNotifyWeaponCommand)
        {
            var response = await _mediator.Send(createNotifyWeaponCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateStoreItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNotifyCommand updateNotifyCommand)
        {
            await _mediator.Send(updateNotifyCommand);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteNotifyWeapon")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteNotifyWeaponCommand = new DeleteNotifyCommand()
            { Id = id };
            await _mediator.Send(deleteNotifyWeaponCommand);
            return NoContent();

        }
    }
}

