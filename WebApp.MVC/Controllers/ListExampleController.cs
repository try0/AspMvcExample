using FeedbackMessages.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{
    /// <summary>
    /// リスト系コンポーネントのフォームバインディングサンプル
    /// </summary>
    public class ListExampleController : ExampleControllerBase
    {
        /// <summary>
        /// Getリクエストを処理します。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ListExampleModel();
            model.UserList.Add(new ListExampleModel.User()
            {
                UserId = "001",
                UserName = "ユーザーA",
                Age = 20
            });
            model.UserList.Add(new ListExampleModel.User()
            {
                UserId = "002",
                UserName = "ユーザーB",
                Age = 30
            });
            model.UserList.Add(new ListExampleModel.User()
            {
                UserId = "003",
                UserName = "ユーザーC",
                Age = 40
            });

            return View(model);
        }

        /// <summary>
        /// Postリクエストを処理します。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ListExampleModel model)
        {
            Debug.WriteLine(model.UserList.Count);

            foreach (var user in model.UserList)
            {
                this.InfoMessage(user.UserId + ", " + user.UserName + ", " + user.Age);
            }

            return View(model);
        }
    }
}