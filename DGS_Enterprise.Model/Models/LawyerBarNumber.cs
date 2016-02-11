
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LawyerBarNumber
    {
        public int LawyerEmployeeID { get; set; }
        public int LawyerBarNumberID { get; set; }
        public string BarNumber { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
    
        public virtual LawyerEmployee LawyerEmployee { get; set; }
    }
}
