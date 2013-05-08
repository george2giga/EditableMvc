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
            EditableMvcConfig.RegisterRepository = () => new SimpleFileRepository("~/App_Data");
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