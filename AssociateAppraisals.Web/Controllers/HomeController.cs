using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssociateAppraisals.Model;
using AssociateAppraisals.Web.ViewModels;
using AssociateAppraisals.Data.Repositories;
using AssociateAppraisals.Data;
using AssociateAppraisals.Service;
using System.Runtime.Caching;
using System.IO;
using System.Net;
using System.Data;

namespace AssociateAppraisals.Web.Controllers
{
    public class HomeController : Controller
    {
        private AssociateAppraisalsEntities entities = new AssociateAppraisalsEntities();
        private readonly IAppraisalService appraisalService;

        private void InitializeCache()
        { 
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(2);  // Our user cache expires in 48 hours
        }

        public HomeController()
        {
            // Definitely hitting this, but don't have a User context yet...
        }

        public HomeController(IAppraisalService appraisalService)
        {
            // WARNING - I don't think we'll ever get here...
            this.appraisalService = appraisalService;
        }

        // GET: Home
        public ActionResult Index()
        {
            // Initialize our custom session.
            Helpers.Session s = new Helpers.Session(User.Identity);

            // Pass the currently logged in user since I don't have a better way of doing this yet.
            //    Associate a = Helpers.Helpers.GetAssociateFromIdentity(User.Identity);
            ViewBag.LoggedInUser = s.FullName;
            ViewBag.UserType = s.UserType;
            ViewBag.AssociateId = s.AssociateId;
            
            // Pass in the current appraisalId because we shouldn't be using this app outside of the February - July window.
            ViewBag.AppraisalId = entities.Appraisals.Where(aa => aa.ReviewYear == DateTime.Now.Year).FirstOrDefault().AppraisalId;

            IEnumerable<Appraisal> appraisals = entities.Appraisals.ToList();
            return View(appraisals);
        }

        // GET: IdentifyPartners - Takes the user to a page where they can identify the partners they worked with most
        public ActionResult IdentifyPartners(int associateId, int appraisalId)
        {
            // WARNING - We need to be able to identify which appraisal we're talking about so we only fetch work for the appropriate appraisal.
            return View(entities.AssociateWorks.Where(a => a.AssociateId == associateId).ToList());
        }

        // POST: IdentifyPartners - Updates the AssociateWork table with the partners identified
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IdentifyPartners(object anything)
        {
            /*  WARNING - This is a good way to check for errors in the ModelState
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                string poop = error.ToString();
            }*/

            var poop = Request.Form; // WARNING - This is very very wrong...  But I can't seem to get my form results any other way.

            List<AssociateWork> works = new List<AssociateWork>();

            try
            {
                if (ModelState.IsValid)
                {
                    string[] workIdArr = poop.GetValues("WorkId");
                    string[] partnerIdArr = poop.GetValues("Partner");

                    for (int i = 0; i < poop.Count; i++)
                    {
                        var evenMorePoop = workIdArr.ElementAt(i);
                        int slightlyLessPoop = int.Parse(evenMorePoop);
                        var morePoop = entities.AssociateWorks.Find(slightlyLessPoop);
                        AssociateWork assWork = morePoop;
                        assWork.Partner = (string.IsNullOrEmpty(partnerIdArr[i]) ? null : partnerIdArr[i]);
                        works.Add(assWork);
                        entities.Entry(assWork).State = System.Data.Entity.EntityState.Modified;
                    }

                    entities.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("SAVE_ERR", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(works);
        }





        // GET: AssociatesForReview - Takes the partner to a page where they see a list of all associates they have worked with.
        public ActionResult AssociatesForReview(int appraisalId)
        {
            IEnumerable<AssociateAppraisal> aa = entities.AssociateAppraisals.ToList();
            return View(aa);
        }

        // GET: ReviewAssociate - This page allows a partner to review an associate.  This is the whole point of the application.
        public ActionResult ReviewAssociate(int associateId, int appraisalId)
        {
            AssociateAppraisal aa = new AssociateAppraisal();
            aa.AssociateId = associateId;
            aa.AppraisalId = appraisalId;
            aa.Appraisal = entities.Appraisals.Include("AppraisalQuestion").Where(a => a.AppraisalId == appraisalId).FirstOrDefault();
            aa.Associate = entities.Associates.Include("AssociateWork").Where(a => a.AssociateId == associateId).FirstOrDefault();
            return View(aa);
        }


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