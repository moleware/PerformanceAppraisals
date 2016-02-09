using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Model;


namespace AssociateAppraisals.Data.Repositories
{
    public class AssociateAppraisalQuestionAnswerRepository : RepositoryBase<AssociateAppraisalQuestionAnswer>, IAssociateAppraisalQuestionAnswerRepository
    {
        public AssociateAppraisalQuestionAnswerRepository(IDbFactory dbFactory) : base(dbFactory) {}
        public AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int AssociateAppraisalQuestionAnswerId)
        {
            return this.DbContext.AssociateAppraisalQuestionAnswers.Where(aaqa => aaqa.AssociateAppraisalQuestionAnswerId == AssociateAppraisalQuestionAnswerId).FirstOrDefault();
        }
        public AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int appraisalQuestionId, int associateAppraisalId)
        {
            return this.DbContext.AssociateAppraisalQuestionAnswers.Where(aaqa => (aaqa.AppraisalQuestionId == appraisalQuestionId) && (aaqa.AssociateAppraisalId == associateAppraisalId)).FirstOrDefault();
        }
        public IEnumerable<AssociateAppraisalQuestionAnswer> GetAssociateAppraisalQuestionAnswers(int associateAppraisalId)
        {
            return this.DbContext.AssociateAppraisalQuestionAnswers.Where(aaqa => aaqa.AssociateAppraisalId == associateAppraisalId);
        }
        public override void Update(AssociateAppraisalQuestionAnswer entity)
        {
            base.Update(entity);
        }  
    }

    public interface IAssociateAppraisalQuestionAnswerRepository : IRepository<AssociateAppraisalQuestionAnswer>
    {
        AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int AssociateAppraisalQuestionAnswerId);
        AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int appraisalQuestionId, int associateAppraisalId);
        IEnumerable<AssociateAppraisalQuestionAnswer> GetAssociateAppraisalQuestionAnswers(int associateAppraisalId);
    }
}
