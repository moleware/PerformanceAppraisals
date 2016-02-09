using System.ComponentModel.DataAnnotations.Schema;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("AssociateAppraisal")]
    public class AssociateAppraisal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssociateAppraisal()
        {
            this.AssociateAppraisalQuestionAnswers = new HashSet<AssociateAppraisalQuestionAnswer>();
        }

        public int AssociateAppraisalId { get; set; }
        public int AppraisalId { get; set; }
        public int AssociateId { get; set; }
        public Nullable<int> PracticeGroupId { get; set; }

        public virtual Appraisal Appraisal { get; set; }
        public virtual Associate Associate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisalQuestionAnswer> AssociateAppraisalQuestionAnswers { get; set; }
    }
}
