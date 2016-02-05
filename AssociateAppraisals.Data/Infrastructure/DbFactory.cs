using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateAppraisals.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        AssociateAppraisalsEntities dbContext;

        public AssociateAppraisalsEntities Init()
        {
            return dbContext ?? (dbContext = new AssociateAppraisalsEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
