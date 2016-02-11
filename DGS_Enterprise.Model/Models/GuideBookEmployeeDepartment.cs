
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("GuideBookEmployeeDepartment")]
    public partial class GuideBookEmployeeDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GuideBookEmployeeDepartment()
        {
            this.Employees = new HashSet<Employee>();
        //    this.Employees1 = new HashSet<Employee>();
        }
    
        [Key]
        public int GuideBookEmployeeDepartmentID { get; set; }
        public int ManagerEmployeeID { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<bool> IsSupervisor { get; set; }
        public Nullable<int> SuperManagerEmployeeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("EmployeeID")]
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Employee Employee { get; set; }
    //    public virtual Employee Employee1 { get; set; }
    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
   //     public virtual ICollection<Employee> Employees1 { get; set; }
    }
}
