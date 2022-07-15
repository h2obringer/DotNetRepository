using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.Middleware;

namespace WorkByrdLibrary.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAccountEnforcerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AccountEnforcerMiddleware>();
        }
    }
}
