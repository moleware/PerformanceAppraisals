using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data.Repositories
{
    public class AssociateAppraisalRepository : RepositoryBase<AssociateAppraisal>, IAssociateAppraisalRepository
    {
        public AssociateAppraisalRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public AssociateAppraisal GetAssociateAppraisal(int associateAppraisalId)
        {
            return this.DbContext.AssociateAppraisals.Where(a => a.AssociateAppraisalId == associateAppraisalId).FirstOrDefault();
        }
        public List<AssociateAppraisal> GetAssociateAppraisals(int employeeId, int appraisalId)
        {
            return this.DbContext.AssociateAppraisals.Where(a => (a.EmployeeId == employeeId) && (a.AppraisalId == appraisalId)).ToList();
        }
        public IEnumerable<AssociateAppraisal> GetAssociateAppraisals()
        {
            return this.DbContext.AssociateAppraisals;
        }

        public override void Update(AssociateAppraisal entity)
        {
            base.Update(entity);
        }

    }
    public interface IAssociateAppraisalRepository : IRepository<AssociateAppraisal>
    {
        AssociateAppraisal GetAssociateAppraisal(int reviewYear);
        IEnumerable<AssociateAppraisal> GetAssociateAppraisals();
        List<AssociateAppraisal> GetAssociateAppraisals(int employeeId, int appraisalId);
    }
}
