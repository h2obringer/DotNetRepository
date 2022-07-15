using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.Objects;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using System.Threading.Tasks;

namespace WorkByrdLibrary.Logging
{
	public interface IWorkByrdDbLogger
	{
		Task Log(string entry, EntryPoint entryPoint, string location = "", LogLevel level = LogLevel.Info, string userID = "");
		Task Log(Exception ex, EntryPoint entryPoint, string location = "", LogLevel level = LogLevel.Error, string userID = "");
	}

    public class WorkByrdDbLogger : IWorkByrdDbLogger
    {
		private ApplicationDbContext _context;

		public WorkByrdDbLogger(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Log(string entry, EntryPoint entryPoint, string location = "", LogLevel level = LogLevel.Info, string userID = "")
		{
			//logging should not throw exceptions, this is a non critical service that should not stop the application
			try
			{
				WorkByrdLog log = new WorkByrdLog();
				log.Message = entry;
				log.StackTrace = "";
				log.InnerException = "";
				log.EntryPoint = entryPoint;
				log.Location = location;
				log.LogLevel = level;
				log.UserID = userID;

				_context.Logs.Add(log);
				await _context.SaveChangesAsync();				
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		/// <summary>
		/// Write a single log entry from an Exception.
		/// </summary>
		/// <param name="ex">The exception.</param>
		/// <param name="entryPoint">LogType.API or LogType.MVC. Used to determine the origination of the log in code.</param>
		/// <param name="entryType">The type of entry: Information, Warning, or Error (amongst other options).</param>
		public async Task Log(Exception ex, EntryPoint entryPoint, string location = "", LogLevel level = LogLevel.Error, string userID = "")
		{
			//logging should not throw exceptions, this is a non critical service that should not stop the application
			try
			{
				string message = ex.Message;
				string trace = ex.StackTrace;
				string innerexception = "";

				if (ex.Message.Length > 1000)
				{
					message = ex.Message.Substring(0, 1000);
				}

				if (trace.Length > 4500)
				{
					trace = trace.Substring(0, 4500);
				}

				if (ex.InnerException != null)
				{
					innerexception = ex.InnerException.ToString();
					if (innerexception.Length > 4500)
					{
						innerexception = innerexception.Substring(0, 4500);
					}
				}
				else
				{
					innerexception = "";
				}

				WorkByrdLog log = new WorkByrdLog();
				log.Message = message;
				log.StackTrace = trace;
				log.InnerException = innerexception;
				log.EntryPoint = entryPoint;
				log.Location = location;
				log.LogLevel = level;
				log.UserID = userID;

				_context.Logs.Add(log);
				await _context.SaveChangesAsync();
			}
			catch
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
