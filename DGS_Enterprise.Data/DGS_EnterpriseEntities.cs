using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DGS_Enterprise.Model;

namespace DGS_Enterprise.Data
{
    public class DGS_EnterpriseEntities : DbContext
    {
        public DGS_EnterpriseEntities() : base("name=DGS_EnterpriseEntities") { }

        public DbSet<Employee> Employees { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }
    }
}
