<%@ Page Language="VB" AutoEventWireup="false" CodeFile="View.aspx.vb" Inherits="View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Animal Care - View Animals</title>
    <link href="internet.css" rel="stylesheet" type="text/css" />
</head>
<body class="Backset">
    <!--#include file="header.htm"-->
    <form id="form1" runat="server">
    <div style="text-align:center">
    <center>
    
           <%-- <p class="MsoBodyText">The information for this page is updated 
	daily. If you do not see the animal you are looking for, check back 
	tomorrow. If you recognize your pet on this web site, please read <a href="http://localhost/AnimalCare/AnimalCareInternet/FAQ.asp#quest7"
class="Hyper1">What is the cost to redeem my animal</a> on the Frequently Asked 
	Questions Page and call Animal Care at (803) 576-2461 immediately<span style="font-weight:normal">.</span></p>--%>
  </center>
  <asp:Panel runat="server" HorizontalAlign="center" Width="800px">
  <p class="BodyText1" >The information for this page is updated 
	daily. If you do not see the animal you are looking for, check back 
	tomorrow. If you recognize your pet on this web site, please read <a href="http://animalcare.richlandonline.com/FAQ.asp#quest7"
class="Hyper1">What is the cost to redeem my animal</a> on the Frequently Asked 
	Questions Page and call Animal Care at (803) 576-2461 immediately<span style="font-weight:normal">.</span></p>
  </asp:Panel>
  <p class="BodyText1"> Click on the animal image to
  view detail information about the animal.</p>
        </div>
        <asp:Panel ID="pnlThumbsView" runat="server" HorizontalAlign="center">
              <table>
                <tr>
                    <td align="left">
                        <asp:DataList ID="dlImages" runat="server" DataKeyField="PhotoName" CssClass="UnderText1" 
                            RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10"   >
                            <ItemStyle BorderStyle="Double" BorderWidth="1pt" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgAnimal" runat="server"  style="border:1pt solid;" CommandName="Select" /><br />
                                <asp:Label ID="lblPickUP" runat="server" Text="Picked Up: " />
                                <asp:Label ID="lblDtTime" runat="server" Text="" /><br />
                                (Richland County) <br />
                                <asp:Label ID="Label1" runat="server" Text="Shelter ID: " />                                
                                <asp:Label ID="lblShelterID" runat="server" Text="" /><br />
                                <asp:Label ID="lblAnimalType" runat="server" Text="" /><br />
                                <asp:Label ID="lblAnimalBreed" runat="server" Text="" /><br />
                                <asp:Label ID="lblAnimalSex" runat="server" Text="" />
                                <asp:Literal ID="litAnimalID" runat="server" Visible="false" />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataList ID="dlCityImages" runat="server" DataKeyField="PhotoName" CssClass="UnderText1" 
                            RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Table" CellPadding="10"   >
                            <ItemStyle BorderStyle="Double" BorderWidth="1pt" />
                            <ItemTemplate>
                                <asp:ImageButton ID="imgAnimal" runat="server"  style="border:1pt solid;" CommandName="Select" /><br />
                                <asp:Label ID="lblPickUP" runat="server" Text="Picked Up: " />
                                <asp:Label ID="lblDtTime" runat="server" Text="" /><br />
                                 (City of Columbia)<br />
                                <asp:Label ID="Label1" runat="server" Text="Shelter ID: " />                                
                                <asp:Label ID="lblShelterID" runat="server" Text="" /><br />
                                <asp:Label ID="lblAnimalType" runat="server" Text="" /><br />
                                <asp:Label ID="lblAnimalBreed" runat="server" Text="" /><br />
                                <asp:Label ID="lblAnimalSex" runat="server" Text="" />
                                <asp:Literal ID="litAnimalID" runat="server" Visible="false" />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            
            </table></asp:Panel>
        <asp:Panel ID="pnlDetails" runat="server" HorizontalAlign="center" Visible="false" >
            <table class="UnderText1">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblDetail" runat="server" Text="Animal Detail" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:ImageButton ID="imgAnimalFull" runat="server"  CssClass="imagepg" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTypeFull" runat="server" Text="Type:" />
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTypeFullVal" runat="server"  />
                        
                    </td>
                    <td align="right">
                        <asp:Label ID="lblSexFull" runat="server" Text="Sex:" />
                    </td>
                    <td align="left" >
                        <asp:Label ID="lblSexFullVal" runat="server"  />
                        
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblBreedFull" runat="server" Text="Breed:" />
                    </td>
                    <td align="left">
                        <asp:Label ID="lblBreedFullVal" runat="server"  />
                        
                    </td>
                    <td align="right">
                        <asp:Label ID="lblLicenseFull" runat="server" Text="Licensed:" />
                    </td>
                    <td align="left" >
                        <asp:Label ID="lblLicenseFullVal" runat="server"  />
                        
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblSizeFull" runat="server" Text="Size:" />
                    </td>
                    <td align="left">
                        <asp:Label ID="lblSizeFullVal" runat="server"  />
                        
                    </td>
                    <td align="right">
                        <asp:Label ID="lblDatePickedFull" runat="server" Text="Date Picked Up:" />
                    </td>
                    <td align="left" >
                        <asp:Label ID="lblDatePickedFullVal" runat="server"  />                        
                    </td>
                    
                </tr>
                <tr>
                   <td align="right">
                        <asp:Label ID="lblColorFull" runat="server" Text="Color:" />
                    </td>
                    <td align="left" >
                        <asp:Label ID="lblColorFullVal" runat="server"  />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Shelter ID:" />
                    </td>
                    <td align="left" >
                        <asp:Label ID="lblShelterID" runat="server"  />                        
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                   <td align="right">
                        <asp:Label ID="lblPickupLoc" runat="server" Text="Pick Up Location:" />
                    </td>
                    <td align="left">
                        <asp:Label ID="lblPickupLocVal" runat="server"  />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCityOrCounty" runat="server" Text="" />
                    </td>
                </tr>
                
                <tr>
                    <td colspan="4" align="center">
                        <br />
                        <asp:LinkButton ID="btnReturn" runat="server">Return To Animal View</asp:LinkButton>
                    </td>
                </tr>
                
            </table>    
               
        </asp:Panel>
        <asp:Panel ID="pnlErrMsg" runat="server" CssClass="errmsg">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblErrorMsg" runat="server" Text="" />
                    </td>
                </tr>
                
            </table>
            
        </asp:Panel>
        
    </form>
    <!--#include file="footer.htm"-->
</body>
</html>
