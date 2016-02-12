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
        public int WorkId { get; set; }
        [ForeignKey("Associate")]
        public int AssociateId { get; set; }
        public string ClientName { get; set; }
        public string ClientMatter { get; set; }
        public string MatterName { get; set; }
        public Nullable<double> Hours { get; set; }
        public string Partner { get; set; }
        public string Supervisor { get; set; }

        public virtual Associate Associate { get; set; }
    }
}
