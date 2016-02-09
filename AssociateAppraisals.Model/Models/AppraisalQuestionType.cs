using System.ComponentModel.DataAnnotations.Schema;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("AppraisalQuestionType")]
    public class AppraisalQuestionType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppraisalQuestionType()
        {
            this.AppraisalQuestions = new HashSet<AppraisalQuestion>();
        }

        public int AppraisalQuestionTypeId { get; set; }
        public string QuestionType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppraisalQuestion> AppraisalQuestions { get; set; }
    }
}
