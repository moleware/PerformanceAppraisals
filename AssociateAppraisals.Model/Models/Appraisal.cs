using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateAppraisals.Model
{
    public class Appraisal
    {
        public int AppraisalId { get; set; }
        public int ReviewYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<AppraisalQuestion> Questions { get; set; }

        public Appraisal()
        {
            // Nothing to do here yet...
        }
    }
}
