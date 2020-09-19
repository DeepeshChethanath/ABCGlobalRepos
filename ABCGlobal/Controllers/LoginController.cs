using ABCGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCGlobal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            bool check = user.CheckLogin(user.userName, user.password);
            if (check == true)
            {
                return RedirectToAction("Candidate", "Candidate");
            }
                
            else
                return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            int i = user.Register(user);
            if (i > 0)
                return RedirectToAction("Candidate", "Candidate");
            else
                return RedirectToAction("Login", "Login");
        }
    }
}