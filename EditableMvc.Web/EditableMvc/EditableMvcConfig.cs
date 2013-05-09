using System;

namespace EditableMvc.Web.EditableMvc
{
    /// <summary>
    /// Bootstrapper class for the EditableMvc html helper.
    /// </summary>
    public static class EditableMvcConfig
    {

        ///// <summary>
        ///// Globally enable/disable the edit functionality for the helper. To override it register a custom function for RegisterAuthorization
        ///// </summary>
        //public static bool AuthorizeAll { get; set; }


        /// <summary>
        /// Lookup for a registered repository, if not present return the SimpleFileRepository
        /// </summary>
        /// <returns>Repository instance</returns>
        public static IEditableRepository GetRepository()
        {
            var repository = RegisterRepository() ?? new SimpleFileRepository("~/App_Data");

            return repository;
        }

        /// <summary>
        /// Execute the AuthorizeAccess function.
        /// </summary>
        /// <returns>true if user is authorized</returns>
        public static bool IsAuthorized()
        {
            if (RegisterAuthorization == null)
                return false;
            
            return RegisterAuthorization();
        }

        /// <summary>
        /// Consumer defined function used to register the repository (note: if none is defined the SimpleFileRepository will be used)
        /// </summary>
        public static Func<IEditableRepository> RegisterRepository { get; set; }

        /// <summary>
        /// Consumer defined function to authorize editing access.
        /// </summary>
        public static Func<bool> RegisterAuthorization { get; set; }
    }

}