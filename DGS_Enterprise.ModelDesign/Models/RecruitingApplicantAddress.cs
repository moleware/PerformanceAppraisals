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
    
    public partial class RecruitingApplicantAddress
    {
        public int AddressID { get; set; }
        public int ApplicationID { get; set; }
        public string ApplicantAddressType { get; set; }
        public string ApplicantAddress1 { get; set; }
        public string ApplicantAddress2 { get; set; }
        public string ApplicantCity { get; set; }
        public Nullable<int> ApplicantStateID { get; set; }
        public string ApplicantZip { get; set; }
        public string ApplicantCountry { get; set; }
    }
}
