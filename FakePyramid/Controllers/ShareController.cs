using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakePyramid.Controllers
{
    public class ShareController : Controller
    {
        // GET: Share
        public ActionResult Index(string id)
        {

            if (string.IsNullOrWhiteSpace(id)) id = "WIGIWIZ";

            var idParts = id.Split('|');
            string userID = idParts[0];

            if (idParts.Length > 1)
            {
                using (DWKDBDataContext db = new DWKDBDataContext())
                {
                    string newUserID = idParts[1];
                    db.User_Insert(userID, newUserID);
                    Response.Redirect("/" + newUserID);
                }

            }

            var sponsorData = new FakePyramid.Models.ShareModel();

            sponsorData.SponsorName = userID;

            return View(sponsorData);
        }
    }
}