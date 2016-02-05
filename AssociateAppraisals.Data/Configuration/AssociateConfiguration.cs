using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data
{
    public class AssociateConfiguration : EntityTypeConfiguration<Associate>
    {
        public AssociateConfiguration()
        {
            ToTable("Associate");
            Property(a => a.Login).IsRequired().HasMaxLength(5);
        }
    }
}
