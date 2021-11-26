using ERP.Middlewares.ErrorsHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middleware.ErrorsHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //context.Request.Headers.TryGetValue("X-XSRF-Token", out var x);
                //Debug.WriteLine(x);

                if (context.Request.Path.Value.Contains("/api")&& !context.Request.Path.Value.Contains("/api/Identity"))
                {
                var token = context.Request.Headers.TryGetValue("Authorization", out var headerValue);
                    if (token)
                    {
                        var tokenFormHeader = headerValue.ToString().Split(" ");
                        if (!tokenFormHeader[1].Contains("5V4fqC2YbK"))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            tokenFormHeader[1] = tokenFormHeader[1].Remove(0, "5V4fqC2YbK".Length);
                            headerValue = tokenFormHeader[0] + " " + tokenFormHeader[1];
                            context.Request.Headers.Remove("Authorization");
                            context.Request.Headers.Add("Authorization", headerValue);
                            Debug.WriteLine(tokenFormHeader[1]);
                            await _next(context);
                        }
                    }
                    else
                        context.Abort();
                }
                else
                    await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}