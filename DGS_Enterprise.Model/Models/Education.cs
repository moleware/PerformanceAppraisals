
namespace DGS_Enterprise.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("Education")]
    public partial class Education
    {
        [Key]
        public int EducationEntryID { get; set; }
        [ForeignKey("LawyerEmployee")]
        public int LawyerEmployeeID { get; set; }
   //     [ForeignKey("GradLevel")]
   //     public int GradLevelID { get; set; }
        public string School { get; set; }
        public Nullable<int> GradYear { get; set; }
        public string Degree { get; set; }
        public string Honors { get; set; }
    
        public virtual LawyerEmployee LawyerEmployee { get; set; }
    }
}
