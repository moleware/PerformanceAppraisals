using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Principal;
using AssociateAppraisals.Model;
using DGS_Enterprise.Model;

namespace AssociateAppraisals.Helpers
{
    public class Session
    {
      //  private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();

        // private constructor
        private Session()
        { }
        public Session(IIdentity user)
        {
            Associate ass = Helpers.GetAssociateFromIdentity(user);
            Employee empl = Helpers.GetEmployeeFromLogin(ass.Login);
            AssociateId = ass.AssociateId;
            EmployeeId = empl.EmployeeID;
            FirstName = empl.FirstName;
            FullName = empl.FullName;
            UserType = Helpers.GetUserType(user);
        }

        // Gets the current session.
        public static Session Current
        {
            get
            { 
                Session session =
                  (Session)HttpContext.Current.Session["__Session__"];
                if (session == null)
                {
                    session = new Session();
                    HttpContext.Current.Session["__Session__"] = session;
                }
                return session;
            }
        }

        // Custom session properties
        public int AssociateId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public UserType.UserTypes UserType { get; set; }
    }
}