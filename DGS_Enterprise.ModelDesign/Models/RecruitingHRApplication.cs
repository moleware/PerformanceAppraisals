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
    
    public partial class RecruitingHRApplication
    {
        public int ApplicationID { get; set; }
        public Nullable<System.DateTime> ApplicationReceivedDate { get; set; }
        public Nullable<int> ApplicantSalutationID { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantMiddleName { get; set; }
        public string ApplicantLastName { get; set; }
        public string ResumeFileName { get; set; }
        public Nullable<int> AreaOfExpertiseID { get; set; }
        public Nullable<int> AppliedPositionID { get; set; }
        public string ApplicationNotes { get; set; }
        public Nullable<int> HeadHunterID { get; set; }
        public Nullable<int> PositionDepartmentID { get; set; }
        public Nullable<int> PositionPracticeGroupID { get; set; }
        public Nullable<bool> TopCandidate { get; set; }
        public string Experience { get; set; }
        public Nullable<int> FieldOfLawID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Zip { get; set; }
    }
}
