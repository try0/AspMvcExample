using FeedbackMessages.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{
    /// <summary>
    /// Ajax系サンプル
    /// </summary>
    public class AjaxExampleController : Controller
    {

        private List<ListExampleModel.User> UserList
        {
            get
            {
                return (List<ListExampleModel.User>)Session["AjaxExampleController.UserList"];
            }
            set
            {
                Session["AjaxExampleController.UserList"] = value;
            }
        }

        // GET: AjaxExample
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ユーザーリストビューを描画します。
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PartialUserListView()
        {
            Thread.Sleep(1000 * 3);

            if (UserList == null || UserList.Count == 0)
            {
                UserList = new List<ListExampleModel.User>
                {
                    new ListExampleModel.User()
                    {
                        UserId = "001",
                        UserName = "ユーザーA",
                        Age = 20
                    },
                    new ListExampleModel.User()
                    {
                        UserId = "002",
                        UserName = "ユーザーB",
                        Age = 30
                    },
                    new ListExampleModel.User()
                    {
                        UserId = "003",
                        UserName = "ユーザーC",
                        Age = 40
                    }
                };
            }


            var myViewData = new ViewDataDictionary(ViewData);
            // WebApp.MVC.Models.ListExampleModel.UserList とマッピングできるようにプレフィックス指定
            myViewData.TemplateInfo.HtmlFieldPrefix = "UserList";

            myViewData.Model = UserList;

            return new PartialViewResult
            {
                ViewData = myViewData,
                ViewName = "_UserList",
                TempData = TempData
            };

        }

        /// <summary>
        /// Postリクエストを処理します。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(WebApp.MVC.Models.ListExampleModel model)
        {

            foreach (var user in model.UserList)
            {
                this.InfoMessage(user.UserId + ", " + user.UserName + ", " + user.Age);
            }

            // 編集内容キープ
            UserList = model.UserList;

            return View(model);
        }

    }
}