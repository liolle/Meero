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
}