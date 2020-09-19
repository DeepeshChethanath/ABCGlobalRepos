using ABCGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCGlobal.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        [HttpGet]
        public ActionResult Candidate()
        {
            CandidateModel candiModel = new CandidateModel();
            candiModel.GetCountry();
            candiModel.GetCandidateList();
            return View(candiModel);
        }

        [HttpPost]
        public ActionResult CandidateDelete(string id)
        {
            CandidateModel comm = new CandidateModel();
            bool statuss = comm.DeleteCandidate(id);
            return RedirectToAction("Candidate", "Candidate");
        }

        public ActionResult ViewCandidate(int id)
        {
            CandidateModel candi = new CandidateModel();
            return View(candi.GetCandidate(id));
        }

        public ActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCandidate(CandidateModel candiModel)
        {
            int i = candiModel.AddCandidate(candiModel);
            if (i > 0)
                return RedirectToAction("Candidate", "Candidate");
            else
                return RedirectToAction("AddCandidate", "AddCandidate");
        }
    }
}