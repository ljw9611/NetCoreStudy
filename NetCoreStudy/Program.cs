using NET_Core_Study; // ������ �̵���� namespace using

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", branch =>
{
    branch.Run(async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Branch middleware");
    });
});

app.UseMiddleware<Middleware>(); // �̵���� Ŭ���� �߰� / Middleware�� Ŭ������

app.MapGet("/", () => "Hello World!12");

app.Run();