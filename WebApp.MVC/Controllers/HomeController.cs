using FeedbackMessages.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{

    public class HomeController : ExampleControllerBase
    {
        /// <summary>
        /// Getリクエストを処理します。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return new RedirectResult("/LoginFormExample/");
        }

     

    }
}