using System;
using System.Web;
using EditableMvc.Web.EditableMvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EditableMvc.Web.EditableMvcBootstrap), "Start")]

namespace EditableMvc.Web
{
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
}