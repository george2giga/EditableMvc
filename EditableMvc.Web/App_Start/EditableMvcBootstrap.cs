using System;
using System.Web;
using System.Web.Optimization;
using EditableMvc.Web.EditableMvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EditableMvc.Web.EditableMvcBootstrap), "Start")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(EditableMvc.Web.EditableMvcBootstrap), "PostStart")]


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

        //After App_Start is executed register the bundles
        public static void PostStart()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/editableMvc").Include(
            "~/Scripts/jquery-ui-{version}.js",
            "~/Scripts/ckeditor/ckeditor.js",
            "~/Scripts/ckeditor/plugins/editablemvcsave/editablemvcsave.js",
            "~/Scripts/editablemvc.js"));
        }
    }

 
}