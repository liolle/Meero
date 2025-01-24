public static class RouteConfig
{
    public static void RegisterRoutes(WebApplication app){
        // Auth
        app.MapControllerRoute(
            name: "register",
            pattern: "{controller=User}/{action=Register}/{id?}"
        );

        app.MapControllerRoute(
            name: "register",
            pattern: "{controller=User}/{action=Login}/{id?}"
        );
    }
    
}