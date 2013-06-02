<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessagesToSocialMedia.aspx.cs" Inherits="RCGovAnimalCareWebFormsApp.WebForm1" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Richland County Animal Care</title>
    <link href="css/bootstrap.css" rel="stylesheet" media="screen">
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="css/bootstrap-responsive.css" rel="stylesheet" media="screen">
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" media="screen">
    <script src="js/bootstrap.js"></script>
    <script src="js/bootstrap-min.js"></script>
    <script>(function () { var cx = '006414237267533834208:hqkkkr8vzys'; var gcse = document.createElement('script'); gcse.type = 'text/javascript'; gcse.async = true; gcse.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//www.google.com/cse/cse.js?cx=' + cx; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(gcse, s); })();</script>
</head>
<body>

    <form id="form1" runat="server">
        <!--Begin Navigation for the page-->
        <div class="container">
            <div class="head">
                <div class="row-fluid">
                    <div class="span12">
                        <ul class="breadcrumb">
                            <li class="active"><a href="#">Home</a></li>
                        </ul>
                    </div>
                    <div class="span12">
                        <div class="span9">
                            <h1 class="muted"><a href="main.html">
                                <img border="0" src="Images/animalcare_logo.png"></a>Richland County Animal Care</h1>
                        </div>
                        <div class="span1"></div>
                        <div class="span3" style="margin-top: 15px;">
                            <form method="get" action="function()" class="form-inline">
                                <p>
                                    <input name="q" size="2" type="text" placeholder="Search our site">
                                    <button type="submit" class="btn btn-primary"><i class="icon-search icon-white"></i></button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="navbar">
                <div class="navbar-inner">
                    <div class="container">
                        <%--                        <ul class="nav">
                            <li class="active"><a href="Main.html">Home</a></li>
                            <li><a href="Facts.html">Facts To Know</a></li>
                            <li><a href="FAQ.html">FAQ</a></li>
                            <li><a href="License.html">Licensing</a></li>
                            <li><a href="animalviewer/View.html">View Animals</a></li>
                            <!--<li><a href="AnimalZone.html">Pet Zone</a></li>						-->
                            <li><a href="Links.html">Links</a></li>
                        </ul>--%>
                    </div>
                    <div>
                        <asp:Label ID="lblType" runat="server" Text="Type">  </asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="txtType" runat="server" align="right"></asp:TextBox>
                        <%--        <select>
            <option value="1">Dog</option>
            <option value="2">Cat</option>
            <option value="3">Rabbit</option>
            <option value="4">Snake</option>
        </select>--%>
                        <br />
                        <br />
                        <asp:Label ID="lblBreed" runat="server" Text="Breed">  </asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBreed" runat="server" align="right"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblSize" runat="server" Text="Size">  </asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSize" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblColor" runat="server" Text="Color">  </asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblPickupLocation" runat="server" Text="Pick Up Location">  </asp:Label>
                        &nbsp;&nbsp;
        <asp:TextBox ID="txtPickupLocation" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblSex" runat="server" Text="Sex">  </asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSex" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblLicensed" runat="server" Text="Licensed">  </asp:Label>
                        &nbsp;&nbsp;
                    <asp:TextBox ID="txtLicensed" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblDatePickedUp" runat="server" Text="DatePickedUp">  </asp:Label>
                        &nbsp;&nbsp;
                    <asp:TextBox ID="txtPickedUp" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <%--        <select>
            <option value="1">Male</option>
            <option value="2">Female</option>
        </select>--%>
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Send Messages to Social Media" OnClick="Button1_Click" />
                        <br />
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="">  </asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <!--End Navigation for the page-->

    </form>
</body>
</html>
