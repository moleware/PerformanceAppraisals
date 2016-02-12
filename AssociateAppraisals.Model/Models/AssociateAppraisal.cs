using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public int AssociateAppraisalId { get; set; }
        public int AppraisalId { get; set; }
        public int EmployeeId { get; set; }
        public int PartnerEmployeeId { get; set; }
        public int SupervisorEmployeeId { get; set; }
        public Nullable<int> PracticeGroupId { get; set; }

        [ForeignKey("AppraisalId")]
        public virtual Appraisal Appraisal { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Associate Associate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisalQuestionAnswer> AssociateAppraisalQuestionAnswers { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Partner Partners { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Partner Supervisors { get; set; }
    }
}
