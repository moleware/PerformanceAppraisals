
namespace DGS_Enterprise.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeLanguage
    {
        public int EmployeeLanguageID { get; set; }
        public int EmployeeID { get; set; }
        public int LanguageID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Language Language { get; set; }
    }
}
