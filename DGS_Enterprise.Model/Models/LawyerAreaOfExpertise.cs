
namespace DGS_Enterprise.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("LawyerAreaOfExpertise")]
    public partial class LawyerAreaOfExpertise
    {
        [Key]
        [Column(Order = 1)]
        public int LawyerEmployeeID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AreaOfExpertiseID { get; set; }
        public string Notes { get; set; }
    
        public virtual AreaOfExpertise AreaOfExpertise { get; set; }
        public virtual LawyerEmployee LawyerEmployee { get; set; }
    }
}
