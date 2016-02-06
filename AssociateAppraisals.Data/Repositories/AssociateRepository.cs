﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data.Repositories
{
    public class AssociateRepository : RepositoryBase<Associate>, IAssociateRepository
    {
        public AssociateRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Associate GetAssociateById(int associateId)
        {
            return this.DbContext.Associates.Where(a => a.AssociateId == associateId).FirstOrDefault();
        }
        public override void Update(Associate entity)
        {
            base.Update(entity);
        }

    }
    public interface IAssociateRepository : IRepository<Associate>
    {
        Associate GetAssociateById(int associateId);
    }
}
