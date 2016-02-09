using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssociateAppraisals.Model;
using AssociateAppraisals.Web.ViewModels;
using AssociateAppraisals.Data;
using AssociateAppraisals.Service;
using System.Data;

namespace AssociateAppraisals.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();
        private readonly IAppraisalService appraisalService;

        // GET: Index - Administration home
        public ActionResult Index()
        {
            ViewBag.LoggedInUser = Helpers.Helpers.GetAssociateFirstNameFromIdentity(User.Identity);

            IEnumerable<Appraisal> appraisals = entities.Appraisals
                .Include("AssociateAppraisals")
                .Include("AppraisalQuestions")
                .ToList();
            return View(appraisals);
        }

        // GET: ListAssociateAppraisals - Associate Appraisal list
        public ActionResult ListAssociateAppraisals(int associateId, int appraisalId)
        {
            //       IEnumerable<AssociateAppraisalViewModel> viewModelAssociateAppraisals;
            //       IEnumerable<AssociateAppraisal> associateAppraisals;

            //       associateAppraisals = associateAppraisalService.GetAssociateAppraisals(associateId, appraisalId);

            //viewModelAssociateAppraisals = Mapper.Map<IEnumerable<AssociateAppraisal>, IEnumerable<AssociateAppraisalViewModel>>(associateAppraisals);
            // return View(viewModelAssociateAppraisals);
            return View();
        }

        // GET: EditAppraisalQuestions
        public ActionResult EditAppraisalQuestions(int id)
        {
            AppraisalQuestion aq = new AppraisalQuestion();
            aq.AppraisalId = id;
            return View(aq);
        }

        // POST: EditAppraisalQuestions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppraisalId, AppraisalQuestionGroupId, AppraisalQuestionTypeId, Question, QuestionNumber")]AppraisalQuestion question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entities.AppraisalQuestions.Add(question);
                    entities.SaveChanges();
                    return RedirectToAction("Index", new { id = question.AppraisalId } );
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(question);
        }
    }
}