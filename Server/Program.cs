
namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Use(AuthMiddleware);
            app.Run(SayHello);

            app.Run();
        }

        public static async Task SayHello(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("<p>Hello, ASP.NET Core!</p>");
        }

        public static async Task AuthMiddleware(HttpContext httpContext, RequestDelegate next)
        {
            if(httpContext.Request.Headers.Count == 17)
            {
                await next.Invoke(httpContext);
                await httpContext.Response.WriteAsync("Bad Request ");
            }
        }
    }
}
