using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace FavouriteAccounts.api.Utility
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var userException = context.Exception as CustomException;
            if (userException != null)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = userException.Message });
            }
        }
    }
}