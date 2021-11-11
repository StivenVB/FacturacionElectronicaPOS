using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class UserController : BaseController
    {
        private UserImplController controller = new UserImplController();

        // GET: User
        public ActionResult Index(string filter = "")
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            UserModelMapper mapper = new UserModelMapper();
            IEnumerable<UserModel> userList = mapper.MapperT1T2(controller.RecordList(filter));
            return View(userList);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            RoleImplController roleController = new RoleImplController();
            RoleModelMapper roleMapper = new RoleModelMapper();
            IEnumerable<RoleModel> roles = roleMapper.MapperT1T2(roleController.RecordList(""));
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (RoleModel role in roles)
            {
                options.Add(new SelectListItem() { Text = role.Name, Value = role.Id.ToString() });
            }
            ViewBag.Roles = options;
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Lastname,Document,Cellphone,Email,City")] UserModel model, SelectListItem item)
        {
            if (ModelState.IsValid)
            {
                RoleImplController roleController = new RoleImplController();
                RoleModelMapper roleMapper = new RoleModelMapper();
                List<RoleModel> roles = new List<RoleModel>();
                roles.Add(roleMapper.MapperT1T2(roleController.RecordSearch(Int32.Parse(item.Value))));
                model.Roles = roles;
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapperT2T1(model);
                int response = controller.RecordCreation(dto);
                return this.ProcessResponse(response, model);
            }

            return View(model);
        }

        private ActionResult ProcessResponse(int response, UserModel model)
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

        // GET: User/Edit/5
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
            UserDTO dto = controller.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);
            RoleImplController roleController = new RoleImplController();
            RoleModelMapper roleMapper = new RoleModelMapper();
            IEnumerable<RoleModel> roles = roleMapper.MapperT1T2(roleController.RecordList(""));
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (RoleModel r in roles)
            {
                RoleModel role = model.Roles.Where(x => x.Id == r.Id).FirstOrDefault();
                if (role != null)
                {
                    ViewBag.UserRole = role;
                    options.Add(new SelectListItem() { Text = role.Name, Value = role.Id.ToString(), Selected = true });
                    continue;
                }
                options.Add(new SelectListItem() { Text = r.Name, Value = r.Id.ToString() });
            }
            ViewBag.Roles = options;
            return View(model);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Lastname,Document,Cellphone,Email,City")] UserModel model, SelectListItem item)
        {
            if (ModelState.IsValid)
            {
                RoleImplController roleController = new RoleImplController();
                RoleModelMapper roleMapper = new RoleModelMapper();
                List<RoleModel> roles = new List<RoleModel>();
                roles.Add(roleMapper.MapperT1T2(roleController.RecordSearch(Int32.Parse(item.Value))));
                model.Roles = roles;
                model.UserSessionId = Int32.Parse(Session["id"].ToString());
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapperT2T1(model);
                int response = controller.RecordUpdate(dto);
                return this.ProcessResponse(response, model);
            }
            return View(model);
        }

        // GET: User/Delete/5
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
            UserDTO dto = controller.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDTO dto = controller.RecordSearch(id);
            dto.UserSessionId = Int32.Parse(Session["id"].ToString());
            int response = controller.RecordRemove(dto);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            if (this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: User/Login
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        [CaptchaValidator(ErrorMessage = "Validación Captcha incorrecta.",
                  RequiredMessage = "La validación Captcha es requerida.")]
        public ActionResult IdentifyUser([Bind(Include = "Username,Password,Captcha")] LoginModel model, bool captchaValid)
        {
            if (!captchaValid)
            {
                return View();
            }
            UserDTO dto = new UserDTO()
            {
                Email = model.Username,
                Password = model.Password,
                CurrentDate = DateTime.Now
            };
            UserDTO login = controller.Login(dto);
            if (login == null)
            {
                ViewBag.ErrorMessage = "Datos inválidos";
                return View(model);
            } else
            {
                Session["username"] = login.Name + " " + login.Lastname;
                Session["token"] = dto.Token;
                Session["id"] = login.Id;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
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
