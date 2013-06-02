Imports System.Configuration.ConfigurationManager
Imports System.Data
Partial Class View
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack() Then
            DisplayImages()
        End If
    End Sub
    ''' <summary>
    ''' Displays the thumbnail images for the animals
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayImages()
        Dim ws As New animalimgs.animalimgs
        Dim ds As DataSet
        Try
            ds = ws.GetAnimalsInfo()
            dlImages.DataSource = ds
            dlImages.DataBind()

            ds = ws.GetAnimalsInfoCity()
            dlCityImages.DataSource = ds
            dlCityImages.DataBind()
        Catch ex As Exception
            HideShowPanels(0, 0, 1, "Error Loading Thumbnail Images.")
        End Try
    End Sub
    ''' <summary>
    ''' Gets the Animal Info for a specific Animal
    ''' </summary>
    ''' <param name="intAnimalID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAnimalInfoByID(ByVal intAnimalID As Integer) As DataSet
        Dim ws As New animalimgs.AnimalImgs
        Dim ds As New DataSet
        Try
            ds = ws.GetAnimalInfoByID(intAnimalID)

            Return ds
        Catch ex As Exception
            HideShowPanels(0, 0, 1, " An Error Occured While Retrieving Animal Info.")
            Return ds
        End Try
    End Function
    ''' <summary>
    ''' Displays the panel containing the full image and info of the animal that was clicked
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dlImages_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlImages.ItemCommand

        Try
            If e.CommandName = "Select" Then
                Dim ds As New DataSet
                Dim dr As DataRow
                Dim strImgName As String = ""
                Dim strAnimalID As String = CType(e.Item.FindControl("litAnimalID"), Literal).Text
                ds = GetAnimalInfoByID(strAnimalID)
                If ds IsNot Nothing And ds.Tables(0) IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
                    dr = ds.Tables(0).Rows(0)
                    strImgName = dr.Item("PhotoName").ToString
                    imgAnimalFull.ImageUrl = "~/image.aspx?strpath=" & AppSettings("ImgPath").ToString & _
                                dlImages.DataKeys(e.Item.ItemIndex).ToString.Trim & "&imgwidth=0&imgheight=0&intoriginal=1"
                    lblBreedFullVal.Text = IIf(IsDBNull(dr("AnimalBreedDescription")), "", dr("AnimalBreedDescription"))
                    lblColorFullVal.Text = IIf(IsDBNull(dr("AnimalColorDescription")), "", dr("AnimalColorDescription"))
                    lblDatePickedFullVal.Text = IIf(IsDBNull(dr("DatePickedUp")), "", dr("DatePickedUp"))
                    'lblLicenseFullVal.Text = IIf(IsDBNull(dr("DatePickedUp")), "", dr("DatePickedUp"))
                    Try
                        lblShelterID.Text = dr("ShelterID")
                    Catch ex As Exception
                        lblShelterID.Text = "N/A"
                    End Try
                    lblCityOrCounty.Text = "Richland County"
                    lblPickupLocVal.Text = IIf(IsDBNull(dr("PickUpAddressStreet")), "", dr("PickUpAddressStreet"))
                    lblSexFullVal.Text = IIf(IsDBNull(dr("AnimalSexDescription")), "", dr("AnimalSexDescription"))
                    lblSizeFullVal.Text = IIf(IsDBNull(dr("AnimalSizeDescription")), "", dr("AnimalSizeDescription"))
                    lblTypeFullVal.Text = IIf(IsDBNull(dr("AnimalTypeDescription")), "", dr("AnimalTypeDescription"))
                    If IsDBNull(dr("LicensedInd")) Then
                        lblLicenseFullVal.Text = "N/A"
                    Else
                        If CBool(dr("LicensedInd")) = True Then
                            lblLicenseFullVal.Text = "Yes"
                        Else
                            lblLicenseFullVal.Text = "No"
                        End If
                    End If
                End If
                HideShowPanels(0, 1, 0)
            End If
        Catch ex As Exception
            HideShowPanels(0, 0, 1, "Error Loading Selected Image.")
        End Try
    End Sub

    Protected Sub dlCityImages_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlCityImages.ItemCommand

        Try
            If e.CommandName = "Select" Then
                Dim ds As New DataSet
                Dim dr As DataRow
                Dim strImgName As String = ""
                Dim strAnimalID As String = CType(e.Item.FindControl("litAnimalID"), Literal).Text
                Using ws As New AnimalImgs.AnimalImgs
                    ds = ws.GetAnimalInfoByIDCity(strAnimalID)
                End Using

                If ds IsNot Nothing And ds.Tables(0) IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
                    dr = ds.Tables(0).Rows(0)
                    strImgName = dr.Item("PhotoName").ToString
                    imgAnimalFull.ImageUrl = "~/image.aspx?strpath=" & AppSettings("CityImgPath").ToString & _
                                dlCityImages.DataKeys(e.Item.ItemIndex).ToString.Trim & "&imgwidth=0&imgheight=0&intoriginal=1"
                    lblBreedFullVal.Text = IIf(IsDBNull(dr("AnimalBreedDescription")), "", dr("AnimalBreedDescription"))
                    lblColorFullVal.Text = IIf(IsDBNull(dr("AnimalColorDescription")), "", dr("AnimalColorDescription"))
                    lblDatePickedFullVal.Text = IIf(IsDBNull(dr("DatePickedUp")), "", dr("DatePickedUp"))
                    'lblLicenseFullVal.Text = IIf(IsDBNull(dr("DatePickedUp")), "", dr("DatePickedUp"))
                    Try
                        lblShelterID.Text = dr("ShelterID")
                    Catch ex As Exception
                        lblShelterID.Text = "N/A"
                    End Try
                    lblCityOrCounty.Text = "City Of Columbia"
                    lblPickupLocVal.Text = IIf(IsDBNull(dr("PickUpAddressStreet")), "", dr("PickUpAddressStreet"))
                    lblSexFullVal.Text = IIf(IsDBNull(dr("AnimalSexDescription")), "", dr("AnimalSexDescription"))
                    lblSizeFullVal.Text = IIf(IsDBNull(dr("AnimalSizeDescription")), "", dr("AnimalSizeDescription"))
                    lblTypeFullVal.Text = IIf(IsDBNull(dr("AnimalTypeDescription")), "", dr("AnimalTypeDescription"))
                    If IsDBNull(dr("LicensedInd")) Then
                        lblLicenseFullVal.Text = "N/A"
                    Else
                        If CBool(dr("LicensedInd")) = True Then
                            lblLicenseFullVal.Text = "Yes"
                        Else
                            lblLicenseFullVal.Text = "No"
                        End If
                    End If
                End If
                HideShowPanels(0, 1, 0)
            End If
        Catch ex As Exception
            HideShowPanels(0, 0, 1, "Error Loading Selected Image.")
        End Try
    End Sub

    ''' <summary>
    ''' Populates the Animal info in the data list control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dlImages_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlImages.ItemDataBound
        Try
            CType(e.Item.FindControl("imgAnimal"), ImageButton).ImageUrl = "~/image.aspx?strpath=" & AppSettings("ImgPath").ToString & _
                            dlImages.DataKeys(e.Item.ItemIndex).ToString.Trim & "&imgwidth=159&imgheight=121&intoriginal=0"
            CType(e.Item.FindControl("imgAnimal"), ImageButton).CommandName = "Select"
            CType(e.Item.FindControl("lblDtTime"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "DatePickedUp")), "", DataBinder.Eval(e.Item.DataItem, "DatePickedUp"))
            Try
                CType(e.Item.FindControl("lblShelterID"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "ShelterID")), "", DataBinder.Eval(e.Item.DataItem, "ShelterID"))
            Catch ex As Exception
                CType(e.Item.FindControl("lblShelterID"), Label).Text = "N/A"
            End Try
            CType(e.Item.FindControl("lblAnimalType"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "AnimalTypeDescription")), "", DataBinder.Eval(e.Item.DataItem, "AnimalTypeDescription"))
            CType(e.Item.FindControl("lblAnimalBreed"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "AnimalBreedDescription")), "", DataBinder.Eval(e.Item.DataItem, "AnimalBreedDescription"))
            CType(e.Item.FindControl("lblAnimalSex"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "AnimalSexDescription")), "", DataBinder.Eval(e.Item.DataItem, "AnimalSexDescription"))
            CType(e.Item.FindControl("litAnimalID"), Literal).Text = DataBinder.Eval(e.Item.DataItem, "AnimalID")
        Catch ex As Exception
            HideShowPanels(0, 0, 1, "Error Loading Thumbnail Images.")
        End Try
    End Sub

    Private Sub dlCityImages_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlCityImages.ItemDataBound
        Try
            CType(e.Item.FindControl("imgAnimal"), ImageButton).ImageUrl = "~/image.aspx?strpath=" & AppSettings("CityImgPath").ToString & _
                            dlCityImages.DataKeys(e.Item.ItemIndex).ToString.Trim & "&imgwidth=159&imgheight=121&intoriginal=0"
            CType(e.Item.FindControl("imgAnimal"), ImageButton).CommandName = "Select"
            CType(e.Item.FindControl("lblDtTime"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "DatePickedUp")), "", DataBinder.Eval(e.Item.DataItem, "DatePickedUp"))
            CType(e.Item.FindControl("lblShelterID"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "ShelterID")), "", DataBinder.Eval(e.Item.DataItem, "ShelterID"))
            CType(e.Item.FindControl("lblAnimalType"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "AnimalTypeDescription")), "", DataBinder.Eval(e.Item.DataItem, "AnimalTypeDescription"))
            CType(e.Item.FindControl("lblAnimalBreed"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "AnimalBreedDescription")), "", DataBinder.Eval(e.Item.DataItem, "AnimalBreedDescription"))
            CType(e.Item.FindControl("lblAnimalSex"), Label).Text = IIf(IsDBNull(DataBinder.Eval(e.Item.DataItem, "AnimalSexDescription")), "", DataBinder.Eval(e.Item.DataItem, "AnimalSexDescription"))
            CType(e.Item.FindControl("litAnimalID"), Literal).Text = DataBinder.Eval(e.Item.DataItem, "AnimalID")
        Catch ex As Exception
            HideShowPanels(0, 0, 1, "Error Loading Thumbnail Images.")
        End Try
    End Sub


    ''' <summary>
    ''' Hides and shows the panels for the thumbnail, full image, or error page.
    ''' </summary>
    ''' <param name="bolThumbs"> boolean for thumbnail panel</param>
    ''' <param name="bolFull">boolean for full image panel</param>
    ''' <param name="bolErr">boolean for Error Panel panel</param>
    ''' <param name="strErrMsg">Error Message to display in the Error Panel</param>
    ''' <remarks></remarks>
    Private Sub HideShowPanels(ByVal bolThumbs As Boolean, ByVal bolFull As Boolean, ByVal bolErr As Boolean, Optional ByVal strErrMsg As String = "")
        pnlThumbsView.Visible = bolThumbs
        pnlDetails.Visible = bolFull
        pnlErrMsg.Visible = bolErr
        If strErrMsg.Length > 0 Then
            lblErrorMsg.Text = strErrMsg
        Else
            lblErrorMsg.Text = String.Empty
        End If
    End Sub
    ''' <summary>
    ''' Returns to Thumbnail View
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        imgAnimalFull.ImageUrl = Nothing
        HideShowPanels(1, 0, 0)
    End Sub

    ''' <summary>
    ''' Returns to thumbnail view
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub imgAnimalFull_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAnimalFull.Click
        imgAnimalFull.ImageUrl = Nothing
        HideShowPanels(1, 0, 0)
    End Sub
End Class
