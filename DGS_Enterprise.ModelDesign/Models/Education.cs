//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DGS_Enterprise.ModelDesign.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education
    {
        public int EducationEntryID { get; set; }
        public int LawyerEmployeeID { get; set; }
        public int GradLevelID { get; set; }
        public string School { get; set; }
        public Nullable<int> GradYear { get; set; }
        public string Degree { get; set; }
        public string Honors { get; set; }
    
        public virtual GradLevel GradLevel { get; set; }
        public virtual LawyerEmployee LawyerEmployee { get; set; }
    }
}
