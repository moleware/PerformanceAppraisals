using System.ComponentModel.DataAnnotations.Schema;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("AppraisalQuestionGroup")]
    public class AppraisalQuestionGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppraisalQuestionGroup()
        {
            this.AppraisalQuestions = new HashSet<AppraisalQuestion>();
        }

        public int AppraisalQuestionGroupId { get; set; }
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppraisalQuestion> AppraisalQuestions { get; set; }
    }
}
