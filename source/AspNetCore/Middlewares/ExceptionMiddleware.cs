using DotNetCore.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DotNetCore.AspNetCore
{
    public class ExceptionMiddleware
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogService _logService;
        private readonly RequestDelegate _request;

        public ExceptionMiddleware
        (
            IWebHostEnvironment environment,
            ILogService logService,
            RequestDelegate request
        )
        {
            _environment = environment;
            _logService = logService;
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                _logService.Error(exception);

                if (_environment.IsDevelopment())
                {
                    throw;
                }

                await ResponseAsync(context, HttpStatusCode.InternalServerError, string.Empty).ConfigureAwait(false);
            }
        }

        private static async Task ResponseAsync(HttpContext context, HttpStatusCode statusCode, string response)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            await context.Response.WriteAsync(response).ConfigureAwait(false);
        }
    }
}
