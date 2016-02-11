
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("LawyerEmployee")]
    public partial class LawyerEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LawyerEmployee()
        {
            this.Educations = new HashSet<Education>();
            this.LawyerAreaOfExpertises = new HashSet<LawyerAreaOfExpertise>();
            this.LawyerBarNumbers = new HashSet<LawyerBarNumber>();
        }
    
        [Key]
        public int LawyerEmployeeID { get; set; }
        [ForeignKey("PracticeGroup")]
        public Nullable<int> PracticeGroupID { get; set; }
        public Nullable<int> SecretaryEmployeeID { get; set; }
        public string PracticeHistory { get; set; }
        public string JudicialClerkship { get; set; }
    

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }
        public virtual Employee Employee { get; set; }
     //   public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LawyerAreaOfExpertise> LawyerAreaOfExpertises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LawyerBarNumber> LawyerBarNumbers { get; set; }
        public virtual PracticeGroup PracticeGroup { get; set; }
    }
}
