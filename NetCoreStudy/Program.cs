using NET_Core_Study; // ������ �̵���� namespace using

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

app.UseMiddleware<Middleware>(); // �̵���� Ŭ���� �߰� / Middleware�� Ŭ������

app.MapGet("/", () => "Hello World!12");

app.Run();