using DynamicForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicForm.Controllers
{
    public class LoginController : Controller
    {
       

        // GET: Login
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User users)
        {
            if (ModelState.IsValid)
            {
                using (Model1 db = new Model1())
                {
                    var obj = db.Users.Where(a => a.username.Equals(users.username) && a.password.Equals(users.password)).FirstOrDefault();
                    if (obj != null)
                    {

                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();

                        return RedirectToAction("Index","Forms");
                    }

                    else
                    {
                        ViewBag.Uyari = "Kullanıcı adı ve şifreyi kontrol ediniz";
                        return View();
                    }
                }

            }
            return View(users);
        }


     
    }
}