using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssociateAppraisals.Model;
using AssociateAppraisals.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AssociateAppraisalViewModel
    {
        #region Extra View Properties

        #endregion

        #region Database Fields
        public int AssociateAppraisalId { get; set; }
        public int AppraisalId { get; set; }
        public int AssociateId { get; set; }
        public int PracticeGroupId { get; set; }
        #endregion

        #region Other Model References
        public virtual List<AppraisalQuestionViewModel> Questions { get; set; }

        public virtual Associate Associate { get; set; }
        public virtual Appraisal Appraisal { get; set; }
        #endregion
    }
}