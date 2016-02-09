using System;
using System.Collections.Generic;
using AssociateAppraisals.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AssociateAppraisals.Data;
using AssociateAppraisals.Service;
using System.Linq;
using System.Web;
using AssociateAppraisals.Web.ViewModels;
using AssociateAppraisals.Data.Repositories;


namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalQuestionGroupViewModel : AppraisalQuestionGroup
    {
        private readonly List<AppraisalQuestionGroup> _questionGroups;
        private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();

        public AppraisalQuestionGroupViewModel()
        {
            _questionGroups = entities.AppraisalQuestionGroups.ToList();
        }

        public IEnumerable<SelectListItem> QuestionGroups
        {
            get { return new SelectList(_questionGroups, "AppraisalQuestionGroupId", "Description"); }
        }
    }
}