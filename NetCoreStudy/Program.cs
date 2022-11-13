var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//�߰��� �ڵ�
app.Use(async (context, next) => //HttpContext Class�� context �Ű�����
{
    if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware\n"); //���� ���� ���� �ۼ�
    }
    await next();
});

app.MapGet("/", () => "Hello World!12");

app.Run();