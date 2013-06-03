using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Facebook;
using Twitterizer;

namespace RCGovAnimalCareWebFormsApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string app_id = "145921825587690";
                string scope = "publish_stream,manage_pages";

                if (Request["code"] == null)
                {
                    Response.Redirect(string.Format(
                        "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                        app_id, Request.Url.AbsoluteUri, scope));
                }

            }
        }
        

        private void PostToFacebook(string bodymessage)
        {
            string app_id = "145921825587690";
            string app_secret = "12f3652f02febf35f9be331ba558cb0a";
            string scope = "publish_stream,manage_pages";

            if (Request["code"] == null)
            {
                Response.Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string vals = reader.ReadToEnd();

                    foreach (string token in vals.Split('&'))
                    {
                        tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }

                string access_token = tokens["access_token"];

                var client = new FacebookClient(access_token);

                client.Post("/rcgovlostpet/feed", new { message = bodymessage });
                ddlBreed.ClearSelection();
                ddlColor.ClearSelection();
                ddlSex.ClearSelection();
                ddlSize.ClearSelection();
                ddlType.ClearSelection();
                ddlYesNo.ClearSelection();
                txtPickupLocation.Text = String.Empty;
                txtPickedUp.Text = String.Empty;
                Label9.Text = "Successfully sent the message to social media";
            }
        }

        private void PostToTwitter(string message)
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
            string bodymessage = "#rcgovlostpet" + "\r\n" + 
                "Type: " + ddlType.SelectedItem.Text + "\r\n"
                + "Breed: " + ddlBreed.SelectedItem.Text + "\r\n"
                + "Size: " + ddlSize.SelectedItem.Text + "\r\n"
                + "Color: " + ddlColor.SelectedItem.Text + "\r\n"
                + "Pickup Location: " + txtPickupLocation.Text + "\r\n"
                + "Sex: " + ddlSex.SelectedItem.Text + "\r\n"
                + "Licensed: " + ddlYesNo.SelectedItem.Text + "\r\n"
                + "Date Picked Up: " + txtPickedUp.Text + "\r\n" 
                + "Picture: " + "http://animalcare.richlandonline.com/animalviewer/image.aspx?strpath=%2F%2F2020-1870-srv10%2FAnimalImages%2F5-27-13bonbon1.jpg";
           
            PostToFacebook(bodymessage);
            //PostToTwitter(bodymessage);
            //Server.Transfer("WebForm1.aspx");
        }   
    }
}