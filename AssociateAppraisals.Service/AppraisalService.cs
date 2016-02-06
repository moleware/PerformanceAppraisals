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
    public interface IAppraisalService
    {
        IEnumerable<Appraisal> GetAppraisals(int reviewYear = 0);
        Appraisal GetAppraisal(int appraisalId);
        void CreateAppraisal(Appraisal appraisal);
        void SaveAppraisal();
    }
    public class AppraisalService : IAppraisalService
    {
        private readonly IAppraisalRepository appraisalsRepository;
        private readonly IAppraisalQuestionRepository appraisalQuestionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public AppraisalService(IAppraisalRepository appraisalsRepository, IAppraisalQuestionRepository appraisalQuestionsRepository, IUnitOfWork unitOfWork)
        {
            this.appraisalsRepository = appraisalsRepository;
            this.appraisalQuestionsRepository = appraisalQuestionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IAppraisalService Members

        public IEnumerable<Appraisal> GetAppraisals(int reviewYear = 0)
        {
            var appraisals = appraisalsRepository.GetAll();
            if (reviewYear > 0)
            {
                appraisals = appraisals.Where(a => a.ReviewYear == reviewYear);
            }
            return appraisals;
        }

        public Appraisal GetAppraisal(int appraisalId)
        {
            return appraisalsRepository.GetById(appraisalId);
        }

        public void CreateAppraisal(Appraisal appraisal)
        {
            appraisalsRepository.Add(appraisal);
        }

        public void SaveAppraisal()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
