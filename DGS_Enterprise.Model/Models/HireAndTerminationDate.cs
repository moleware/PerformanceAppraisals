
namespace DGS_Enterprise.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("HireAndTerminationDates")]
    public partial class HireAndTerminationDate
    {
        [Key]
        public int DateRangeID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Nullable<System.DateTime> ActualStartDate { get; set; }
        public Nullable<System.DateTime> NominalStartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
