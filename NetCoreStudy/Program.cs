var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//추가한 코드
app.Use(async (context, next) => //HttpContext Class의 context 매개변수
{
    if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware\n"); //응답 본문 내용 작성
    }
    await next();
});

app.MapGet("/", () => "Hello World!12");

app.Run();