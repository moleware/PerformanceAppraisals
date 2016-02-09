using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("Appraisal")]
    public class Appraisal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appraisal()
        {
            this.AppraisalQuestions = new HashSet<AppraisalQuestion>();
            this.AssociateAppraisals = new HashSet<AssociateAppraisal>();
        }

        [Display(Name = "Appraisal Id")]
        public int AppraisalId { get; set; }
        [Display(Name = "Review Year")]
        public Nullable<int> ReviewYear { get; set; }
        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Display(Name = "End Date")]
        public Nullable<System.DateTime> EndDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppraisalQuestion> AppraisalQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisal> AssociateAppraisals { get; set; }
    }
}
