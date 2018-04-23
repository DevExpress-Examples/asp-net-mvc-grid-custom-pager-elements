# GridView - How to create a custom "Select Page Size" element with the "Show All Records" feature


<p><strong>Problem:</strong><br />I wish to implement custom paging elements with the capability to show all records.<br /><br /><strong>Solution:</strong><br />Generally, it is possible to override the template for the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument3676">Pager</a> area using the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_SetPagerBarTemplateContenttopic2450">GridViewSettings.SetPagerBarTemplateContent(Action`1)</a> method. However, in this scenario the entire area with your custom template will be hidden once you set the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridViewPagerSettings_Modetopic">ASPxGridViewPagerSettings.Mode</a> property to the ShowAllRecords value. This is expected behavior. To overcome it, you can leave the default page UI and add custom pager elements to the  <a href="https://documentation.devexpress.com/#AspNet/CustomDocument3675">Footer</a> area by overriding its template instead using the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_SetFooterRowTemplateContenttopic2440">GridViewSettings.SetFooterRowTemplateContent(Action`1)</a> method.<br /><br /><strong>Note 1:</strong> Currently, there is no capability to replicate the default UI of the GridView's specific visual element within a template of this element. We have discussed this topic in the <a href="https://www.devexpress.com/Support/Center/p/S37728">S37728: Add the GridViewTemplateReplacement extension</a> ticket.<br /><br /><strong>Note 2:</strong> If necessary, you can display the "Show All Records" item in the "Select Page Size" element of the built-in pager without implementing custom templates:</p>


```cs
@Html.DevExpress().GridView(settings => {
    settings.Name = "GridView";
    settings.SettingsPager.PageSizeItemSettings.Visible = true;
    settings.SettingsPager.PageSizeItemSettings.ShowAllItem = true;
...
```




```vb
@Html.DevExpress().GridView( _
    Sub(settings)
        settings.Name = "GridView"
        settings.SettingsPager.PageSizeItemSettings.Visible = True
        settings.SettingsPager.PageSizeItemSettings.ShowAllItem = True
...
```



<br/>


