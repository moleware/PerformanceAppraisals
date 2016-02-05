using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateAppraisals.Model
{
    public class Associate
    {
        public int AssociateId { get; set; }
        public string Login { get; set; }

   //     public virtual List<AssociateWork> Work { get; set; }

        public Associate()
        {
            // Nothing to do here yet.
        }
    }
}
