using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace lab2MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/Scripts").Include(
               "~/scripts/jquery-3.0.0.min.js", "~/scripts/jquery.validate.min.js",
               "~/scripts/jquery.validate.unobtrusive.min.js", "~/scripts/jquery.unobtrusive-ajax.min.js",
               "~/scripts/bootstrap.min.js","~/scripts/SiteScripts/site.js"));
            bundles.Add(new StyleBundle("~/Bundles/Styles").Include("~/Content/bootstrap.min.css"));
        }
    }
}