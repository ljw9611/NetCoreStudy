using Microsoft.Extensions.Options;
using NET_Core_Study; // 생성한 미들웨어 namespace using
using NetCoreStudy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FruitOptions>(options =>
{
    options.Name = "watermelon";
});

var app = builder.Build();

//app.MapGet("/fruit", async(HttpContext context, IOptions<FruitOptions> FruitOptions) =>
//{
//    FruitOptions options = FruitOptions.Value;
//    await context.Response.WriteAsync($"{options.Name}, {options.Color}");
//});

app.UseMiddleware<FruitMiddleware>(); // 미들웨어 클래스 추가 / Middleware는 클래스명

app.MapGet("/", () => "Hello World!12");

app.Run();