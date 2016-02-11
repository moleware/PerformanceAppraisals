using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DGS_Enterprise.Model;

namespace DGS_Enterprise.Data
{
    using System;
    using System.Data.Entity;

    public partial class DGS_EnterpriseEntities : DbContext
    {
        public DGS_EnterpriseEntities()
            : base("name=DGS_EnterpriseEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // It says not to comment out this line....but I'm going to need a good reason cuz this breaks my app.
            //     throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<AreaOfExpertise> AreaOfExpertises { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<GuideBookEmployeeDepartment> GuideBookEmployeeDepartments { get; set; }
        public virtual DbSet<HireAndTerminationDate> HireAndTerminationDates { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LawyerAreaOfExpertise> LawyerAreaOfExpertises { get; set; }
        public virtual DbSet<LawyerBarNumber> LawyerBarNumbers { get; set; }
        public virtual DbSet<LawyerEmployee> LawyerEmployees { get; set; }
        public virtual DbSet<PhotoGalleryCategory> PhotoGalleryCategories { get; set; }
        public virtual DbSet<PracticeGroup> PracticeGroups { get; set; }
        public virtual DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public virtual DbSet<Salutation> Salutations { get; set; }
    }
}
