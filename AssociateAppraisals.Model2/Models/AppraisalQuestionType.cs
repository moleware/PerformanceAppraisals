//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssociateAppraisals.Model_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppraisalQuestionType
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
