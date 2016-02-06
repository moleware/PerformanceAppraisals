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
    public interface IAppraisalQuestionService
    {
        IEnumerable<AppraisalQuestion> GetAppraisalQuestions(int appraisalId);
        AppraisalQuestion GetAppraisalQuestion(int appraisalQuestionId);
        AppraisalQuestion GetAppraisalQuestion(int appraisalId, int questionNumber);
        void CreateQuestion(AppraisalQuestion appraisalQuestion);
        void SaveAppraisalQuestion();
    }
    public class AppraisalQuestionService : IAppraisalQuestionService
    {
        private readonly IAppraisalRepository appraisalsRepository;
        private readonly IAppraisalQuestionRepository appraisalQuestionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public AppraisalQuestionService(IAppraisalRepository appraisalsRepository, IAppraisalQuestionRepository appraisalQuestionsRepository, IUnitOfWork unitOfWork)
        {
            this.appraisalsRepository = appraisalsRepository;
            this.appraisalQuestionsRepository = appraisalQuestionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region AppraisalQuestionService Members

        public IEnumerable<AppraisalQuestion> GetAppraisalQuestions(int appraisalId)
        {
            var questions = appraisalQuestionsRepository.GetMany(a => a.AppraisalId == appraisalId).ToList();
            return questions;
        }

        public AppraisalQuestion GetAppraisalQuestion(int questionId)
        {
            return appraisalQuestionsRepository.GetById(questionId);
        }

        public AppraisalQuestion GetAppraisalQuestion(int appraisalId, int questionNumber)
        {
            return appraisalQuestionsRepository.GetAppraisalQuestion(appraisalId, questionNumber);
        }

        public void CreateQuestion(AppraisalQuestion appraisalQuestion)
        {
            appraisalQuestionsRepository.Add(appraisalQuestion);
        }

        public void SaveAppraisalQuestion()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
