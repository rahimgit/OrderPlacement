using OrderPlacement.Helper;
using OrderPlacement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OrderPlacement.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizationFilter]
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AccessDenied()
        {

            return View();
        }


        public ActionResult Login()
        {
         
            return View();
        }

        public JsonResult CheckLogin(string username, string password)
        {
            orderplacementEntities8 db = new orderplacementEntities8();
            string md5StringPassword = AppHelper.GetMd5Hash(password);
            var dataItem = db.Users.Where(x => x.Username == username && x.Password == md5StringPassword).SingleOrDefault();
            bool isLogged = true;
            if (dataItem != null)
            {
                
                Session["Username"]=dataItem.Username;
                Session["Role"] = dataItem.Role;
                isLogged = true;
            }
            else
            {
                isLogged = false;
            }
            return Json(isLogged, JsonRequestBehavior.AllowGet);
        }

    }
}