using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApp.MVC.Core.Extensions
{
    public static class HtmlHelperExtensions
    {

        /// <summary>
        /// ネストされたPartialViewを考慮したモデルバインディングに対応する描画処理
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="expression"></param>
        public static void RenderPartialFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            string partialViewName,
            Expression<Func<TModel, TProperty>> expression)
        {


            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var model = metadata.Model;


            var oldTemplateInfo = htmlHelper.ViewData.TemplateInfo;

            var newPrefix = ExpressionHelper.GetExpressionText(expression);
            if (oldTemplateInfo.HtmlFieldPrefix.Length > 0)
            {
                // 呼び出し元のExpression考慮

                if (newPrefix.StartsWith("[") && newPrefix.EndsWith("]"))
                {
                    // 配列バインディング考慮
                    // old: UserList new: [0] →　UserList[0]
                    newPrefix = oldTemplateInfo.HtmlFieldPrefix + newPrefix;
                }
                else
                {
                    // old: User new: Name → User.Name
                    newPrefix = oldTemplateInfo.HtmlFieldPrefix + (string.IsNullOrEmpty(newPrefix) ? "" : "." + newPrefix);
                }

            }


            var templateInfo = new TemplateInfo
            {
                HtmlFieldPrefix = newPrefix,
            };


            var viewData = new ViewDataDictionary(htmlHelper.ViewData)
            {
                TemplateInfo = templateInfo,
            };

            htmlHelper.RenderPartial(partialViewName, model, viewData);
        }
    }
}
