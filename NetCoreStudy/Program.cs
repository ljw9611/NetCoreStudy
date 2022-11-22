using Microsoft.Extensions.Options;
using NET_Core_Study; // ������ �̵���� namespace using
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

app.UseMiddleware<FruitMiddleware>(); // �̵���� Ŭ���� �߰� / Middleware�� Ŭ������

app.MapGet("/", () => "Hello World!12");

app.Run();