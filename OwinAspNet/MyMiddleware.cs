using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;

namespace OwinAspNet
{
    public class MyMiddleware : OwinMiddleware
    {
        public MyMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IAppBuilder UseMyMiddleware(
            this IAppBuilder builder)
        {
            return builder.Use(typeof(MyMiddleware));
        }
    }
}