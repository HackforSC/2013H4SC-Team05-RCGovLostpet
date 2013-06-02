using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitterizer;

namespace RCGovAnimalCareWebFormsApp
{
    public partial class PostToTwitter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckAuthorization(string message)
        {
            var oauth_consumer_key = "e0eWxJc69u8xOBgZmxaPA";
            var oauth_consumer_secret = "gpyveiQsAJwe81pIlcD5WoteTYKm1auBSRtPKFXQXA";

            if (Request["oauth_token"] == null)
            {
                OAuthTokenResponse reqToken = OAuthUtility.GetRequestToken(
                    oauth_consumer_key,
                    oauth_consumer_secret,
                    Request.Url.AbsoluteUri);

                Response.Redirect(string.Format("http://twitter.com/oauth/authorize?oauth_token={0}",
                    reqToken.Token));

            }
            else
            {
                string requestToken = Request["oauth_token"].ToString();
                string pin = Request["oauth_verifier"].ToString();

                var tokens = OAuthUtility.GetAccessToken(
                    oauth_consumer_key,
                    oauth_consumer_secret,
                    requestToken,
                    pin);

                OAuthTokens accesstoken = new OAuthTokens()
                {
                    AccessToken = tokens.Token,
                    AccessTokenSecret = tokens.TokenSecret,
                    ConsumerKey = oauth_consumer_key,
                    ConsumerSecret = oauth_consumer_secret
                };

                TwitterResponse<TwitterStatus> response = TwitterStatus.Update(
                    accesstoken,
                    message);

                if (response.Result == RequestResult.Success)
                {
                    Response.Write("Posted to twitter successfully");
                }
                else
                {
                    Response.Write("Posting to twitter failed");
                }
            }
        }    

        protected void Button1_Click(object sender, EventArgs e)
        {

            string message = String.Empty;
            message = TextBox1.Text;
            CheckAuthorization(message);
        }
    }
}