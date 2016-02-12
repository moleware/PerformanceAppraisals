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

            // Pass in the current appraisalId because we shouldn't be using this app outside of the February - July window.
            Helpers.Session.Current.CurrentAppraisalId = entities.Appraisals.Where(aa => aa.ReviewYear == DateTime.Now.Year).FirstOrDefault().AppraisalId;

            // If the current user is an Associate, forward them on to the IdentifyPartners page
            if (Helpers.UserType.UserTypes.Associate.ToString() == Helpers.Session.Current.UserType)
                return RedirectToAction("IdentifyPartners", "Home", new
                {
                    employeeId = AssociateAppraisals.Helpers.Session.Current.EmployeeId,
                    appraisalId = AssociateAppraisals.Helpers.Session.Current.CurrentAppraisalId
                });

            IEnumerable<Appraisal> appraisals = entities.Appraisals.ToList();
            return View(appraisals);
        }

        // GET: IdentifyPartners - Takes the user to a page where they can identify the partners they worked with most
        public ActionResult IdentifyPartners(int employeeId, int appraisalId)
        {
            // Set a variable in the session to hold our appraisalId
            //Helpers.Session.Current.AppraisalId = appraisalId;

            // Identify and return only work relevant to this appraisal.
          //  PartnerViewModel pvm = new PartnerViewModel();
            List<AssociateWork> assWorks = entities.AssociateWorks.Include("Partner").Where(a => a.EmployeeId == employeeId && a.AppraisalId == appraisalId).ToList();
            List<AssociateWorkViewModel> assWorkVM = new List<AssociateWorkViewModel>();

            foreach(AssociateWork assWork in assWorks)
            {
                int assPartner = -1;
                int.TryParse(assWork.PartnerEmployeeId.ToString(), out assPartner);
                assWorkVM.Add(new AssociateWorkViewModel(assWork, assPartner));
            }

            return View(assWorkVM);
        }

        // POST: IdentifyPartners - Updates the AssociateWork table with the partners identified
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IdentifyPartners(ICollection<int> AssociateWorkId, ICollection<int> EmployeeId, ICollection<string> ClientName, ICollection<string> ClientMatter, ICollection<string> MatterName, ICollection<float> Hours, ICollection<int> PartnerEmployeeId)
        {
            /*  WARNING - This is a good way to check for errors in the ModelState
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                string poop = error.ToString();
            }*/

            try
            {
                if (ModelState.IsValid)
                {
                    int count = 0;
                    foreach (AssociateWork assWork in entities.AssociateWorks)
                    {
                        if (assWork.AssociateWorkId == AssociateWorkId.ElementAt(count))
                        {
                            assWork.PartnerEmployeeId = PartnerEmployeeId.ElementAt(count);
                            count++;
                            entities.SaveChanges();
                        }
                    }
                    
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("SAVE_ERR", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            catch (Exception ex)
            {
                string poop = ex.Message;
            }
            return RedirectToAction("Error", "Home");  // WARNING = This isn't right at all, but at least I'll know we err'd
                                                       // if we're here, the DB did not update.
        }


        // GET: AssociatesForReview - Takes the partner to a page where they see a list of all associates they have worked with.
        public ActionResult AssociatesForReview(int appraisalId)
        {
            IEnumerable<AssociateAppraisal> aa = entities.AssociateAppraisals.ToList();
            return View(aa);
        }

        // GET: ReviewAssociate - This page allows a partner to review an associate.  This is the whole point of the application.
        public ActionResult ReviewAssociate(int employeeId, int appraisalId)
        {
            AssociateAppraisal aa = new AssociateAppraisal();
            aa.EmployeeId = employeeId;
            aa.AppraisalId = appraisalId;
            aa.Appraisal = entities.Appraisals.Include("AppraisalQuestion").Where(a => a.AppraisalId == appraisalId).FirstOrDefault();
            aa.Associate = entities.Associates.Include("AssociateWork").Where(a => a.EmployeeId == employeeId).FirstOrDefault();
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