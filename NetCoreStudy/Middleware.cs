namespace NET_Core_Study
{
    public class Middleware
    {
        private RequestDelegate _next; //개인 요청 대리자 생성

        // 01. 클래스는 요청 대리자를 생성자 매개변수로 수신하며, 파이프라인의 다음 구성요소로 요청을 전달하는 데 사용됩니다.
        public Middleware(RequestDelegate next) // Http 요청을 수신 받을 수 있는 RequestDelegate 형식의 next 매개변수를 갖는 생성자 
        {
            _next = next; // 수신 받은 요청 대리자를 _next 필드(개인 요청 대리자)에 전달합니다.
        }

        // 02. (01) 이후 Invoke 메소드는 요청이 수신되고, 요청 및 응답에 대한 액세스를 제공하는 HttpContext 객체를 수신할 때 ASP에 의해 호출됩니다.
        // 클래스 미들웨어는 이전에 했던 람다 함수 미들웨어가 수신하는 것과 동일한 클래스인 HttpContext 클래스를 사용합니다.
        public async Task Invoke(HttpContext context) //HttpContext 클래스의 context 매개변수 생성
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted) // context 응답을 확인하기 위해 context 응답이 실행되지 않은 경우 ContentType 설정되도록 조건 설정
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class-based Middleware\n");
            }
            await _next(context);
            // 클래스 기반 미들웨어에서는 요청을 전달하기 위해 요청 대리자를 호출할 때 http 컨텍스트 객체를 인수로 사용해야 합니다.
        }
    }
}
