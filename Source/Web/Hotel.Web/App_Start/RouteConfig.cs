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
                name: "Reserved",
                url: "reservetion/reserved",
                defaults: new { controller = "Reservation", action = "Reserved" });

            routes.MapRoute(
                name: "Create Entertainment",
                url: "entertainment/create",
                defaults: new { controller = "Entertainment", action = "Create" });
                                                    
            routes.MapRoute(                        
                name: "Edit Entertainment",         
                url: "entertainment/edit/{id}",     
                defaults: new { controller = "Entertainment", action = "Edit", id = UrlParameter.Optional });
                                                    
            //routes.MapRoute(                        
            //    name: "Delete Entertainment",       
            //    url: "entertainment/delete/{id}",   
            //    defaults: new { controller = "Entertainment", action = "Delete", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Hotel.Web.Controllers" }
            );
        }
    }
}
