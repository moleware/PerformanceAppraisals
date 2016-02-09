using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssociateAppraisals.Model;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Data.Repositories;


namespace AssociateAppraisals.Service
{
    public interface IAssociateAppraisalService
    {
        IEnumerable<AssociateAppraisal> GetAssociateAppraisals();
        IEnumerable<AssociateAppraisal> GetAssociateAppraisals(int associateId, int appraisalId);
        AssociateAppraisal GetAssociateAppraisal(int associateAppraisalId);
    }
    public class AssociateAppraisalService : IAssociateAppraisalService
    {
        private readonly IAssociateAppraisalRepository associateAppraisalsRepository;
   //     private readonly IAssociateRepository associateRepository;
   //     private readonly IAppraisalRepository appraisalRepository;
        private readonly IUnitOfWork unitOfWork;

        //    public AssociateService(IAssociateRepository associatesRepository, IAssociateWorkRepository associateWorkRepository, IUnitOfWork unitOfWork)
        public AssociateAppraisalService(IAssociateAppraisalRepository associateAppraisalsRepository, IUnitOfWork unitOfWork)
        {
            this.associateAppraisalsRepository = associateAppraisalsRepository;
      //      this.associateRepository = associateRepository;
       //     this.appraisalRepository = appraisalRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IAssociateAppraisalService Members

        public IEnumerable<AssociateAppraisal> GetAssociateAppraisals()
        {
            return associateAppraisalsRepository.GetAssociateAppraisals();
        }
        public IEnumerable<AssociateAppraisal> GetAssociateAppraisals(int associateId, int appraisalId)
        {
            return associateAppraisalsRepository.GetAssociateAppraisals(associateId, appraisalId);
        }

        public AssociateAppraisal GetAssociateAppraisal(int associateAppraisalId)
        {
            return associateAppraisalsRepository.GetById(associateAppraisalId);
        }

        public void CreateAssociateAppraisal(AssociateAppraisal associateAppraisal)
        {
            associateAppraisalsRepository.Add(associateAppraisal);
        }

        public void SaveAssociateAppraisal()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
