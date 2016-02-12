using System.Collections.Generic;
using AssociateAppraisals.Model;
using System.Web.Mvc;
using AssociateAppraisals.Data;
using System.Linq;


namespace AssociateAppraisals.Web.ViewModels
{
    public class PartnerViewModel : Partner
    {
        private List<Partner> _partners;
        private int _selectedPartner;  // This is used for our drop down of partners
        private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();

        public PartnerViewModel()
        {
            // Initialize _selectedPartner to -1 so we know it has not been assigned
            _selectedPartner = -1;

            // Fetch all partners and add their first names to the entity for access in our drop down
            _partners = entities.Partners.ToList();
        /*    foreach (Partner p in _partners)
            {
                p.FullName = Helpers.Helpers.GetAssociateFullNameFromLogin(p.Login);
            }*/
        }

        public IEnumerable<SelectListItem> Partners
        {
            get
            {
                // One last try to populate partner names
                foreach (Partner p in _partners)
                {
                    p.FullName = Helpers.Helpers.GetAssociateFullNameFromLogin(p.Login);
                }
                return new SelectList(_partners, "EmployeeId", "FullName", (-1 == _selectedPartner) ? "--- Select One ---" : _selectedPartner.ToString());
            }
        }

        public List<Partner> PartnersList
        {
            set { _partners = value; }
        }

        public int SelectedPartner
        {
            get { return _selectedPartner; }
            set
            {
                _selectedPartner = value;
            }
        }
    }
}