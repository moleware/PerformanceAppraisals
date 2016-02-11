using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociateAppraisals.Helpers
{
    public class UserType
    {
        public enum UserTypes
        {
            NotAuthorized,
            Associate,
            Partner,
            ReviewingPartner,
            Admin
        }
    }
}