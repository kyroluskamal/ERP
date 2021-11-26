
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Utilities.Helpers
{
    public class CustomAuthorize : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext actionContext)
        {

            var token = actionContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var headerValue);
            Debug.WriteLine(actionContext.HttpContext.User.Identity.Name);
            Debug.WriteLine(token);
            if (token)
            {
                var tokenFormHeader = headerValue.ToString().Split(" ");
                if (!tokenFormHeader[1].Contains("5V4fqC2YbK"))
                {
                    actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    actionContext.Result = new BadRequestObjectResult(new { statu = "Hacking", error = "fsfsdf" });
                }
                else
                {
                    tokenFormHeader[1] = tokenFormHeader[1].Remove(0, "5V4fqC2YbK".Length);
                    headerValue = tokenFormHeader[0] + " " + tokenFormHeader[1];
                    actionContext.HttpContext.Request.Headers.Remove("Authorization");
                    actionContext.HttpContext.Request.Headers.Add("Authorization", headerValue);
                    Debug.WriteLine(tokenFormHeader[1]);
                    actionContext.Result = new OkObjectResult(new { status="Ok"});
                }
                actionContext.Result = new UnauthorizedObjectResult(new { status = "Unauthorized", error = "ffsdf" });
                base.OnActionExecuting(actionContext);
            }
        }

    }
}
