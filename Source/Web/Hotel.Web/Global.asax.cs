using Hotel.Web.Infrastructure.Mapping;
using Hotel.Web.ViewModels;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hotel.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig automapper = new AutoMapperConfig();
            automapper.Execute(typeof(IMapping).Assembly);
        }
    }
}
