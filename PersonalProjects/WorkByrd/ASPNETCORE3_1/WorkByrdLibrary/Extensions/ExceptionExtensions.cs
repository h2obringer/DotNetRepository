using System;

namespace WorkByrdLibrary.Extensions
{
    public static class ExceptionExtensions
    {
		//ASP.NET MVC Exceptions often have a lot of nested inner exceptions and it is hard to get to the bottom of what you are trying to look for sometimes...
		public static bool Contains(this Exception ex, string text)
		{
			if (ex.Message == null) return false;
			if (ex.Message.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) return true;

			Exception innerException = ex.InnerException;

			while (innerException != null)
			{
				if (innerException.Message == null) return false;
				if (innerException.Message.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) return true;

				innerException = innerException.InnerException;
			}
			return false;
		}
	}
}
