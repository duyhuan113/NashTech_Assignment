using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace demoWebApp
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() =>
            {
                context.Response.OnStarting(() =>
                  {
                      context.Response.Headers.Add("Huan", "NASHTECH");
                      return Task.FromResult(0);
                  });
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                context.Response.WriteAsync($"The processing take {responseTimeForCompleteRequest.ToString()} millisecond.");
                return Task.CompletedTask;
            });
            await next.Invoke(context);
        }
    }
}