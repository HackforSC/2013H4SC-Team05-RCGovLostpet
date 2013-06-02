using System;
using System.Configuration;
using System.IO;
using System.Web;
using Facebook;

namespace SocialCoding.FbAuth.Framework
{
    public class FbHelpers
    {
        private static readonly String CookieName = ConfigurationManager.AppSettings["fb_key"];

        public static void AccessTokenSave(HttpResponseBase response, String token)
        {
            var cookie = new HttpCookie(CookieName, token) {Expires = DateTime.Now.AddDays(1)};
            response.AppendCookie(cookie);
        }

        public static String AccessTokenRead(HttpRequestBase request)
        {
            var cookie = request.Cookies[CookieName];
            return cookie != null ? cookie.Value : null;
        }

        public static void AccessTokenDelete(HttpRequestBase request)
        {
            request.Cookies.Remove(CookieName);
        }

        public static void Post(String token, String status)
        {
            var client = new FacebookClient(token);
            dynamic result = client.Post("/me/feed", new { message = status });
            var x = 0;
        }

        public static void PostPicture(String token, String status, String path)
        {
            var client = new FacebookClient(token);
            using (var stream = File.OpenRead(path))
            {
                dynamic result = client.Post("me/photos",
                                             new
                                                 {
                                                     message = status,
                                                     file = new FacebookMediaStream
                                                                {
                                                                    ContentType = "image/jpg", 
                                                                    FileName = Path.GetFileName(path)
                                                                }.SetValue(stream)
                                                 });
            }
        }
    }
}