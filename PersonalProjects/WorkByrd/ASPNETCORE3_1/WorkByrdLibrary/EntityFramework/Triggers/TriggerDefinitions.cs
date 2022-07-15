using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Identity;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Triggers
{
    public class TriggerDefinitions
    {
        public TriggerDefinitions()
        {
            Register();
        }

        public void Register()
        {
            //ApplicationUser
            Triggers<ApplicationUser, ApplicationDbContext>.Inserting += e => e.Context.ApplicationUserHistory.Add(new ApplicationUserHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<ApplicationUser, ApplicationDbContext>.Updating += e => e.Context.ApplicationUserHistory.Add(new ApplicationUserHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<ApplicationUser, ApplicationDbContext>.Deleting += e => e.Context.ApplicationUserHistory.Add(new ApplicationUserHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //AspNetRoles
            Triggers<IdentityRole<string>, ApplicationDbContext>.Inserting += e => e.Context.RoleHistory.Add(new AspNetRolesHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<IdentityRole<string>, ApplicationDbContext>.Updating += e => e.Context.RoleHistory.Add(new AspNetRolesHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<IdentityRole<string>, ApplicationDbContext>.Deleting += e => e.Context.RoleHistory.Add(new AspNetRolesHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //AspNetUserClaims
            Triggers<IdentityUserClaim<string>, ApplicationDbContext>.Inserting += e => e.Context.UserClaimsHistory.Add(new AspNetUserClaimsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<IdentityUserClaim<string>, ApplicationDbContext>.Updating += e => e.Context.UserClaimsHistory.Add(new AspNetUserClaimsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<IdentityUserClaim<string>, ApplicationDbContext>.Deleting += e => e.Context.UserClaimsHistory.Add(new AspNetUserClaimsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //AspNetUserLogins
            Triggers<IdentityUserLogin<string>, ApplicationDbContext>.Inserting += e => e.Context.UserLoginsHistory.Add(new AspNetUserLoginsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<IdentityUserLogin<string>, ApplicationDbContext>.Updating += e => e.Context.UserLoginsHistory.Add(new AspNetUserLoginsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<IdentityUserLogin<string>, ApplicationDbContext>.Deleting += e => e.Context.UserLoginsHistory.Add(new AspNetUserLoginsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //AspNetUserRoles
            Triggers<IdentityUserRole<string>, ApplicationDbContext>.Inserting += e => e.Context.UserRolesHistory.Add(new AspNetUserRolesHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<IdentityUserRole<string>, ApplicationDbContext>.Updating += e => e.Context.UserRolesHistory.Add(new AspNetUserRolesHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<IdentityUserRole<string>, ApplicationDbContext>.Deleting += e => e.Context.UserRolesHistory.Add(new AspNetUserRolesHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //AspNetUserTokens
            Triggers<IdentityUserToken<string>, ApplicationDbContext>.Inserting += e => e.Context.UserTokensHistory.Add(new AspNetUserTokensHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<IdentityUserToken<string>, ApplicationDbContext>.Updating += e => e.Context.UserTokensHistory.Add(new AspNetUserTokensHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<IdentityUserToken<string>, ApplicationDbContext>.Deleting += e => e.Context.UserTokensHistory.Add(new AspNetUserTokensHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //AspNetRoleClaims
            Triggers<IdentityRoleClaim<string>, ApplicationDbContext>.Inserting += e => e.Context.RoleClaimsHistory.Add(new AspNetRoleClaimsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<IdentityRoleClaim<string>, ApplicationDbContext>.Updating += e => e.Context.RoleClaimsHistory.Add(new AspNetRoleClaimsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<IdentityRoleClaim<string>, ApplicationDbContext>.Deleting += e => e.Context.RoleClaimsHistory.Add(new AspNetRoleClaimsHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //TimeZone
            Triggers<TimeZone, ApplicationDbContext>.Inserting += e => e.Context.TimeZoneHistory.Add(new TimeZoneHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<TimeZone, ApplicationDbContext>.Updating += e => e.Context.TimeZoneHistory.Add(new TimeZoneHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<TimeZone, ApplicationDbContext>.Deleting += e => e.Context.TimeZoneHistory.Add(new TimeZoneHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //TimeZone
            Triggers<StateProvince, ApplicationDbContext>.Inserting += e => e.Context.StateProvinceHistory.Add(new StateProvinceHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<StateProvince, ApplicationDbContext>.Updating += e => e.Context.StateProvinceHistory.Add(new StateProvinceHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<StateProvince, ApplicationDbContext>.Deleting += e => e.Context.StateProvinceHistory.Add(new StateProvinceHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //Country
            Triggers<Country, ApplicationDbContext>.Inserting += e => e.Context.CountryHistory.Add(new CountryHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<Country, ApplicationDbContext>.Updating += e => e.Context.CountryHistory.Add(new CountryHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<Country, ApplicationDbContext>.Deleting += e => e.Context.CountryHistory.Add(new CountryHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //Company
            Triggers<Company, ApplicationDbContext>.Inserting += e => e.Context.CompanyHistory.Add(new CompanyHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<Company, ApplicationDbContext>.Updating += e => e.Context.CompanyHistory.Add(new CompanyHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<Company, ApplicationDbContext>.Deleting += e => e.Context.CompanyHistory.Add(new CompanyHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //CompanyEmployee
            Triggers<CompanyEmployee, ApplicationDbContext>.Inserting += e => e.Context.CompanyEmployeeHistory.Add(new CompanyEmployeeHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<CompanyEmployee, ApplicationDbContext>.Updating += e => e.Context.CompanyEmployeeHistory.Add(new CompanyEmployeeHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<CompanyEmployee, ApplicationDbContext>.Deleting += e => e.Context.CompanyEmployeeHistory.Add(new CompanyEmployeeHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

            //PaymentMethodHistory
            Triggers<StripePaymentMethod, ApplicationDbContext>.Inserting += e => e.Context.StripePaymentMethodHistory.Add(new StripePaymentMethodHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Insert));
            Triggers<StripePaymentMethod, ApplicationDbContext>.Updating += e => e.Context.StripePaymentMethodHistory.Add(new StripePaymentMethodHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Update));
            Triggers<StripePaymentMethod, ApplicationDbContext>.Deleting += e => e.Context.StripePaymentMethodHistory.Add(new StripePaymentMethodHistory(e.Entity, e.Context.UserID, HistoryAuditAction.Delete));

        }
    }
}
