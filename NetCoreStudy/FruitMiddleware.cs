﻿using Microsoft.Extensions.Options;

namespace NetCoreStudy
{
    public class FruitMiddleware
    {
        private RequestDelegate _next;
        private FruitOptions _options;

        public FruitMiddleware(RequestDelegate next, IOptions<FruitOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/fruit")
            {
                await context.Response.WriteAsync($"{_options.Name}, {_options.Color}");
            }

            else
            {
                await _next(context);
            }

        }
    }
}
