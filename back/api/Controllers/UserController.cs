using meero.bll;
using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;

public class UserController(IAuthService auth, IConfiguration conf) : Controller
{
    
    [HttpPost]
    public IActionResult Register ([FromBody] UserModel model){
        try
        {
            auth.Register(model);
            return Ok(new{message=""});
        }
        catch (DuplicateEmailException e)
        {
            return Ok(new{message=e.Message});
        }
        catch (DatabaseException e)
        {
            return Ok(new{message=e.Message});
        }
    }

    [HttpPost]
    public IActionResult Login ([FromBody] UserModel model){
        try
        {
            string token = auth.Login(model);

            HttpContext.Response.Cookies.Append(conf["AUTH_TOKEN_NAME"]!, token, new CookieOptions
            {
                HttpOnly = true,   // Prevents JavaScript access to the cookie
                Secure = false,     // Ensures the cookie is sent only over HTTPS
                SameSite = SameSiteMode.Strict, // Prevents CSRF attacks
                Expires = DateTime.UtcNow.AddHours(1) // Set cookie expiration
            });
            return Ok();
        }
        catch (InvalidCredentialException e)
        {
            return Ok(new{message=e.Message});
        }
        catch (UserNotFountException e)
        {
            return Ok(new{message=e.Message});
        }
    }

    [HttpPost]
    public IActionResult Auth (){

        string? token;


        if (!Request.Cookies.TryGetValue(conf["AUTH_TOKEN_NAME"]!, out token))
        {
            return Unauthorized(new { message = "JWT token is missing." });
        }

        try
        {
            return Ok(auth.Auth(token));
        }
        catch (InvalidTokenException e)
        {
            return Unauthorized(new { message = e.Message });
        }
    }

    [HttpPost]
    public IActionResult Logout(){
        HttpContext.Response.Cookies.Delete(conf["AUTH_TOKEN_NAME"]!);
        return Ok();
    }

}