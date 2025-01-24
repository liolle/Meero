public static class RouteConfig
{
    public static void RegisterRoutes(WebApplication app){
        app.MapControllerRoute(
            name: "register",
            pattern: "{controller=User}/{action=Register}/{id?}"
        );
    }
    
}