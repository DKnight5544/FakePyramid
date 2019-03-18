using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.IO;
using FakePyramid.Models;

namespace FakePyramid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            if (!Request.IsLocal && !Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl, false);
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            if (string.IsNullOrWhiteSpace(id)) return View();

            using (DWKDBDataContext db = new DWKDBDataContext())
            {
                var userData = db.User_SelectByUserName(id).SingleOrDefault();

                if (userData == null)
                {
                    Response.Redirect("/");
                    //return View();
                }

                if (userData.UserName == null) return View("UpdateUserName", userData);
                else return View("User", userData);
            }
        }

        public ActionResult Validate(string id)
        {
            if (!Request.IsLocal && !Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl, false);
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                Response.Redirect("/");
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            var idParts = id.Split('|');
            string userName = idParts[0];
            string payeeName = idParts[1];
            string transID = idParts[2];

            string formData = "USER=davidwayneknight_api1.comcast.net"
                            + "&PWD=FBQGM3B8KTGEKWGK"
                            + "&SIGNATURE=AFcWxV21C7fd0v3bYYYRCpSSRl31AQH-bSM2NIkCPFvkQ1ILsP9k6vch"
                            + "&METHOD=GetTransactionDetails"
                            + "&TRANSACTIONID=" + transID
                            + "&VERSION=94";


            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(formData);

            WebRequest request = WebRequest.Create("https://api-3t.paypal.com/nvp");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var resp = request.GetResponse();

            Stream receiveStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            string content = reader.ReadToEnd();

            content = Server.UrlDecode(content);

            var isInvalid = content.Split('&').Any(x => x.Contains("ACK=Failure"));

            ValidationMessage msg = new ValidationMessage();
            msg.UserName = userName;

            if (isInvalid)
            {
                msg.Message = "BAD";
            }
            else
            {

                using (DWKDBDataContext db = new DWKDBDataContext())
                {
                    string amount = content.Split('&').Single(x => x.Contains("AMT")).Split('=')[1];
                    decimal actualAmount = decimal.Parse(amount);
                    var value = db.Setting_SelectByKey("GIFT_AMOUNT").SingleOrDefault();
                    decimal requiredAmount = decimal.Parse(value.Value);

                    if (actualAmount >= requiredAmount)
                    {
                        var userData = db.User_Insert(transID, userName, payeeName).SingleOrDefault();

                        if (userData == null)
                        {
                            Response.Redirect("/");
                        }
                        else
                        {
                            Response.Redirect("/" + userData.TransID);
                        }

                        HttpContext.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        msg.Message = "SMALL";
                        msg.RequiredAmount = requiredAmount;
                        msg.ActualAmount = actualAmount;
                    }
                }

            }

            return View(msg);

        }

        public void UpdateName(string id)
        {
            if (!Request.IsLocal && !Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl, false);
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                Response.Redirect("/");
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            var idParts = id.Split('|');
            string transID = idParts[0];
            string userName = idParts[1];

            using (DWKDBDataContext db = new DWKDBDataContext())
            {

                var userData = db.User_UpdateUserName(transID, userName).SingleOrDefault();

                if (userData == null)
                {
                    Response.Redirect("/");
                }
                else
                {
                    Response.Redirect("/" + userData.UserName);
                }

                HttpContext.ApplicationInstance.CompleteRequest();
            }
        }

        public ActionResult TestValidateView(string id)
        {
            ValidationMessage msg = new ValidationMessage();

            msg.UserName = "wigiwiz";
            msg.Message = "SMALL";
            msg.RequiredAmount = 10;
            msg.ActualAmount = 5;

            return View("Validate",msg);
        }

    }
}