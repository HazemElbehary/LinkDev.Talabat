using LinkDev.Talabat.APIs.Controllers.Errors;
using LinkDev.Talabat.Core.Application.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LinkDev.Talabat.APIs.Controllers.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IHostingEnvironment _environment;
		private readonly ILogger<ExceptionHandlerMiddleware> _logger;

		public ExceptionHandlerMiddleware(RequestDelegate next, IHostingEnvironment environment, ILogger<ExceptionHandlerMiddleware> logger)
        {
			_next = next;
			_environment = environment;
			_logger = logger;
		}

        public async Task InvokeAsync(HttpContext httpContext)
        {
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);

			}
		}

		private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
		{
			ApiResponce response;
			switch (ex)
			{
				case _NotFoundException:
					response = new ApiResponce(404, ex.Message);
					httpContext.Response.StatusCode = 404;
					httpContext.Response.ContentType = "text/json";
					await httpContext.Response.WriteAsync(response.ToString());
					break;

				case BadRequestException:
					response = new ApiResponce(400, ex.Message);
					httpContext.Response.StatusCode = 400;
					httpContext.Response.ContentType = "text/json";
					await httpContext.Response.WriteAsync(response.ToString());
					break;


				default:
					if (_environment.IsDevelopment())
					{
						_logger.LogError(ex, ex.Message);
						response = new ApiExceptionResponse(500, ex.Message, ex.StackTrace!.ToString());
					}
					else
					{
						// Log Error In DB Or In File
						response = new ApiExceptionResponse(500);
					}
					httpContext.Response.StatusCode = 500;
					httpContext.Response.ContentType = "text/json";
					await httpContext.Response.WriteAsync(response.ToString());
					break;
			}
		}
	}
}
 