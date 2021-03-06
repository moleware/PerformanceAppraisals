﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("Associate")]
    public class Associate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Associate()
        {
            this.AssociateAppraisals = new HashSet<AssociateAppraisal>();
            this.AssociateWorks = new HashSet<AssociateWork>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public string Login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateAppraisal> AssociateAppraisals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociateWork> AssociateWorks { get; set; }
    }
}
