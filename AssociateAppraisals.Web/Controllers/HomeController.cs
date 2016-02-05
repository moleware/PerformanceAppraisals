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

        public HomeController(IAppraisalService appraisalService, IAppraisalQuestionService appraisalQuestionService)
        {
            this.appraisalService = appraisalService;
            this.appraisalQuestionService = appraisalQuestionService;
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<AppraisalViewModel> viewModelAppraisals;
            IEnumerable<Appraisal> appraisals;
            IEnumerable<AppraisalQuestion> questions;

            appraisals = appraisalService.GetAppraisals().ToList();
            foreach (Appraisal a in appraisals)
            {
                questions = appraisalQuestionService.GetAppraisalQuestions(a.AppraisalId);

                foreach (AppraisalQuestion q in questions)
                {
                    a.Questions.Add(q);
                }
            }

            ViewBag.LoggedInUser = Helpers.Helpers.GetAssociateFirstNameFromIdentity(User.Identity);

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