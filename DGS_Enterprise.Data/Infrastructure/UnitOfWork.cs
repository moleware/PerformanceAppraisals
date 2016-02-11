using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Enterprise.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DGS_EnterpriseEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DGS_EnterpriseEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

 /*       public void Commit()      // We won't be committing anything back to the DB from here.
        {
            DbContext.Commit();
        }*/
    } 
}
