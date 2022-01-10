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
    /// PartialViewフォームバインディングサンプル<br/>
    /// <see cref="WebApp.MVC.Core.Extensions.HtmlHelperExtensions.RenderPartialFor{TModel, TProperty}(HtmlHelper{TModel}, string, System.Linq.Expressions.Expression{Func{TModel, TProperty}})"/>
    /// </summary>
    public class PartialViewExampleController : ExampleControllerBase
    {
        // GET: PartialViewExample
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PartialViewExampleModel();

            model.TimeList.Add(new TimeModel
            {
                Hour = 8,
                Minute = 30
            });
            model.TimeList.Add(new TimeModel
            {
                Hour = 9,
                Minute = 30
            });

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PartialViewExampleModel model)
        {
            foreach (var time in model.TimeList)
            {
                this.InfoMessage(time.Hour + ":" + time.Minute);
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Nested()
        {

            var root = new NestedPartialViewModel
            {
                Value = "1"
            };
            CreateChildModel(root, 2);

            return View(root);
        }

        [HttpPost]
        public ActionResult Nested(NestedPartialViewModel model)
        {
            Print(model, "");

            return View(model);
        }

        private void CreateChildModel(NestedPartialViewModel model, int depth)
        {

            if (depth == 4)
            {
                return;
            }
            var rnd = new Random();
            var childDepth = depth + 1;
            for (int i = 0; i < Math.Max(1, rnd.Next(5)); i++)
            {
                var child = new NestedPartialViewModel();
                model.Children.Add(child);

                child.Value = model.Value + "_" + (i + 1);
                child.Parent = model;


                CreateChildModel(child, childDepth);
            }

        }

        private void Print(NestedPartialViewModel model, string prefix)
        {
            this.InfoMessage(prefix + model.Value);

            foreach (var child in model.Children)
            {
                Print(child, prefix + "　");
            }
        }
    }
}