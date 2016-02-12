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

        public AssociateWork GetAssociateWork(int AssociateWorkId)
        {
            return this.DbContext.AssociateWorks.Where(a => a.AssociateWorkId == AssociateWorkId).FirstOrDefault();
        }
        public List<AssociateWork> GetAssociateWork(int employeeId, int appraisalId)
        {
            return this.DbContext.AssociateWorks.Where(a => a.EmployeeId == employeeId && a.AppraisalId == appraisalId).ToList();
        }
        public override void Update(AssociateWork entity)
        {
            base.Update(entity);
        }
    }
    public interface IAssociateWorkRepository : IRepository<AssociateWork>
    {
        AssociateWork GetAssociateWork(int AssociateWorkId);
        List<AssociateWork> GetAssociateWork(int employeeId, int appraisalId);
    }
}
