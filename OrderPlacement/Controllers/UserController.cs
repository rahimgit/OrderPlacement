using OrderPlacement.Helper;
using OrderPlacement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
namespace OrderPlacement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveUser(User user)
        {
            
                orderplacementEntities8 db = new orderplacementEntities8();

                bool isSuccess = true;
            if (ModelState.IsValid)
            {
                try
                {
                    user.Status = 1;
                    user.Password = AppHelper.GetMd5Hash(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();

                }
                catch (Exception)
                {

                    isSuccess = false;
                }
            }
                return Json(isSuccess, JsonRequestBehavior.AllowGet);
            
            
           
          
            
        }


        

    }
}