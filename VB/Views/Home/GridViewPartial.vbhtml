@ModelType System.Collections.IEnumerable

@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "GridView"
            settings.KeyFieldName = "ProductID"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}

            settings.CustomActionRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewCallbackPartial"}

            settings.Columns.Add("ProductID")
            settings.Columns.Add("ProductName")
            settings.Columns.Add("UnitPrice")
            settings.Columns.Add("UnitsOnOrder")

            settings.Settings.ShowFooter = True
    
            settings.SetFooterRowTemplateContent( _
                Sub(c)
                        Html.RenderPartial("FooterRowPartial", c)
                End Sub)
            
            settings.BeforeGetCallbackResult = _
                 Sub(s, e)

                         If ViewData("pageSize") IsNot Nothing Then
                             Dim pageSize As Integer = Convert.ToInt32(ViewData("pageSize"))
                             Dim grid As MVCxGridView = CType(s, MVCxGridView)

                             If pageSize = -1 Then
                                 grid.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                             Else
                                 grid.SettingsPager.Mode = GridViewPagerMode.ShowPager
                                 grid.SettingsPager.PageSize = pageSize
                             End If
                         End If
                 End Sub

    End Sub).SetEditErrorText(CType(ViewData("EditError"), String)).Bind(Model).GetHtml()