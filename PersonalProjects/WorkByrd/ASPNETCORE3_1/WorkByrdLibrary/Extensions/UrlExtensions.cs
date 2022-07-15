using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkByrdLibrary.Extensions
{
    public static class UrlExtensions
    {
        public static string BaseURL(this IUrlHelper url, string contentPath = "~/")
        {
            var request = url.ActionContext.HttpContext.Request;
            return new Uri(new Uri(request.Scheme + "://" + request.Host.Value), url.Content(contentPath)).ToString();
        }
    }
}
