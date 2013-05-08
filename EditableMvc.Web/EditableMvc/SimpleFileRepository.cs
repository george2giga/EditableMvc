using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace EditableMvc.Web.EditableMvc
{
    /// <summary>
    /// Simple file repository class using xml and serialization
    /// </summary>
    public class SimpleFileRepository : IEditableRepository
    {

        /// <summary>
        /// Readonly Rootfolder (content storage)
        /// </summary>
        public string RootFolder { get; private set; }

        /// <summary>
        /// Constructor accepting the root folder where the content file will be saved
        /// </summary>
        /// <param name="rootFolder">Root folder</param>
        public SimpleFileRepository(string rootFolder)
        {
            RootFolder = rootFolder;
        }

        #region Implementation of IEditableRepository

        /// <summary>
        /// Save the editable content
        /// </summary>
        /// <param name="item">Editable content to save</param>
        public void Save(EditableContent item)
        {
            //if directory doesn't exist, create it
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(RootFolder)))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(RootFolder));

            var xmlFile = string.Format("{0}.xml", item.Id);
            var fullFileName = Path.Combine(RootFolder, xmlFile);
            using (var streamWriter = new StreamWriter(HttpContext.Current.Server.MapPath(fullFileName), false))
            {
                var xmlSerializer = new XmlSerializer(typeof(EditableContent));
                xmlSerializer.Serialize(streamWriter, item);
            }
        }

        /// <summary>
        /// Retrieve an editable item (content) by id.
        /// </summary>
        /// <param name="id">Editable content id (es: name)</param>
        /// <returns>Found editable content, if nothing found return null</returns>
        public EditableContent Get(string id)
        {
            EditableContent editableContent = null;
            var xmlFile = string.Format("{0}.xml", id);
            var fullFileName = Path.Combine(RootFolder, xmlFile);
            if (File.Exists(HttpContext.Current.Server.MapPath(fullFileName)))
            {
                using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(fullFileName), false))
                {
                    var xmlSerializer = new XmlSerializer(typeof (EditableContent));
                    var obj = xmlSerializer.Deserialize(streamReader.BaseStream);
                    editableContent = (EditableContent) obj;
                }
            }

            return editableContent;
        }

        #endregion
    }
}