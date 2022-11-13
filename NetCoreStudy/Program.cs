using NET_Core_Study; // 생성한 미들웨어 namespace using

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    await context.Response.WriteAsync($"\n Status code : { context.Response.StatusCode }");
});

app.UseMiddleware<Middleware>(); // 미들웨어 클래스 추가 / Middleware는 클래스명

app.MapGet("/", () => "Hello World!12");

app.Run();