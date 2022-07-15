using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.Objects;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using System.Threading.Tasks;

namespace WorkByrdLibrary.Logging
{
	public interface IUserAccessLogger
	{
		Task Log(string userName, UserAccessAction action, EntryPoint entryPoint);
	}

	public class UserAccessLogger : IUserAccessLogger
	{
		private ApplicationDbContext _context;

		public UserAccessLogger(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Log(string userName, UserAccessAction action, EntryPoint entryPoint)
		{
			//logging should not throw exceptions, this is a non critical service that should not stop the application
			try
			{
				UserAccessLog log = new UserAccessLog(userName, action, entryPoint);

				_context.UserAccessLogs.Add(log);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
