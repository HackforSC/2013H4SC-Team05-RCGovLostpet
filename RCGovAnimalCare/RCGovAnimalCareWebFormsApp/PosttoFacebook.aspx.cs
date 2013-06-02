using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;


namespace RCGovAnimalCareWebFormsApp
{
    public partial class PosttoFacebook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new FacebookClient();
                //dynamic me = client.Get("JValentinJesusFidelP");
                dynamic me = client.Get("bkraider");
                string firstName = me.first_name;
                string lastName = me.last_name;
                Label1.Text = firstName + " " + lastName;
            }
            catch (Exception ex)
            {
                Label3.Text = "Error Message: " + ex.Message + "Stack Trace: " + ex.StackTrace;
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var fb = new FacebookClient();
                dynamic result = fb.Get("oauth/access_token", new {
                    client_id = "145921825587690",
                    client_secret = "1202d75a2f85b0323497f924e9d252e0", 
                    grant_type    = "client_credentials" 
                });
                fb.AccessToken = result.access_token;
                
                var accessToken = fb.AccessToken;
                var client = new FacebookClient(accessToken);
                string status = "hello world";
                dynamic results = client.Post("/me/feed", new { message = status });
                //dynamic theApp = client.Get("145921825587690");
                //string appName = theApp.name;
                //Label2.Text = appName;
                //var args = new Dictionary<string, object>();
                //args["message"] = "hello world";
                //client.Post("/me/feed", args);
                //var accessToken = "145921825587690|-VCohPGxlYGoqtGrJR4lzPX5RTA";
                //FacebookClient app = new FacebookClient(accessToken);
                //var argList = new Dictionary<string, object>();
                //argList["message"] = "hello from bhanu";
                //app.Post("feed", argList);   
                //FacebookClient fbApp = new FacebookClient();
                //FacebookClient app = new FacebookClient("145921825587690|-VCohPGxlYGoqtGrJR4lzPX5RTA");
                //var args = new Dictionary<string, object>();
                //args["message"] = "abc";
                //args["caption"] = "This is caption!";
                //args["description"] = "This is description!";
                //args["name"] = "This is name!";
                //args["picture"] = "[your image URL]";
                //args["link"] = "[your link URL]";

                //app.Api("/me/feed", args, HttpMethod.Post);
                
            }
            catch (Exception ex)
            {
                Label3.Text = "Error Message: " + ex.Message + "Stack Trace: " + ex.StackTrace;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Text = String.Empty;
            Label2.Text = String.Empty;
            Label3.Text = String.Empty;
        }
    }
}