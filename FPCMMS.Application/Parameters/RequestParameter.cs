using Microsoft.AspNetCore.Mvc;

namespace FPCMMS.Application.Parameters
{
    public class RequestParameter
    {
        [FromQuery]
        public int PageNumber { get; set; }
        [FromQuery]
        public int PageSize { get; set; }
        public RequestParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public RequestParameter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
