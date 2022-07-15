using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkByrdLibrary.EntityFramework.Tables;
using System.Reflection;
using EntityFrameworkCore.Triggers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WorkByrdLibrary.EntityFramework
{
	/// <summary>
	/// Dependency Injection Parameter Signature: (ApplicationDbContext context)
	/// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		/// <summary>
		/// Usage:
		///		If registered with Dependency Injection (See Startup.cs):
		///			private readonly ApplicationDbContext _context;
		///			public MyControl(ApplicationDbContext context){ _context = context; } //then reference _context where you need it
		///		If not registered:
		///			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		///			optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WorkByrdDB"));
		///			using (var context = new ApplicationDbContext(optionsBuilder.Options)){}
		/// </summary>
		/// <param name="options"></param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		private string _userID;
		public string UserID {
			get
			{
				if (_userID == null)
				{
					_userID = "";
				}
				return _userID;
			}
			set
			{
				_userID = value;
			}
		}

		public DbSet<Company> Companies { get; set; }
		public DbSet<CompanyEmployee> CompanyEmployees { get; set; }
		public DbSet<StripePaymentMethod> StripePaymentMethods { get; set; }
		public DbSet<TaxJarCache> TaxJarCache { get; set; }

		//MOSTLY STATIC DATA
		public DbSet<Country> Countries { get; set; }
		public DbSet<StateProvince> StateProvinces { get; set; }
		public DbSet<Tables.TimeZone> TimeZones { get; set; }

		//LOGS
		public DbSet<WorkByrdLog> Logs { get; set; }
		public DbSet<UserAccessLog> UserAccessLogs { get; set; }

		//HISTORY ITEMS
		public DbSet<ApplicationUserHistory> ApplicationUserHistory { get; set; }
		public DbSet<AspNetRoleClaimsHistory> RoleClaimsHistory { get; set; }
		public DbSet<AspNetRolesHistory> RoleHistory { get; set; }
		public DbSet<AspNetUserClaimsHistory> UserClaimsHistory { get; set; }
		public DbSet<AspNetUserLoginsHistory> UserLoginsHistory { get; set; }
		public DbSet<AspNetUserRolesHistory> UserRolesHistory { get; set; }
		public DbSet<AspNetUserTokensHistory> UserTokensHistory { get; set; }
		public DbSet<CompanyHistory> CompanyHistory { get; set; }
		public DbSet<CompanyEmployeeHistory> CompanyEmployeeHistory { get; set; }
		public DbSet<StripePaymentMethodHistory> StripePaymentMethodHistory { get; set; }
		public DbSet<CountryHistory> CountryHistory { get; set; }
		public DbSet<StateProvinceHistory> StateProvinceHistory { get; set; }
		public DbSet<TimeZoneHistory> TimeZoneHistory { get; set; }
		
		public override int SaveChanges()
		{
			return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
		}

		/// <summary>
		/// Fluent API usage gets put here
		/// </summary>
		/// <param name="builder"></param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Sets up the in memory schema for the AspNet Identity tables
			base.OnModelCreating(builder);

			//See WorkByrdLibrary.EntityFramework.Schema for the files that get executed by this command.
			Assembly assembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
			builder.ApplyConfigurationsFromAssembly(assembly);
		}
	}
}
