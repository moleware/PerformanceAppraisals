using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Enterprise.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DGS_EnterpriseEntities dbContext;

        public DGS_EnterpriseEntities Init()
        {
            return dbContext ?? (dbContext = new DGS_EnterpriseEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
