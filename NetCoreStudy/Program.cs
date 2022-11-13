using NET_Core_Study; // 생성한 미들웨어 namespace using

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/short")
    {
        await context.Response.WriteAsync("Request short-circuited");
    }
    else
    {
        await next();
    }
});

app.UseMiddleware<Middleware>(); // 미들웨어 클래스 추가 / Middleware는 클래스명

app.MapGet("/", () => "Hello World!12");

app.Run();