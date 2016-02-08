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
    public class HomeController : Controller
    {
        private readonly IAppraisalService appraisalService;
        private readonly IAppraisalQuestionService appraisalQuestionService;
        private readonly IAssociateAppraisalService associateAppraisalService;
        private readonly IAssociateAppraisalQuestionAnswerService associateAppraisalQuestionAnswerService;

        public HomeController(IAppraisalService appraisalService, IAppraisalQuestionService appraisalQuestionService, IAssociateAppraisalService associateAppraisalService)
        {
            this.appraisalService = appraisalService;
            this.appraisalQuestionService = appraisalQuestionService;
            this.associateAppraisalService = associateAppraisalService;
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<AppraisalViewModel> viewModelAppraisals;
            IEnumerable<Appraisal> appraisals;

            appraisals = appraisalService.GetAppraisals();

            ViewBag.LoggedInUser = Helpers.Helpers.GetAssociateFirstNameFromIdentity(User.Identity);

            viewModelAppraisals = Mapper.Map<IEnumerable<Appraisal>, IEnumerable<AppraisalViewModel>>(appraisals);
            return View(viewModelAppraisals);
        }

        //GET: Appraisals
        public ActionResult MyAppraisals()
        {
            IEnumerable<AppraisalViewModel> viewModelAppraisals;
            IEnumerable<Appraisal> appraisals;
            IEnumerable<AppraisalQuestion> questions;
            IEnumerable<AssociateAppraisal> associateAppraisals;
            AssociateAppraisalQuestionAnswer answer;

            // 1) Get the currently logged in Associate
            Associate associate = Helpers.Helpers.GetAssociateFromIdentity(User.Identity);

            // 2) Get a list of all appraisals
            appraisals = appraisalService.GetAppraisals().ToList();
            foreach (Appraisal a in appraisals)
            {
                // 3) Get all AssociateAppraisals for this Associate
                associateAppraisals = associateAppraisalService.GetAssociateAppraisals(associate.AssociateId, a.AppraisalId);

                // 4) Add questions for each appraisal
                foreach (AssociateAppraisal aa in associateAppraisals)
                {
                    // 5) Get all questions for each appraisal
                    questions = appraisalQuestionService.GetAppraisalQuestions(aa.AppraisalId);

                    // 6) Add the questions to the appraisal
                    foreach (AppraisalQuestion q in questions)
                    {
                        // 7) Get the Associate's answer to this question
                        answer = associateAppraisalQuestionAnswerService.GetAssociateAppraisalQuestionAnswer(q.AppraisalQuestionId, aa.AssociateAppraisalId);

                        // 8) Add the answer to the question
                        q.AssociateAppraisalQuestionAnswer = answer;

                        // 9) Add the question to the AssociateAppraisal
                        aa.AppraisalQuestions.Add(q);
                    }

                    // 10) add the AssociateAppraisal to the Appraisal
                    a.AssociateAppraisals.Add(aa);
                }
            }

            viewModelAppraisals = Mapper.Map<IEnumerable<Appraisal>, IEnumerable<AppraisalViewModel>>(appraisals);
            return View(viewModelAppraisals);
        }


        // GET: EditAppraisal
        /*  public ActionResult EditAppraisal(int appraisalId)
          {
              IEnumerable<AppraisalViewModel> viewModelAppraisals;
              IEnumerable<Appraisal> appraisals;
              IEnumerable<AppraisalQuestion> questions;

              // This seems wrong.... It is known that we'll only get one result back, so why loop?
              appraisals = appraisalService.GetAppraisals().Where(a => a.AppraisalId == appraisalId);
              foreach (Appraisal a in appraisals)
              {
                  questions = appraisalQuestionService.GetAppraisalQuestions(a.AppraisalId);
                  foreach (AppraisalQuestion q in questions)
                  {
                      a.Questions.Add(q);
                  }
              }

              Associate ass = Helpers.Helpers.GetAssociateFromIdentity(User.Identity);

              viewModelAppraisals = Mapper.Map<IEnumerable<Appraisal>, IEnumerable<AppraisalViewModel>>(appraisal);            
          }*/


        /*  We can worry about searching and filtering once the app works.




            public ActionResult Filter(string category, string gadgetName)
            {
                IEnumerable<GadgetViewModel> viewModelGadgets;
                IEnumerable<Gadget> gadgets;

                gadgets = gadgetService.GetCategoryGadgets(category, gadgetName);

                viewModelGadgets = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

                return View(viewModelGadgets);
            }

            [HttpPost]
            public ActionResult Create(GadgetFormViewModel newGadget)
            {
                if (newGadget != null && newGadget.File != null)
                {
                    var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
                    gadgetService.CreateGadget(gadget);

                    string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                    newGadget.File.SaveAs(path);

                    gadgetService.SaveGadget();
                }

                var category = categoryService.GetCategory(newGadget.GadgetCategory);
                return RedirectToAction("Index", new { category = category.Name });
            }
            */
    }
}