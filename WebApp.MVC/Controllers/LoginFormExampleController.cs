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
    /// <summary>
    /// ログインフォームサンプル
    /// </summary>
    public class LoginFormExampleController : ExampleControllerBase
    {
        /// <summary>
        /// Getリクエストを処理します。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Postリクエストを処理します。<br/>
        /// ログイン処理を実行します。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            // アノテーションで入力チェックが実行されます。
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.InfoMessage($"UserId:{model.UserId}");
            this.InfoMessage($"Password:{model.Password}");

            return View(model);
        }

    }
}