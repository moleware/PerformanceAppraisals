using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Mvc;
using AssociateAppraisals.Model;
using AssociateAppraisals.Data;
using DGS_Enterprise.Model;
using DGS_Enterprise.Data;

namespace AssociateAppraisals.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeRedirect : AuthorizeAttribute
    {
        private const string IS_AUTHORIZED = "isAuthorized";
        public string RedirectUrl = "~/Error/Unauthorized";

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            bool isAuthorized = base.AuthorizeCore(httpContext);
            if (httpContext.Items.Contains(IS_AUTHORIZED))
            {
                httpContext.Items.Remove(IS_AUTHORIZED);
            }
            httpContext.Items.Add(IS_AUTHORIZED, isAuthorized);
            return isAuthorized;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            var isAuthorized = filterContext.HttpContext.Items[IS_AUTHORIZED] != null
                ? Convert.ToBoolean(filterContext.HttpContext.Items[IS_AUTHORIZED])
                : false;

            if (!isAuthorized && filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect(RedirectUrl);
            }
        }
    }

    public static class HelperExtensions
    {
        public static bool IsAdmin(this IPrincipal p)
        {
            return p.IsInRole(@"dgslaw\ems_owner");
        }
        public static bool IsManager(this IPrincipal p)
        {
            return p.IsInRole(@"dgslaw\ems_manager");
        }
        public static bool IsScheduler(this IPrincipal p)
        {
            return p.IsInRole(@"dgslaw\ems_scheduling");
        }
        public static bool IsVisitor(this IPrincipal p)
        {
            return p.IsInRole(@"dgslaw\ems_visitor");
        }
        public static bool IsHospitality(this IPrincipal p)
        {
            return p.IsInRole(@"dgslaw\ems_hospitality");
        }
    }

    public class Helpers
    {
        // WARNING - These should be updated once DGS_Enterprise is represented/modeled
        public static string GetAssociateFirstNameFromIdentity(IIdentity i)
        {
            Associate ass = GetAssociateFromLogin(GetLoginFromIdentity(i));
            if (ass != null)
            {
                Employee empl = GetEmployeeFromLogin(ass.Login);
                return empl.FirstName;
            }
            return "Unknown User";
        }
        public static string GetAssociateFullNameFromLogin(string login)
        {
            Employee empl = GetEmployeeFromLogin(login);
            if (null == empl)
                return "Unknown Employee: " + login;
            return empl.FullName;
        }
        public static Associate GetAssociateFromIdentity(IIdentity i)
        {
            return GetAssociateFromLogin(GetLoginFromIdentity(i));
        }
        internal static Employee GetEmployeeFromLogin(string login)
        {
            using (DGS_EnterpriseEntities dbDGS = new DGS_EnterpriseEntities())
            {
                return dbDGS.Employees.Where(e => e.LoginName == login).FirstOrDefault();
            }
        }
        internal static Associate GetAssociateFromLogin(string login)
        {
            using (AssociateAppraisalsEntities dbAss = new AssociateAppraisalsEntities())
            {
                return dbAss.Associates.FirstOrDefault(a => a.Login == login);
            }
        }
        internal static string GetLoginFromIdentity(IIdentity i)
        {
            return i.Name.ToLower().Replace("dgslaw\\", "");
        }
    }
}