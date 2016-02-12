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
    public interface IAssociateService
    {
        IEnumerable<Associate> GetAssociates();
        Associate GetAssociate(int employeeId);
    }
    public class AssociateService : IAssociateService
    {
        private readonly IAssociateRepository associatesRepository;
        //  private readonly IAssociateWorkRepository associateWorksRepository;
        private readonly IUnitOfWork unitOfWork;

        //    public AssociateService(IAssociateRepository associatesRepository, IAssociateWorkRepository associateWorkRepository, IUnitOfWork unitOfWork)
        public AssociateService(IAssociateRepository associatesRepository, IUnitOfWork unitOfWork)
        {
            this.associatesRepository = associatesRepository;
        //    this.associateWorkRepository = associateWorkRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IAssociateService Members

        public IEnumerable<Associate> GetAssociates()
        {
            var associates = associatesRepository.GetAll();
            return associates;
        }

        public Associate GetAssociate(int employeeId)
        {
            var associate = associatesRepository.GetById(employeeId);
            return associate;
        }
        #endregion

    }
}
