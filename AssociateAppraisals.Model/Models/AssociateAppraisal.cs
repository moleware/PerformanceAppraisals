using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Model
{
    public class AssociateAppraisal
    {
        public int AssociateAppraisalId { get; set; }
        public int AppraisalId { get; set; }
        public int AssociateId { get; set; }
        public int PracticeGroupId { get; set; }

        
        [ForeignKey("AssociateId")]
        public virtual Associate Associate { get; set; }
        [ForeignKey("AppraisalId")]
        public virtual Appraisal Appraisal { get; set; }

        [NotMapped]
        public virtual List<AppraisalQuestion> AppraisalQuestions { get; set; }
    }
}
