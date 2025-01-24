using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;

public class UserController(IAuthService auth) : Controller
{
    
    [HttpPost]
    public IActionResult Register ([FromBody] UserModel model){
        int id = auth.Register(model);
        return Ok(new{id=id});
    }

    [HttpPost]
    public IActionResult Login ([FromBody] UserModel model){
        string token = auth.Login(model);

        HttpContext.Response.Cookies.Append("meero_auth_token", token, new CookieOptions
        {
            HttpOnly = true,   // Prevents JavaScript access to the cookie
            Secure = false,     // Ensures the cookie is sent only over HTTPS
            SameSite = SameSiteMode.Strict, // Prevents CSRF attacks
            Expires = DateTime.UtcNow.AddHours(1) // Set cookie expiration
        });
        return Ok(new{token=token});
    }
}