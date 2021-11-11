using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FEPOS.Helpers;
using FEPOS.Mapper.SecurityModule;
using FEPOS.Models.SecurityModule;
using FEPOSController.DTO.SecurityModule;
using FEPOSController.Implementation.SecurityModule;
using FEPOSModel.Model;

namespace FEPOS.Controllers.SecurityModule
{
    public class RoleController : BaseController
    {
        private RoleImplController controller = new RoleImplController();

        // GET: Role
        public ActionResult Index(string filter = "")
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            RoleModelMapper mapper = new RoleModelMapper();
            IEnumerable<RoleModel> roleList = mapper.MapperT1T2(controller.RecordList(filter));
            return View(roleList);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Role/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                int response = controller.RecordCreation(dto);
                return this.ProcessResponse(response, model);
            }
            return View(model);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDTO dto = controller.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RoleModelMapper mapper = new RoleModelMapper();
            RoleModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Role/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Removed,Description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                int response = controller.RecordUpdate(dto);
                return this.ProcessResponse(response, model);
            }
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private ActionResult ProcessResponse(int response, RoleModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDTO dto = controller.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RoleModelMapper mapper = new RoleModelMapper();
            RoleModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleDTO dto = controller.RecordSearch(id);
            int response = controller.RecordRemove(dto);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
