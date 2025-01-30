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
            name: "logout",
            pattern: "{controller=User}/{action=Logout}/{id?}"
        ).RequireCors("auth-input");

        // Hero
        app.MapControllerRoute(
            name: "add-hero",
            pattern: "{controller=Hero}/{action=Add}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "get-hero-by-id",
            pattern: "{controller=Hero}/{action=Get}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all-heroes",
            pattern: "{controller=Hero}/{action=All}/{id?}"
        );

        // Power
        app.MapControllerRoute(
            name: "add-power",
            pattern: "{controller=Power}/{action=Add}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "get-power-by-id",
            pattern: "{controller=Power}/{action=Get}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all-powers",
            pattern: "{controller=Power}/{action=All}/{id?}"
        );

        // Location
        app.MapControllerRoute(
            name: "add-location",
            pattern: "{controller=Location}/{action=Add}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "get-location-by-id",
            pattern: "{controller=Location}/{action=Get}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all-locations",
            pattern: "{controller=Location}/{action=All}/{id?}"
        );

        // Event
        app.MapControllerRoute(
            name: "add-event",
            pattern: "{controller=Event}/{action=Add}/{id?}"
        ).RequireAuthorization()
        .RequireCors("auth-input");

        app.MapControllerRoute(
            name: "get-event-by-id",
            pattern: "{controller=Event}/{action=Get}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all-event",
            pattern: "{controller=Event}/{action=All}/{id?}"
        );
    }
}