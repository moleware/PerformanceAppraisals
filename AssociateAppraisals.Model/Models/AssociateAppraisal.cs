using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DGS_Enterprise.Model;

namespace AssociateAppraisals.Model
{
    public class AssociateAppraisal
    {
        public int AssociateAppraisalId { get; set; }
        public int AppraisalId { get; set; }
        public int AssociateId { get; set; }
        public int PracticeGroupId { get; set; }

 //       public Employee Employee { get; set; }  // This is a reference to the DGS_Enterprise employee.

        public virtual List<AppraisalQuestion> AppraisalQuestions { get; set; }
        public virtual Associate Associate { get; set; }
        public virtual Appraisal Appraisal { get; set; }
    }
}
