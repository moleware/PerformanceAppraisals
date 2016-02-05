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

     /*   public IEnumerable<Appraisal> GetCategoryGadgets(int appraisalId)
        {
            var question = appraisalQuestionsRepository.GetAppraisalQuestionsByAppraisalId(appraisalId);
            return question .Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }*/

        public AppraisalQuestion GetAppraisalQuestion(int questionId)
        {
            var question = appraisalQuestionsRepository.GetById(questionId);
            return question;
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
