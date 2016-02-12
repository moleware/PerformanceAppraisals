using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("AssociateWork")]
    public class AssociateWork
    {
        [Key]
        public int AssociateWorkId { get; set; }
        [ForeignKey("Associate")]
        public int EmployeeId { get; set; }
        [ForeignKey("Appraisal")]
        public int AppraisalId { get; set; }
        public string ClientName { get; set; }
        public string ClientMatter { get; set; }
        public string MatterName { get; set; }
        public Nullable<double> Hours { get; set; }
        public Nullable<int> PartnerEmployeeId { get; set; }
        public Nullable<int> SupervisorEmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Associate Associate { get; set; }
        [ForeignKey("PartnerEmployeeId")]
        public virtual Partner Partner { get; set; }
        [ForeignKey("SupervisorEmployeeId")]
        public virtual Partner Supervisor { get; set; }
        [ForeignKey("AppraisalId")]
        public virtual Appraisal Appraisal { get; set; }
    }
}
