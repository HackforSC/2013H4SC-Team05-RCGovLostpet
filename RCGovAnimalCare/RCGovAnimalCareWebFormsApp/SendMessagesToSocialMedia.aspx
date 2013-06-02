<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessagesToSocialMedia.aspx.cs" Inherits="RCGovAnimalCareWebFormsApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Automate sending messages to Social Media Sites</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label">
        <br />
        <br />
        </asp:Label>
    </div>
    </form>
</body>
</html>
