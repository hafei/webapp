using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using ToDoListBLL;

namespace ToDoList.Controllers
{
    public class UserInfoController : Controller
    {
        UserInfoBll bll = new UserInfoBll();
        // GET: UserInfo
        public ActionResult Index()
        {

            var model = bll.GetUserInfo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(UserInfo model)
        {
            //UserInfoBll 
            bll.Add(model);
            return View();
        }

        public ActionResult Add()
        {
            UserInfo model = new UserInfo();
            return View(model);
        }
    }
}