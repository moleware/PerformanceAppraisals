using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;


namespace AssociateAppraisals.Data.Repositories
{
    public class AppraisalQuestionRepository : RepositoryBase<AppraisalQuestion>, IAppraisalQuestionRepository
    {
        public AppraisalQuestionRepository(IDbFactory dbFactory) : base(dbFactory) {} 
        public AppraisalQuestion GetAppraisalQuestionsByAppraisalId(int appraisalId)
        {
            var question = this.DbContext.AppraisalQuestions.Where(q => q.AppraisalId == appraisalId).FirstOrDefault();
            return question;
        }
        public override void Update(AppraisalQuestion entity)
        {
            base.Update(entity);
        }
        
    }

    public interface IAppraisalQuestionRepository : IRepository<AppraisalQuestion>
    {
        AppraisalQuestion GetAppraisalQuestionsByAppraisalId(int appraisalId);
    }
}
