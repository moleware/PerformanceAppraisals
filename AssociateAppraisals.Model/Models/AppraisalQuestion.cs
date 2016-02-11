using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("AppraisalQuestion")]
    public class AppraisalQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppraisalQuestion()
        {
            this.AssociateAppraisalQuestionAnswers = new HashSet<AssociateAppraisalQuestionAnswer>();
        }

        public int AppraisalQuestionId { get; set; }
        [Required]
        public int AppraisalId { get; set; }
        public Nullable<int> AppraisalQuestionGroupId { get; set; }
        public Nullable<int> AppraisalQuestionTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Question { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Please enter a valid number (1 - 100).")]     // They shouldnt have over 100 questions on the appraisal, must be typo
        public Nullable<int> QuestionNumber { get; set; }

        public virtual Appraisal Appraisal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisalQuestionAnswer> AssociateAppraisalQuestionAnswers { get; set; }
        public virtual AppraisalQuestionGroup AppraisalQuestionGroup { get; set; }
        public virtual AppraisalQuestionType AppraisalQuestionType { get; set; }
    }
}
