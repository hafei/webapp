﻿using System.Web.Mvc;

namespace WebApp.Areas.SysManage
{
    public class SysManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysManage_default",
                "Sys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "WebApp.Areas.SysManage.Controllers" }
            );
        }
    }
}