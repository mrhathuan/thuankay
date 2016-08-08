using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop_Nhi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Cart
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Shop_Nhi.Controllers" }
           );


            //Product Category
            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatTitle}-{cateId}",
                defaults: new { controller = "Product", action = "ProductCategory", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //ListAll
            routes.MapRoute(
                name: "ListAll",
                url: "san-pham",
                defaults: new { controller = "Product", action = "ListAll", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //Search
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //Details
            routes.MapRoute(
                name: "Details",
                url: "chi-tiet/{metatTitle}-{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //giới thiệu
            routes.MapRoute(
                name: "Abouts",
                url: "gioi-thieu",
                defaults: new { controller = "Abouts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //giới thiệu
            routes.MapRoute(
                name: "Contacts",
                url: "lien-he",
                defaults: new { controller = "Contacts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //Hướng dẫn mua hàng
            routes.MapRoute(
                name: "HelpBuy",
                url: "huong-dan-mua-hang",
                defaults: new { controller = "HelpBuys", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //Gửi đơn hàng
            routes.MapRoute(
                name: "SendOrder",
                url: "gui-don-hang",
                defaults: new { controller = "Cart", action = "SendOrder", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //Trang thanh toán
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan-don-hang",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "Shop_Nhi.Controllers" }
                );

            //mua hàng thành công
            routes.MapRoute(
              name: "Success",
              url: "mua-hang-thanh-cong",
              defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "Shop_Nhi.Controllers" }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
