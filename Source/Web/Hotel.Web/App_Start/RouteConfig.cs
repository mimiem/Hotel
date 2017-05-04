using System.Web.Mvc;
using System.Web.Routing;

namespace Hotel.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "AllCategories",
                url: "categories",
                defaults: new { controller = "Images", action = "CategoriesImages" });

            routes.MapRoute(
                name: "Add",
                url: "reservetion",
                defaults: new { controller = "Reservation", action = "Add" });

            routes.MapRoute(
                name: "Not Available",
                url: "reservetion/cheked",
                defaults: new { controller = "Reservation", action = "NotAvailable" });

            routes.MapRoute(
                name: "Confirm",
                url: "reservetion/confirm",
                defaults: new { controller = "Reservation", action = "Confirm" });

            routes.MapRoute(
                name: "Reserved",
                url: "reservetion/reserved",
                defaults: new { controller = "Reservation", action = "Reserved" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
