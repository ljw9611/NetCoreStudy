using NET_Core_Study; // ������ �̵���� namespace using

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    await context.Response.WriteAsync($"\n Status code : { context.Response.StatusCode }");
});

app.UseMiddleware<Middleware>(); // �̵���� Ŭ���� �߰� / Middleware�� Ŭ������

app.MapGet("/", () => "Hello World!12");

app.Run();