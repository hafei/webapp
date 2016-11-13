using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Services.IService;
using Services.ServiceImp;

namespace WebApp.Areas.SysManage.Controllers
{
    public class AccountController : Controller
    {

        #region 声明容器
        IUserManage UserManage;

        log4net.Ext.IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        #endregion

        // GET: SysManage/Account
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 登录验证
        /// add yuangang by 2016-05-16
        /// </summary>
        [ValidateAntiForgeryToken]
        public ActionResult Login(Domain.SYS_USER item)
        {
            var json = new JsonHelper() { Msg = "登录成功", Status = "n" };
            try
            {
                //调用登录验证接口 返回用户实体类
                var users = UserManage.UserLogin(item.ACCOUNT.Trim(), item.PASSWORD.Trim());
                if (users != null)
                {
                    //是否锁定
                    if (users.ISCANLOGIN == 1)
                    {
                        json.Msg = "用户已锁定，禁止登录，请联系管理员进行解锁";
                        //log4net.
                        return Json(json);
                    }
                    json.Status = "y";

                }
                else
                {
                    json.Msg = "用户名或密码不正确";
                }

            }
            catch (Exception e)
            {
                json.Msg = e.Message;
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}