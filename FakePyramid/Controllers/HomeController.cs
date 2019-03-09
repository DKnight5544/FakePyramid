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

                var idParts = id.Split('|');
                string userID = idParts[0];

                //if there is a second parameter then we need to insert the
                //new user before we display the page.
                if (idParts.Length > 1)
                {
                    string newUserID = idParts[1];
                    db.User_Insert(userID, newUserID);
                    Response.Redirect("/" + newUserID);
                }

                //grab the user data and pass it to the view
                var userData = db.User_SelectByUserID(userID).SingleOrDefault();

                return View(userData);

            }
        }
    }
}