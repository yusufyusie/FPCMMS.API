using FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.API.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost(Name = "AddNotifyItems")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(422)]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<CreateNotifyItemCommandResponse>> Create([FromBody] CreateNotifyItemCommand createNotifyItemCommand)
        {
            var response = await _mediator.Send(createNotifyItemCommand);
            return Ok(response);
        }
    }
}
