using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssociateAppraisals.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AssociateViewModel
    {
        public int AssociateId { get; set; }
        public string Login { get; set; }

        public virtual List<Appraisal> Appraisals { get; set; }
    }
}