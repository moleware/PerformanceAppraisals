
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AreaOfExpertise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreaOfExpertise()
        {
            this.LawyerAreaOfExpertises = new HashSet<LawyerAreaOfExpertise>();
        }
    
        public int AreaOfExpertiseID { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LawyerAreaOfExpertise> LawyerAreaOfExpertises { get; set; }
    }
}
