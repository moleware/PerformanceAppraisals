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
    public interface IPartnerService
    {
        IEnumerable<Partner> GetPartners();
        Partner GetPartner(int employeeId);
    }
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository partnersRepository;
        //  private readonly IAssociateWorkRepository associateWorksRepository;
        private readonly IUnitOfWork unitOfWork;

        //    public AssociateService(IAssociateRepository associatesRepository, IAssociateWorkRepository associateWorkRepository, IUnitOfWork unitOfWork)
        public PartnerService(IPartnerRepository partnersRepository, IUnitOfWork unitOfWork)
        {
            this.partnersRepository = partnersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPartnerService Members

        public IEnumerable<Partner> GetPartners()
        {
            return partnersRepository.GetAll();
        }

        public Partner GetPartner(int employeeId)
        {
            return partnersRepository.GetById(employeeId);
        }
        #endregion
    }
}
