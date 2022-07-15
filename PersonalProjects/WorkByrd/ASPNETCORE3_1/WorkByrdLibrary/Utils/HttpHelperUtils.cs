using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace WorkByrdLibrary.Utils
{
	public static class HttpHelperUtils
	{
		///// <summary>
		///// returns the base URL from a Uri.
		///// </summary>
		///// <param name="url">The Uri.</param>
		///// <returns>A base URL.</returns>
		//public static string BaseURL(Uri url)
		//{
		//	int index = url.AbsoluteUri.IndexOf(url.PathAndQuery);
		//	string baseURL = url.AbsoluteUri.Substring(0, index);
		//	if (!baseURL.EndsWith("/"))
		//	{
		//		baseURL = baseURL + "/";
		//	}
		//	return baseURL;
		//}

		//public static string BaseURL(HttpRequestMessage request)
		//{
		//	int index = request.RequestUri.AbsoluteUri.IndexOf(request.RequestUri.PathAndQuery);
		//	string baseURL = request.RequestUri.AbsoluteUri.Substring(0, index);
		//	if (!baseURL.EndsWith("/"))
		//	{
		//		baseURL = baseURL + "/";
		//	}
		//	return baseURL;
		//}

		//TODO - not tested
		//public static string BaseURL(DefaultHttpContext context)
		//{
		//	string path = context.Request.Host.Value + ResolveUrl("~/");
		//	return request.PathBase.Value;
		//	//int index = request.Url.AbsoluteUri.IndexOf(request.Url.PathAndQuery);
		//	//string baseURL = request.Url.AbsoluteUri.Substring(0, index);
		//	//if (!baseURL.EndsWith("/"))
		//	//{
		//	//	baseURL = baseURL + "/";
		//	//}
		//	//return baseURL;
		//}
	}
}
