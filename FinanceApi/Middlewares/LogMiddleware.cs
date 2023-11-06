using FinanceCore.Repository.IRepository.ICardRepository;

namespace FinanceApi.Middlewares;

public static class LogMiddleware
{
    public static void Logware(this WebApplication webApplication,IApplicationBuilder applicationBuilder)
    {

        webApplication.Use(async (context, next) =>
        {
          ICardWriteRepository _cardWriteRepository=  applicationBuilder.ApplicationServices.GetService<ICardWriteRepository>();
          
            await next.Invoke();
        });

    }
}