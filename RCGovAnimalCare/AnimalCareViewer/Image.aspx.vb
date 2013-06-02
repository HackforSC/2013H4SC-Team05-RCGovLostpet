Imports System.Drawing
Imports System.Data
Partial Class Image
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strPath As String = Request.QueryString("strpath")
        Dim intOriginal As String = Request.QueryString("intoriginal")
        Dim intImgWdth As Integer = Request.QueryString("imgwidth")
        Dim intImgHt As Integer = Request.QueryString("imgheight")
        Dim fileLocation As String = "~/images/NoImage.gif"

        '   give default value if 0
        If intImgWdth = 0 Then intImgWdth = 159
        If intImgHt = 0 Then intImgHt = 121
        If intOriginal IsNot Nothing AndAlso (intOriginal = "1" Or intOriginal = "0") Then
            intOriginal = CInt(intOriginal)
        End If
        Response.Clear()
        Response.ClearHeaders()
        Response.ContentType = "image/JPEG"

        If strPath IsNot Nothing AndAlso strPath.Length > 0 Then
            Dim ws As New AnimalImgs.AnimalImgs
            Dim bytearray As Byte() = ws.RetrieveImageByPath(strPath, intImgWdth, intImgHt, intOriginal)
            Response.BinaryWrite(bytearray)
        Else
            Response.WriteFile(fileLocation, True)
        End If

        Response.Flush()
        Response.End()
    End Sub
End Class
