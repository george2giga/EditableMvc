
namespace EditableMvc.Web.EditableMvc
{

    /// <summary>
    /// Interface to implement when creating a custom repository for editable content. It can be registered within the initial bootstrap.
    /// </summary>
    public interface  IEditableRepository
    {
        /// <summary>
        /// Save the editable content
        /// </summary>
        /// <param name="item">Editable content to save</param>
        void Save(EditableContent item);

        /// <summary>
        /// Retrieve an editable item (content) by id.
        /// </summary>
        /// <param name="id">Editable content id (es: name)</param>
        /// <returns>Found editable content, if nothing found return null</returns>
        EditableContent Get(string id);
    }
}