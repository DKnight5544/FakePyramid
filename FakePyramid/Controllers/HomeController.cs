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
                var userData = db.User_Select(id).SingleOrDefault();

                if (userData == null)
                {
                    Response.Redirect("/");
                    //return View();
                }

                if (string.IsNullOrWhiteSpace(userData.UserName)) return View("Update", userData);
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
            string transID = idParts[1];

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
                    var value = db.Setting_SelectByKey("GIFT_AMOUNT").SingleOrDefault();
                    string payeeID = content.Split('&').Single(x => x.Contains("RECEIVERID")).Split('=')[1];
                    string newUserID = content.Split('&').Single(x => x.Contains("PAYERID")).Split('=')[1];


                    decimal actualAmount = decimal.Parse(amount);
                    decimal requiredAmount = decimal.Parse(value.Value);

                    if (actualAmount >= requiredAmount)
                    {
                        var userData = db.User_Insert(payeeID, newUserID, userName).SingleOrDefault();

                        if (userData == null)
                        {
                            Response.Redirect("/");
                        }
                        else
                        {
                            Response.Redirect("/home/index/" + userData.UserName);
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

        public void Update(string id)
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
            string UserID = idParts[0];
            string userName = idParts[1];

            using (DWKDBDataContext db = new DWKDBDataContext())
            {

                var userData = db.User_Update(UserID, userName).SingleOrDefault();

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

            return View("Validate", msg);
        }


        public ActionResult Customize(string id)
        {
            if (!Request.IsLocal && !Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl, false);
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            if (string.IsNullOrWhiteSpace(id)) return View("/Index");


            using (DWKDBDataContext db = new DWKDBDataContext())
            {

                string userName;
                string imageURL;
                string buttonText;
                UserView userData;

                string[] idParts = id.Split('|');
                userName = idParts[0];

                if (id.Length == 3)
                {
                    imageURL = idParts[1];
                    buttonText = idParts[2];
                    userData = db.User_Customize(userName, imageURL, buttonText).SingleOrDefault();
                }
                else
                {
                    userData = db.User_Select(userName).SingleOrDefault();
                }


                if (userData == null) Response.Redirect("/");
                return View("Customize", userData);


            }
        }

        [HttpPost]
        public ActionResult UpdateButton(ButtonCustomizations formData)
        {
            if (!Request.IsLocal && !Request.IsSecureConnection)
            {
                string redirectUrl = Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(redirectUrl, false);
                HttpContext.ApplicationInstance.CompleteRequest();
            }

            using (DWKDBDataContext db = new DWKDBDataContext())
            {

                var userData = db.User_Customize(
                    formData.UserName, 
                    formData.ImageUrl, 
                    formData.ButtonText
                    ).SingleOrDefault();

                if (userData == null) Response.Redirect("/");
                return View("Customize", userData);


            }
        }

    }
}