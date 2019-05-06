using DynamicForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicForm.Controllers
{
    public class FormsController : Controller
    {
        Model1 db = new Model1();
        // GET: Forms2
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetList()
        {
            List<ListModel> List = db.Forms.Select(x => new ListModel
            {
                id = x.id,
                ad = x.ad,
                soyad = x.soyad,
                yas = x.yas,

            }).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetFormById(int Id)
        {
            Form model = db.Forms.Where(x => x.id == Id).SingleOrDefault();
            string value = string.Empty;

            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);


        }

        public JsonResult SaveForm(Form form)
        {
            var result = false;

            if (form.id > 0)
            {
                return Json(form, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Form f = new Form();
                f.ad = form.ad;
                f.soyad = form.soyad;
                f.yas = form.yas;
                db.Forms.Add(f);
                db.SaveChanges();
                result = true;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Search(string Ara)
        {
            if (ModelState.IsValid)
            {

                var ara = db.Forms.Where(x => x.ad.Contains(Ara)).ToList();
                return View(ara);
            }
            else
            {
                return Json("hata oluştu");
            }



        }
    }
}