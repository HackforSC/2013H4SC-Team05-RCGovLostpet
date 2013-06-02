using System;
using System.Web.Mvc;
using SocialCoding.FbAuth.Framework;

namespace SocialCoding.FbAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This application doesn't really allow you to do much without logging in.";
            ViewBag.Message1 = "The great news is that you can log in using the built-in membership or your Facebook account!";
            return View();
        }
        
        [Authorize]
        public ActionResult Post(String status)
        {
            var token = FbHelpers.AccessTokenRead(Request);
            if (String.IsNullOrEmpty(token))
                throw new InvalidOperationException("Can't find FB access token");

            FbHelpers.Post(token, status);
            return View("index");
        }

        [Authorize]
        public ActionResult PostPhoto(String status)
        {
            var token = FbHelpers.AccessTokenRead(Request);
            if (String.IsNullOrEmpty(token))
                throw new InvalidOperationException("Can't find FB access token");

            //var path = Server.MapPath("~/Content/Images/onserve.jpg");
            //FbHelpers.PostPicture(token, status, path);
            FbHelpers.Post(token, status);
            return View("index");
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }
    }
}
