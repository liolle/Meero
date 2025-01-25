public static class RouteConfig
{
    public static void RegisterRoutes(WebApplication app){
        // Auth
        app.MapControllerRoute(
            name: "register",
            pattern: "{controller=User}/{action=Register}/{id?}"
        ).RequireCors("auth-input");

        app.MapControllerRoute(
            name: "login",
            pattern: "{controller=User}/{action=Login}/{id?}"
        ).RequireCors("auth-input");
    }
    
}