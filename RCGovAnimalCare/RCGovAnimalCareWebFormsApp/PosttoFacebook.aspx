<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PosttoFacebook.aspx.cs" Inherits="RCGovAnimalCareWebFormsApp.PosttoFacebook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get User Name" Width="154px" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Post to Facebook" Width="146px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Clear" Width="153px" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>
        <p>
        </p>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js" type="text/javascript"></script>
        <div id="fb-root">
        </div>
        <script>
            window.fbAsyncInit = function () {
                FB.init({ appId: '145921825587690', status: true, cookie: true,
                    xfbml: true
                });
            };
            (function () {
                var e = document.createElement('script'); e.async = true;
                e.src = document.location.protocol +
    '//connect.facebook.net/en_US/all.js';
                document.getElementById('fb-root').appendChild(e);
            } ());
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $( &#039;#share_button&#039; ).click(function (e) {
                    e.preventDefault();
                    FB.ui(
    {
        method: 'feed',
        name: 'jQuery Dialog',
        link: 'http://www.c-sharpcorner.com/authors/raj1979/raj-kumar.aspx',
        picture: 'http://www.c-sharpcorner.com/UploadFile/AuthorImage/raj1979.gif',
        caption: 'This article demonstrates how to use the jQuery dialog feature in ASP.Net.',
        description: 'First of all make a new website in ASP.Net and add a new stylesheet and add .js files and put images in the images folder and make a reference to the page.',
        message: 'hello raj message'
    });
                });
            });
        </script>




        <div>
            <input type="button" id="share_button" value="Share" />
        </div>
    </form>
</body>
</html>
