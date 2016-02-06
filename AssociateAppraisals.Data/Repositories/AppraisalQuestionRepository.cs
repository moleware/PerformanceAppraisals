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
        public AppraisalQuestion GetAppraisalQuestions(int appraisalId)
        {
            return this.DbContext.AppraisalQuestions.Where(q => q.AppraisalId == appraisalId).FirstOrDefault();
        }
        public AppraisalQuestion GetAppraisalQuestion(int appraisalQuestionId)
        {
            return this.DbContext.AppraisalQuestions.Where(q => q.AppraisalQuestionId == appraisalQuestionId).FirstOrDefault();
        }
        public AppraisalQuestion GetAppraisalQuestion(int appraisalId, int questionNumber)
        {
            return this.DbContext.AppraisalQuestions.Where(q => (q.AppraisalId == appraisalId) && (q.QuestionNumber == questionNumber)).FirstOrDefault();
        }
        public override void Update(AppraisalQuestion entity)
        {
            base.Update(entity);
        }
        
    }

    public interface IAppraisalQuestionRepository : IRepository<AppraisalQuestion>
    {
        AppraisalQuestion GetAppraisalQuestions(int appraisalId);
        AppraisalQuestion GetAppraisalQuestion(int appraisalQuestionId);
        AppraisalQuestion GetAppraisalQuestion(int appraisalId, int questionNumber);
    }
}
