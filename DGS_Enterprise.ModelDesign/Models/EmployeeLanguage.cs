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
    
    public partial class EmployeeLanguage
    {
        public int EmployeeLanguageID { get; set; }
        public int EmployeeID { get; set; }
        public int LanguageID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Language Language { get; set; }
    }
}
