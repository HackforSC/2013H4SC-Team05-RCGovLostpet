using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using System.Web.Security;
using Facebook;
using SocialCoding.FbAuth.Framework;

namespace SocialCoding.FbAuth.Controllers
{
    public class AuthController : Controller
    {
        /// <summary>
        /// Starts the process that authenticates users via Facebook
        /// </summary>
        /// <returns>Redirect to FB</returns>
        public ActionResult FacebookLogin()
        {
            Contract.Requires<ArgumentNullException>(Request.Url != null);

            var returnUri = new UriBuilder(Request.Url)
                                {
                                    Path = Url.Action("FacebookAuthenticated", "Auth")
                                };

            var client = new FacebookClient();
            var fbLoginUri = client.GetLoginUrl(new
                                                {
                                                    client_id = ConfigurationManager.AppSettings["fb_key"],
                                                    redirect_uri = returnUri.Uri.AbsoluteUri,
                                                    response_type = "code",
                                                    display = "popup",
                                                    scope = "email,publish_stream"
                                                });


            return Redirect(fbLoginUri.ToString());
        }

        /// <summary>
        /// Handles the post-authentication step from Facebook
        /// </summary>
        /// <param name="returnUrl">Return URL, if any</param>
        /// <returns>Redirect to home/return URL</returns>
        public ActionResult FacebookAuthenticated(String returnUrl)
        {
            Contract.Requires<ArgumentNullException>(Request.Url != null);

            var redirectUri = new UriBuilder(Request.Url) { Path = Url.Action("FacebookAuthenticated", "Auth") };
            var client = new FacebookClient();
            var oauthResult = client.ParseOAuthCallbackUrl(Request.Url);

            // Exchange the code for an access token    
            dynamic result = client.Get("/oauth/access_token",
                                        new
                                        {
                                            client_id = ConfigurationManager.AppSettings["fb_key"],
                                            client_secret = ConfigurationManager.AppSettings["fb_secret"],
                                            redirect_uri = redirectUri.Uri.AbsoluteUri,
                                            code = oauthResult.Code,
                                        });

            var token = result.access_token;
            FbHelpers.AccessTokenSave(Response, token);

            dynamic user = client.Get("/me", new { fields = "first_name,last_name,email", access_token = token });

            //FormsAuthentication.SetAuthCookie(user.email, false);
            var userName = String.Format("{0} {1}", user.first_name, user.last_name);
            var cookie = FormsAuthentication.GetAuthCookie(userName, true);
            Response.AppendCookie(cookie);

            return Redirect(returnUrl ?? "/");
        }

        /// <summary>
        /// Logs off and redirects to the specified view.
        /// </summary>
        /// <param name="defaultAction">Action to redirect</param>
        /// <param name="defaultController">Controller to redirect</param>
        /// <returns>Redirect</returns>
        public ActionResult LogOff(String defaultAction = "Index", String defaultController = "Home")
        {
            FormsAuthentication.SignOut();
            FbHelpers.AccessTokenDelete(Request);
            return RedirectToAction(defaultAction, defaultController);
        }
    }
}
