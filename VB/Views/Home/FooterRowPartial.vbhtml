@ModelType GridViewFooterRowTemplateContainer

@Code
    Dim pageSizes() As Integer = {10, 20, 30}
End Code

@Html.DevExpress().ComboBox( _
    Sub(settings)
            settings.Name = "cbPageSize"
            settings.Width = System.Web.UI.WebControls.Unit.Pixel(50)

            For i As Integer = 0 To pageSizes.Length - 1
                settings.Properties.Items.Add(pageSizes(i).ToString(), pageSizes(i))
            Next i

            settings.Properties.Items.Add("All", -1)
    
            If Model.Grid.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords Then
                settings.SelectedIndex = settings.Properties.Items.Count - 1
            Else
                settings.SelectedIndex = Array.IndexOf(pageSizes, Model.Grid.SettingsPager.PageSize)
            End If

            settings.Properties.ClientSideEvents.SelectedIndexChanged = "function(s, e) { GridView.PerformCallback({ pageSize: s.GetValue() }); }"
    End Sub).GetHtml()