using FPCMMS.Application.Features.Weapon.NotifyDetailCommands;
using FPCMMS.Application.Features.Weapon.NotifyDetailQueries;
using FPCMMS.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.API.Controllers.Notify
{
    public class NotifyItemsController : VersionedApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotifyItemsController> _Logger;
        public NotifyItemsController(IMediator mediator, ILogger<NotifyItemsController> logger)
        {
            _Logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllNotifyItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<NotifyListVm>>> GetAllNotifies()
        {
            var dtos = await _mediator.Send(new GetNotifyListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetNotifyItemById")]
        public async Task<ActionResult<NotifyDetailVm>> GetNotifyById(int id)
        {
            var getNotifyDetailQuery = new GetNotifyDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getNotifyDetailQuery));
        }

        [HttpPost(Name = "AddNotifyItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateNotifyDetailCommandResponse>> Create([FromBody] CreateNotifyDetailCommand createNotifyItemCommand)
        {
            var response = await _mediator.Send(createNotifyItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateNotifyItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNotifyDetailCommand updateNotifyItemCommand)
        {
            await _mediator.Send(updateNotifyItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteNotifyItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteNotifyItemCommand = new DeleteNotifyDetailCommand() { Id = id };
            await _mediator.Send(deleteNotifyItemCommand);
            return NoContent();
        }
    }
}
