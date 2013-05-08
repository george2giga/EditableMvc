using System;
using System.Web.Mvc;
using EditableMvc.Web.EditableMvc;


namespace $rootnamespace$.Controllers
{
    public class EditableMvcController : Controller
    {
        private IEditableRepository _repository = null;

        public EditableMvcController()
        {
            _repository = EditableMvcConfig.GetRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Edit the content of this page";

            return View();
        }

        [HttpPost]
        public ActionResult Update(EditableContent model)
        {
            //update the modified date
            model.ModifiedDate = DateTime.Now;
            _repository.Save(model);

            return Json(new { success = true });
        }

    }
}
