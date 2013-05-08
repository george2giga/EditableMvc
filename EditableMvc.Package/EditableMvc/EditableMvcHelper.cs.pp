using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EditableMvc.Web.EditableMvc;

namespace $rootnamespace$
{
    /// <summary>
    /// Extension providing the EditableMvc html helper
    /// </summary>
    public static class HtmlHelpers
    {
        /// <summary>
        /// Helper rendering a choosen tag and enabling it for wysiwyg editor;
        /// </summary>
        /// <param name="helper">Current helper</param>
        /// <param name="tag">Html tag to render (Es: h1, div, li)</param>
        /// <param name="id">Element id</param>
        /// <param name="htmlAttributes">Object initializer of html attributes</param>
        /// <returns>Html of the renderend html element</returns>
        public static HtmlString EditableMvc(this HtmlHelper helper, string tag, string id, object htmlAttributes)
        {
            return EditableMvc(helper, tag, id, new RouteValueDictionary(htmlAttributes), null);
        }

        /// <summary>
        /// Helper rendering a choosen tag and enabling it for wysiwyg editor
        /// </summary>
        /// <param name="helper">Current helper</param>
        /// <param name="tag">Html tag to render (Es: h1, div, li)</param>
        /// <param name="id">Element id</param>
        /// <param name="htmlAttributes">Object initializer of html attributes</param>
        /// <param name="initialContent">Default initial content for element (Es: lorem ispum)</param>
        /// <returns>Html of the renderend html element</returns>
        public static HtmlString EditableMvc(this HtmlHelper helper, string tag, string id, object htmlAttributes, string initialContent)
        {
            return EditableMvc(helper, tag, id, new RouteValueDictionary(htmlAttributes), initialContent);
        }

        /// <summary>
        /// Helper rendering a choosen tag and enabling it for wysiwyg editor
        /// </summary>
        /// <param name="helper">Current helper</param>
        /// <param name="tag">Html tag to render (Es: h1, div, li)</param>
        /// <param name="id">Element id</param>
        /// <param name="htmlAttributes">Dictionary of html attributes</param>
        /// <param name="initialContent">Default initial content for element (Es: lorem ispum)</param>
        /// <returns>Html of the renderend html element</returns>
        public static HtmlString EditableMvc(this HtmlHelper helper, string tag, string id, IDictionary<string, object> htmlAttributes, string initialContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
        {
            //Retrieving registered configuration values
            var authorized = EditableMvcConfig.IsAuthorized();
            var repository = EditableMvcConfig.GetRepository();

            var editableContent = repository.Get(id);
            if (editableContent != null)
                initialContent = editableContent.Content;

            //Create tag builder
            var builder = new TagBuilder(tag) { InnerHtml = initialContent };
            
            //Create valid id
            builder.GenerateId(id);

            //Register the htmlattributes if present
            if(htmlAttributes!=null)
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            if (authorized)
            {
                builder.MergeAttribute("contenteditable", "true");
                builder.AddCssClass("editablemvc");
            }
            //Render tag
            return new HtmlString(builder.ToString());
        }

    }
}