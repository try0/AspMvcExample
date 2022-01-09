using FeedbackMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static FeedbackMessages.FeedbackMessage;

namespace WebApp.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FeedbackMessageSettings.CreateInitializer()
                .SetMessageRendererFactory(() =>
                {

                    var messageRenderer = new FeedbackMessageRenderer
                    {
                        OuterTagName = "div",
                        InnerTagName = "div"
                    };

                    messageRenderer.AppendOuterAttributeValue(FeedbackMessageLevel.INFO, "class", "alert alert-info");
                    messageRenderer.AppendOuterAttributeValue(FeedbackMessageLevel.SUCCESS, "class", "alert alert-success");
                    messageRenderer.AppendOuterAttributeValue(FeedbackMessageLevel.WARN, "class", "alert alert-warning");
                    messageRenderer.AppendOuterAttributeValue(FeedbackMessageLevel.ERROR, "class", "alert alert-danger");


                    return messageRenderer;
                })
                .Initialize();
        }
    }
}
