using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data.Repositories
{
    public class AssociateWorkRepository : RepositoryBase<AssociateWork>, IAssociateWorkRepository
    {
        public AssociateWorkRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public AssociateWork GetAssociateWork(int workId)
        {
            return this.DbContext.AssociateWorks.Where(a => a.WorkId == workId).FirstOrDefault();
        }
        public List<AssociateWork> GetAssociateWork(int associateId, int appraisalId)
        {
            // WARNING - THIS IS NOT COMPLETE - Needs to be able to identify the year the work was performed
            return this.DbContext.AssociateWorks.Where(a => a.AssociateId == associateId).ToList();
        }
        public override void Update(AssociateWork entity)
        {
            base.Update(entity);
        }
    }
    public interface IAssociateWorkRepository : IRepository<AssociateWork>
    {
        AssociateWork GetAssociateWork(int workId);
        List<AssociateWork> GetAssociateWork(int associateId, int appraisalId);
    }
}
