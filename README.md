![ScreenShot](https://raw.github.com/george2giga/EditableMvc/master/ReadmeResources/editablemvclogosmall.PNG)
===========
The package provides persistent inline page editing using [CKEditor](http://ckeditor.com/).

###How it works:
The EditableMvc helper will render the specified selected html element and enable the inline editing functionality
of CKEditor. Once edited, the content is posted via ajax to a controller action and the data get saved through a
repository layer, which can be easily swapped (default storage is xml serialization on filesystem).

###Setup:
The default configuration deployed with the package enable the edit functionality when editablemvc=true is present 
in the querystring and setup the repository to use files. 

```C#

public static class EditableMvcBootstrap
{
    public static void Start()
    {
        //Register a custom repository by implementing IEditableRepository 
        EditableMvcConfig.RegisterRepository = () => new SimpleFileRepository("~/App_Data");

        //Register the authorization method used to enable/disable editing on the html element
        EditableMvcConfig.RegisterAuthorization = () =>
        {
            var editable = !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["editablemvc"]);
            if (editable)
            {
                return Convert.ToBoolean(HttpContext.Current.Request.QueryString["editablemvc"]);
            }
            return false;
        };
    }
}
```

###Use it:
Ensure all the required js (and optional style) are registered

```C#
@Scripts.Render("~/Scripts/ckeditor/ckeditor.js")
@Scripts.Render("~/Scripts/ckeditor/plugins/editablemvcsave/editablemvcsave.js")
@Scripts.Render("~/Scripts/editablemvc.js")
@Styles.Render("~/Content/editablemvcstyle.css")
```

Now that everything is in place, let's try the helper and generate an editable paragraph with some default text


```C#
<div id="content">
    @Html.EditableMvc("p", "idParagraph", new {@class = "mycssclass", "<strong>Lorem ipsum...</strong>")
</div>    

```
