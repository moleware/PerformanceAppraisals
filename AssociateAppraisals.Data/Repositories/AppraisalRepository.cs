using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data.Repositories
{
    public class AppraisalRepository : RepositoryBase<Appraisal>, IAppraisalRepository
    {
        public AppraisalRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Appraisal GetAppraisalByYear(int reviewYear)
        {
            var appraisal = this.DbContext.Appraisals.Where(a => a.ReviewYear == reviewYear).FirstOrDefault();
            return appraisal;
        }
        public override void Update(Appraisal entity)
        {
            base.Update(entity);
        }

    }
    public interface IAppraisalRepository : IRepository<Appraisal>
    {
        Appraisal GetAppraisalByYear(int reviewYear);
    }
}
