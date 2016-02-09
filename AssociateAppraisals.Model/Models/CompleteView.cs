using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    public partial class CompleteView
    {
        public string FullName { get; set; }
        public string LoginName { get; set; }
        public System.DateTime StartDate { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public Nullable<int> GradYear { get; set; }
        public string ClientName { get; set; }
        public string ClientMatter { get; set; }
        public Nullable<double> Hours { get; set; }
    }
}
