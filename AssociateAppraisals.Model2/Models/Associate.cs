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
    
    public partial class Associate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Associate()
        {
            this.AssociateAppraisals = new HashSet<AssociateAppraisal>();
            this.AssociateWorks = new HashSet<AssociateWork>();
        }
    
        public int AssociateId { get; set; }
        public string Login { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisal> AssociateAppraisals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateWork> AssociateWorks { get; set; }
    }
}
