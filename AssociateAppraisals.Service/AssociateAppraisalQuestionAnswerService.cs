using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Model;
using AssociateAppraisals.Data;
using AssociateAppraisals.Data.Repositories;
using AssociateAppraisals.Data.Infrastructure;

namespace AssociateAppraisals.Service
{
    public interface IAssociateAppraisalQuestionAnswerService
    {
        IEnumerable<AssociateAppraisalQuestionAnswer> GetAssociateAppraisalQuestionAnswers(int associateAppraisalId);
        AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int associateAppraisalQuestionAnswerId);
        AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int appraisalQuestionId, int associateAppraisalId);
        void CreateAssociateAppraisalQuestionAnswer(AssociateAppraisalQuestionAnswer associateAppraisalQuestionAnswer);
        void SaveAssociateAppraisalQuestionAnswer();
    }
    public class AssociateAppraisalQuestionAnswerService : IAssociateAppraisalQuestionAnswerService
    {
        private readonly IAssociateAppraisalQuestionAnswerRepository associateAppraisalQuestionAnswerRepository;
        private readonly IAppraisalQuestionRepository appraisalQuestionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public AssociateAppraisalQuestionAnswerService(IAssociateAppraisalQuestionAnswerRepository associateAppraisalQuestionAnswerRepository, IAppraisalQuestionRepository appraisalQuestionsRepository, IUnitOfWork unitOfWork)
        {
            this.associateAppraisalQuestionAnswerRepository = associateAppraisalQuestionAnswerRepository;
            this.appraisalQuestionsRepository = appraisalQuestionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region AssociateAppraisalQuestionAnswerServiceService Members

        public IEnumerable<AssociateAppraisalQuestionAnswer> GetAssociateAppraisalQuestionAnswers(int associateAppraisalId)
        {
            return associateAppraisalQuestionAnswerRepository.GetMany(a => a.AssociateAppraisalId == associateAppraisalId).ToList();
        }

        public AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int associateAppraisalQuestionAnswerId)
        {
            return associateAppraisalQuestionAnswerRepository.GetById(associateAppraisalQuestionAnswerId);
        }

        public AssociateAppraisalQuestionAnswer GetAssociateAppraisalQuestionAnswer(int appraisalQuestionId, int associateAppraisalId)
        {
            return associateAppraisalQuestionAnswerRepository.GetAssociateAppraisalQuestionAnswer(appraisalQuestionId, associateAppraisalId);
        }

        public void CreateAssociateAppraisalQuestionAnswer(AssociateAppraisalQuestionAnswer associateAppraisalQuestionAnswer)
        {
            associateAppraisalQuestionAnswerRepository.Add(associateAppraisalQuestionAnswer);
        }

        public void SaveAssociateAppraisalQuestionAnswer()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
