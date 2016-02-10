using System.Collections.Generic;
using AssociateAppraisals.Model;
using System.Web.Mvc;
using AssociateAppraisals.Data;
using System.Linq;

namespace AssociateAppraisals.Web.ViewModels
{
    public partial class AssociatesViewModel : Associate
    {
        private readonly List<Associate> _associates;
        private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();

        public AssociatesViewModel()
        {
            _associates = entities.Associates
                .Include("AssociateAppraisals")
                .ToList();
        }

        public IEnumerable<Associate> Associates
        {
            get { return _associates.AsEnumerable(); }
        }

    }
}