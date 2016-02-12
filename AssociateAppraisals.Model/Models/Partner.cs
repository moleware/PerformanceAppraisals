using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("Partner")]
    public class Partner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partner()
        {
            this.AssociateAppraisals = new HashSet<AssociateAppraisal>();
            this.AssociateWorks = new HashSet<AssociateWork>();
        }

        [Key]
        public Nullable<int> EmployeeId { get; set; }
        public string Login { get; set; }
        [NotMapped]
        public string FullName { get; set; }

        [ForeignKey("EmployeeId")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisal> AssociateAppraisals { get; set; }
        [ForeignKey("EmployeeId")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateWork> AssociateWorks { get; set; }
    }
}
