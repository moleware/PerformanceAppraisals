
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            // This file was (originally) auto-generated.  Not sure why there are 3 GuideBookEmployeeDepartment list variables...

            this.EmployeeLanguages = new HashSet<EmployeeLanguage>();
            this.HireAndTerminationDates = new HashSet<HireAndTerminationDate>();
            this.LawyerEmployees = new HashSet<LawyerEmployee>();
            this.GuideBookEmployeeDepartments = new HashSet<GuideBookEmployeeDepartment>();
      //      this.GuideBookEmployeeDepartments1 = new HashSet<GuideBookEmployeeDepartment>();
            this.EmployeeTypes = new HashSet<EmployeeType>();
      //      this.GuideBookEmployeeDepartments2 = new HashSet<GuideBookEmployeeDepartment>();
        }
    
        [Key]
        public int EmployeeID { get; set; }
        public Nullable<int> PhotoGalleryCategoryID { get; set; }
        public Nullable<int> GuideBookEmployeeDepartmentID { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Initials { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string Extension { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public Nullable<decimal> DefaultBillingRate { get; set; }
        public Nullable<bool> ConfirmBillingRate { get; set; }
        public string ADPEmployeeCode { get; set; }
        public int MacPacID { get; set; }
        public string EliteBillingCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsExecutiveCommittee { get; set; }
        public System.DateTime StartDate { get; set; }
        public bool IsNotary { get; set; }
        [ForeignKey("GuideBookEmployeeDepartmentID")]
        public virtual GuideBookEmployeeDepartment GuideBookEmployeeDepartment { get; set; }
        public virtual PhotoGalleryCategory PhotoGalleryCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HireAndTerminationDate> HireAndTerminationDates { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual LawyerEmployee LawyerEmployee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LawyerEmployee> LawyerEmployees { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("GuideBookEmployeeDepartmentID")]
        public virtual ICollection<GuideBookEmployeeDepartment> GuideBookEmployeeDepartments { get; set; }
        //     [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //     public virtual ICollection<GuideBookEmployeeDepartment> GuideBookEmployeeDepartments1 { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ForeignKey("EmployeeTypeID")]
        public virtual ICollection<EmployeeType> EmployeeTypes { get; set; }
  //      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
  //      public virtual ICollection<GuideBookEmployeeDepartment> GuideBookEmployeeDepartments2 { get; set; }
    }
}
