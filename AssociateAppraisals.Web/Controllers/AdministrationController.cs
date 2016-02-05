using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssociateAppraisals.Model;
using AssociateAppraisals.Data;
using AssociateAppraisals.Service;
using AssociateAppraisals.Web.ViewModels;
using AutoMapper;


namespace AssociateAppraisals.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IAppraisalService appraisalService;
        private readonly IAppraisalQuestionService appraisalQuestionService;

        public AdministrationController(IAppraisalService appraisalService, IAppraisalQuestionService appraisalQuestionService)
        {
            this.appraisalService = appraisalService;
            this.appraisalQuestionService = appraisalQuestionService;
        }

        // GET: EditAppraisal
        public ActionResult EditAppraisalQuestions(int appraisalId)
        {
            IEnumerable<AppraisalQuestionViewModel> viewModelAppraisalQuestions;
            IEnumerable<Appraisal> appraisals;
            IEnumerable<AppraisalQuestion> questions;

            // This seems wrong.... It is known that we'll only get one result back, so why loop?
            appraisals = appraisalService.GetAppraisals().Where(a => a.AppraisalId == appraisalId);
            foreach (Appraisal a in appraisals)
            {
                questions = appraisalQuestionService.GetAppraisalQuestions(a.AppraisalId);
                foreach (AppraisalQuestion q in questions)
                {
                    q.AppraisalId = appraisalId;
                    a.Questions.Add(q);
                }
            }

            viewModelAppraisalQuestions = Mapper.Map<IEnumerable<Appraisal>, IEnumerable<AppraisalQuestionViewModel>>(appraisals);
            return View(viewModelAppraisalQuestions);
        }
    }
}