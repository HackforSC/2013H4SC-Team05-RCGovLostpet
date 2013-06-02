Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.Drawing.Imaging


<WebService(Namespace:="http://richlandcounty.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AnimalImgs
    Inherits System.Web.Services.WebService

    <WebMethod()> _
            Public Function RetrieveImageByPath(ByVal strImagePath As String, _
                ByVal intImgWdth As Integer, ByVal intImgHt As Integer, _
                ByVal intOriginal As Integer) As Byte()
        '*****************************************************************
        '*****************************************************************
        ' Purpose -     Get image from server using impersonate, resize it
        '               then send it back as bytearray
        '*****************************************************************
        '*****************************************************************

        Dim fileLocation As String '= AppSettings("NoImgPath")
        Dim fullImage As System.Drawing.Image
        Dim fullImageFormat As System.Drawing.Imaging.ImageFormat
        Dim objStream As New MemoryStream
        Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort
        Dim thumbNailImg As System.Drawing.Image

        dummyCallBack = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

        If strImagePath.Substring(strImagePath.LastIndexOf("\") + 1).Trim.Length > 0 Then
            fileLocation = strImagePath
        Else
            fileLocation = AppSettings("NoImgPath")
        End If

        Using imper As New ImpersonateUtil()
            Dim val As Boolean = imper.Impersonate()
            If File.Exists(fileLocation) Then
                fullImage = System.Drawing.Image.FromFile(fileLocation)
            Else
                fullImage = System.Drawing.Image.FromFile(AppSettings("NoImgPath"))
            End If

            If intOriginal = 1 Then
                intImgWdth = fullImage.Width
                intImgHt = fullImage.Height
            End If

            fullImageFormat = ImageFormat.Jpeg

            Select Case intOriginal
                Case 0
                    thumbNailImg = fullImage.GetThumbnailImage(intImgWdth, intImgHt, _
                        dummyCallBack, IntPtr.Zero)
                Case 1
                    If File.Exists(fileLocation) Then
                        thumbNailImg = System.Drawing.Image.FromFile(fileLocation)
                    Else
                        thumbNailImg = System.Drawing.Image.FromFile(AppSettings("NoImgPath"))
                    End If

                Case Else
                    If File.Exists(fileLocation) Then
                        thumbNailImg = System.Drawing.Image.FromFile(fileLocation)
                    Else
                        thumbNailImg = System.Drawing.Image.FromFile(AppSettings("NoImgPath"))
                    End If
            End Select

            fullImage.Dispose() '   must dispose object or share connection problem
            thumbNailImg.Save(objStream, fullImageFormat)
            thumbNailImg.Dispose()
            imper.UndoImpersonation()

            Return objStream.ToArray()
        End Using

    End Function


    ''' <summary>
    ''' Gets Animal Info
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetAnimalsInfo() As DataSet
        Dim ds As New DataSet
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim p As SqlParameter
        Dim da As New SqlDataAdapter


        con.ConnectionString = ConfigurationManager.ConnectionStrings("AnimalConn").ToString
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = con
            .CommandTimeout = 120
            .CommandText = "usp_GetAnimalImages"
        End With
        da.SelectCommand = cmd
        da.Fill(ds)

        Return ds
    End Function

    <WebMethod()> _
    Public Function GetAnimalsInfoCity() As DataSet
        Dim ds As New DataSet
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim p As SqlParameter
        Dim da As New SqlDataAdapter


        con.ConnectionString = ConfigurationManager.ConnectionStrings("CityConn").ToString
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = con
            .CommandTimeout = 120
            .CommandText = "usp_GetAnimalImages"
        End With
        da.SelectCommand = cmd
        da.Fill(ds)

        Return ds
    End Function

    ''' <summary>
    ''' Gets animal info by ID
    ''' </summary>
    ''' <param name="intAnimalID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetAnimalInfoByID(ByVal intAnimalID As Integer) As DataSet
        Dim ds As New DataSet
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim da As New SqlDataAdapter
        Dim dr As DataRow

        con.ConnectionString = ConfigurationManager.ConnectionStrings("AnimalConn").ToString
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = con
            .CommandTimeout = 120
            .CommandText = "usp_GetAnimalInfoByID"
            .Parameters.AddWithValue("@AnimalID", intAnimalID)
        End With
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds

    End Function

    <WebMethod()> _
    Public Function GetAnimalInfoByIDCity(ByVal intAnimalID As Integer) As DataSet
        Dim ds As New DataSet
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim da As New SqlDataAdapter
        Dim dr As DataRow

        con.ConnectionString = ConfigurationManager.ConnectionStrings("CityConn").ToString
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Connection = con
            .CommandTimeout = 120
            .CommandText = "usp_GetAnimalInfoByID"
            .Parameters.AddWithValue("@AnimalID", intAnimalID)
        End With
        da.SelectCommand = cmd
        da.Fill(ds)
        Return ds

    End Function



    Private Function ThumbnailCallback() As Boolean
        Return False
    End Function

End Class
