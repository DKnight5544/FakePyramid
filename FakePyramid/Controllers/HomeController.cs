using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakePyramid.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {

            if (string.IsNullOrWhiteSpace(id)) id = "WIGIWIZ";

            using (DWKDBDataContext db = new DWKDBDataContext())
            {
                var userData = db.User_SelectByUserID(id).SingleOrDefault();
                return View(userData);
            }
        }
    }
}