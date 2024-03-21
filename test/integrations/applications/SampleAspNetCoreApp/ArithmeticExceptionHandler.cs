using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleAspNetCoreApp;

public class ArithmeticExceptionHandler : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(
		HttpContext httpContext,
		Exception exception,
		CancellationToken cancellationToken
	)
	{
		if (httpContext.Response.HasStarted || exception is not ArithmeticException)
			return false;

		var logger = httpContext.RequestServices.GetRequiredService<ILogger<ArithmeticExceptionHandler>>();
		logger.LogError(exception, "An arithmetic error occurred");
		httpContext.Response.ContentType = "text/plain";
		httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
		await httpContext.Response.WriteAsync(
			httpContext.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment()
				? exception.ToString()
				: "Arithmetic Error Handled",
			cancellationToken
		);

		return true;
	}
}
