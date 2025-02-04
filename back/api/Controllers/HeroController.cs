using meero.bll;
using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;


public class HeroController(IHeroService h) : ControllerBase
{
    [HttpGet]
    public IActionResult All([FromQuery] bool includePowers)
    {
        return Ok(h.GetAll(includePowers));
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id,bool includePowers)
    {
        return Ok(h.GetById(id,includePowers));
    }

    
    [HttpPost]
    [Authorize]
    public IActionResult Add([FromBody] HeroModel model){

        if (!ModelState.IsValid){
            return BadRequest(ModelState);
        }

        try
        {
            HeroEntity hero = new(){
                Alias=model.Alias,
                Name=model.Name,
                Bio=model.Bio,
                ProfileImage=model.ProfileImage
            };

            h.Insert(hero, model.SelectedPowerIds);
        }
        catch (DuplicatePowerException e)
        {
             return Ok(new{message=e.Message});
        }
        catch (DatabaseException e)
        {
            return Ok(new{message=e.Message});
        }

        return Ok(new{message=""});
    }
}