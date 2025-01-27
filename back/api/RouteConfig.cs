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

        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=User}/{action=Auth}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=User}/{action=Logout}/{id?}"
        ).RequireCors("auth-input");

        // Hero
        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Hero}/{action=Add}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Hero}/{action=Get}/{id?}"
        );

        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Hero}/{action=All}/{id?}"
        );

        // Power
        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Power}/{action=Add}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Power}/{action=Get}/{id?}"
        );

        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Power}/{action=All}/{id?}"
        );
    }
}