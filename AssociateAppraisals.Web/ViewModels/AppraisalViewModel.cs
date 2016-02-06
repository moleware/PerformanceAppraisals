﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssociateAppraisals.Model;
using AssociateAppraisals.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalViewModel
    {
        #region Extra View Properties

        #endregion

        #region Database Fields
        [ForeignKey("Appraisal")]
        public int AppraisalId { get; set; }
        public int ReviewYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion


        #region Other Model References
        public virtual List<AssociateAppraisal> AssociateAppraisals { get; set; }
        public virtual List<AppraisalQuestionViewModel> Questions { get; set; }
        #endregion
    }
}