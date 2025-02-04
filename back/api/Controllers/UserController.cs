using meero.bll;
using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;

public class UserController(IAuthService auth, IConfiguration conf) : ControllerBase
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
            string jwtToken = auth.Login(model);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // 🔒 Prevents JavaScript access (XSS protection)
                Secure = true,   // 🔒 Send only over HTTPS (set to false in development)
                SameSite = SameSiteMode.Strict, // Prevent CSRF attacks
                Expires = DateTime.UtcNow.AddHours(1) // Set cookie expiration same as JWT expiration
            };

            Response.Cookies.Append(conf["AUTH_TOKEN_NAME"], jwtToken, cookieOptions);
            return Ok(new{message="Logged in successfully!"});
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
    [Authorize]
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