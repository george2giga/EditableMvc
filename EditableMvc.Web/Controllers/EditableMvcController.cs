using System;
using System.Web.Mvc;
using EditableMvc.Web.EditableMvc;

namespace EditableMvc.Web.Controllers
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
            var success = false;

            if (Request.IsAjaxRequest())
            {
                //update the modified date
                model.ModifiedDate = DateTime.Now;
                _repository.Save(model);
                success = true;
            }

            return Json(success);
        }

    }
}
