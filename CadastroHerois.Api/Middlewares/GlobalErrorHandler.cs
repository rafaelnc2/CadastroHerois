using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace CadastroHerois.Api.Middlewares;

public class GlobalErrorHandler : IExceptionHandler
{
    private readonly ILogger<GlobalErrorHandler> _logger;
    
    public GlobalErrorHandler(ILogger<GlobalErrorHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        var result = new ApiDefaultOutput<object>(
            HttpStatusCode.InternalServerError, false, new List<string>() 
                { exception.Message }
        );
        
        var response = JsonSerializer.Serialize(result);

        httpContext.Response.ContentType = "application/json";
        
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        await httpContext.Response.WriteAsync(response, cancellationToken: cancellationToken);
        
        return true;
    }
}