using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VersionedApiController : BaseApiController
    {
    }

}
