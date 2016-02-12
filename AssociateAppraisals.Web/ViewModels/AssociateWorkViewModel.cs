using AssociateAppraisals.Model;
using AssociateAppraisals.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Mvc;


namespace AssociateAppraisals.Web.ViewModels
{
    public partial class AssociateWorkViewModel : AssociateWork
    {
        private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();
        private int _selectedPartnerEmployeeId;

        public AssociateWorkViewModel(AssociateWork assWork)
        {
            this.Appraisal = assWork.Appraisal;
            this.AppraisalId = assWork.AppraisalId;
            this.Associate = assWork.Associate;
            this.AssociateWorkId = assWork.AssociateWorkId;
            this.ClientMatter = assWork.ClientMatter;
            this.ClientName = assWork.ClientName;
            this.EmployeeId = assWork.EmployeeId;
            this.Hours = assWork.Hours;
            this.MatterName = assWork.MatterName;
            this.Partner = assWork.Partner;
            this.PartnerEmployeeId = PartnerEmployeeId;
            this.Supervisor = assWork.Supervisor;
            this.SupervisorEmployeeId = assWork.SupervisorEmployeeId;
            this._selectedPartnerEmployeeId = -1;       
        }

        public AssociateWorkViewModel(AssociateWork assWork, int selectedPartnerEmployeeId)
        {
            this.Appraisal = assWork.Appraisal;
            this.AppraisalId = assWork.AppraisalId;
            this.Associate = assWork.Associate;
            this.AssociateWorkId = assWork.AssociateWorkId;
            this.ClientMatter = assWork.ClientMatter;
            this.ClientName = assWork.ClientName;
            this.EmployeeId = assWork.EmployeeId;
            this.Hours = assWork.Hours;
            this.MatterName = assWork.MatterName;
            this.Partner = assWork.Partner;
            this.PartnerEmployeeId = PartnerEmployeeId;
            this.Supervisor = assWork.Supervisor;
            this.SupervisorEmployeeId = assWork.SupervisorEmployeeId;
            this._selectedPartnerEmployeeId = selectedPartnerEmployeeId;
        }

        public IEnumerable<SelectListItem> PartnerSelectList
        {
            get
            {
                PartnerViewModel pvm = new PartnerViewModel();
                pvm.PartnersList = entities.Partners.ToList();
                pvm.SelectedPartner = _selectedPartnerEmployeeId;

                return pvm.Partners;
            }
        }

    }
}