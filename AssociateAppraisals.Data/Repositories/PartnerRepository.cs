using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data.Repositories
{
    public class PartnerRepository : RepositoryBase<Partner>, IPartnerRepository
    {
        public PartnerRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Partner GetPartnerById(int employeeId)
        {
            return this.DbContext.Partners.Where(a => a.EmployeeId == employeeId).FirstOrDefault();
        }
        public override void Update(Partner entity)
        {
            base.Update(entity);
        }
    }
    public interface IPartnerRepository : IRepository<Partner>
    {
        Partner GetPartnerById(int employeeId);
    }
}
