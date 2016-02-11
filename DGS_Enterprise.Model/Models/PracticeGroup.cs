
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("PracticeGroup")]
    public partial class PracticeGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PracticeGroup()
        {
            this.LawyerEmployees = new HashSet<LawyerEmployee>();
        }
    
        [Key]
        public int PracticeGroupID { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
        public Nullable<int> EnterpriseKey { get; set; }
    
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LawyerEmployee> LawyerEmployees { get; set; }
    }
}
