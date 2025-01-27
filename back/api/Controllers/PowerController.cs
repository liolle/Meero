using meero.bll.Service;
using meero.entity;
using Microsoft.AspNetCore.Mvc;
namespace meero.api.controllers;

public class PowerController(IPowerService p) : Controller
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
        return Ok(model);
    }
}