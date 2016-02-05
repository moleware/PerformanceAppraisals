using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DGS_Enterprise.Model;
using AssociateAppraisals.Helpers;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalViewModel
    {
        #region Extra View Properties

        #endregion

        #region Database Fields
        public int AppraisalId { get; set; }
        public int ReviewYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion

        #region Other Model References
        public virtual List<AppraisalQuestionViewModel> Questions { get; set; }
        #endregion
    }
}