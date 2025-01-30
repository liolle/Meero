using meero.bll;
using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;

public class PowerController(IPowerService p) : ControllerBase
{
    [HttpGet]
    public IActionResult All()
    {
        return Ok(p.GetAll());
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id,bool includeHeroes )
    {
        return Ok(p.GetById(id,includeHeroes));
    }

    [HttpPost]
    public IActionResult Add([FromBody] PowerModel model){
        try
        {
            PowerEntity power = new(){
                name=model.Name,
            };

            p.Insert(power);
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