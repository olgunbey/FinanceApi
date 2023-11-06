using FinanceCore.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using ServiceStack;

namespace FinanceApi.Middlewares;

public static class ExceptionMiddleware
{
    public  static void Middleware(this WebApplication service)
    {
        service.UseExceptionHandler(conf =>
        {
            conf.Run(async context =>
            {
              var exceptionObject=  context.Features.Get<IExceptionHandlerFeature>();
              int exceptionNumber = exceptionObject.Error switch
              {
                CachingException => 201,
                NoUserException => 505,
                NoLimitException => 505
              };
              context.Response.StatusCode = exceptionNumber;
             await context.Response.WriteAsJsonAsync(exceptionObject.Error.Message);
            });
        }

        );
    }
}