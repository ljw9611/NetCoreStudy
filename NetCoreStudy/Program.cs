using NET_Core_Study; // ������ �̵���� namespace using

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<Middleware>(); // �̵���� Ŭ���� �߰� / Middleware�� Ŭ������

app.MapGet("/", () => "Hello World!12");

app.Run();