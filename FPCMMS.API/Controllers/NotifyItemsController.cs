using FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem;
using FPCMMS.Application.Features.NotifyItems.Commands.DeleteNotifyItem;
using FPCMMS.Application.Features.NotifyItems.Commands.UpdateNotifyItem;
using FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyDetail;
using FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/notifyItems")]
    [ApiController]
    public class NotifyItemsController : ControllerBase
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
            var getNotifyDetailQuery = new GetNotifyDetailQuery() { NotifyItemId = id };
            return Ok(await _mediator.Send(getNotifyDetailQuery));
        }

        [HttpPost(Name = "AddNotifyItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateNotifyItemCommandResponse>> Create([FromBody] CreateNotifyItemCommand createNotifyItemCommand)
        {
            var response = await _mediator.Send(createNotifyItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateNotifyItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateNotifyItemCommand updateNotifyItemCommand)
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
            var deleteNotifyItemCommand = new DeleteNotifyItemCommand() { NotifyItemId = id };
            await _mediator.Send(deleteNotifyItemCommand);
            return NoContent();
        }
    }
}
