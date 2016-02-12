using System.Collections.Generic;
using DGS_Enterprise.Model;
using System.Web.Mvc;
using DGS_Enterprise.Data;
using System.Linq;


namespace AssociateAppraisals.Web.ViewModels
{
    public class PartnerViewModel : Employee
    {
        private readonly List<Employee> _partnerEmployees;
        private DGS_EnterpriseEntities entities = new DGS_EnterpriseEntities();

        public PartnerViewModel()
        {
            // Set up variables because Razor gets upset when you use methods...
            string partnerStr = Helpers.UserType.UserTypes.Partner.ToString();
            int emplTypeId = entities.EmployeeTypes.Where(e => e.Description == partnerStr).FirstOrDefault().EmployeeTypeID;

            // This SHOULD fetch us a list of all active partners in DGS.
            _partnerEmployees = entities.Employees
                .Include("EmployeeTypes")
                .Where(e =>
                    (e.IsActive != false) && 
                    (e.EmployeeTypes.Select(et => et.EmployeeTypeID).Contains(emplTypeId)))     
                .ToList();
        }

        public IEnumerable<SelectListItem> Partners
        {
            get { return new SelectList(_partnerEmployees, "LoginName", "FullName", "--- Select One ---"); }
        }
    }
}